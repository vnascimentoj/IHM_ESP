using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace IHM_ESP
{
    public class ESPComm : IComm
    {
        const int MAX_PWM = 1023;
        SerialPort serialPort;
        
        Dictionary<int, MessageReceivedEventHandler> onMessageReceived;
        Dictionary<int, Type> codeMessagePair = new Dictionary<int, Type>();
        byte[] response;

        int messageIntervalInTicks;
        public override bool IsOpen 
        { 
            get 
            {
                if (serialPort != null)
                    return serialPort.IsOpen;

                return false;
            } 
        }

        public ESPComm(string comPort, int baudRate)
        {
            serialPort = new SerialPort(comPort, baudRate);
            //serialPort.DataReceived += serialPort_DataReceived;
            onMessageReceived = new Dictionary<int, MessageReceivedEventHandler>();

            serialPort.Open();
            messageIntervalInTicks = Convert.ToInt32(3.5 * Stopwatch.Frequency / baudRate);

            //checkDuplicateMessageCodes();
            //printAllMessages();
        }

        public override void RegisterEvent(int code, MessageReceivedEventHandler func)
        {
            onMessageReceived[code] = func;
        }

        //private void checkDuplicateMessageCodes()
        //{
        //    Type[] types = GetInheritedClasses(typeof(Message));
            
        //    foreach(var type in types)
        //    {
        //        Message instance = (Message)Activator.CreateInstance(type);
                
        //        if(codeMessagePair.ContainsKey(instance.code))
        //            Debug.Assert(!codeMessagePair.ContainsKey(instance.code), codeMessagePair[instance.code].Name + " e " + type.Name +
        //                     " compartilham o mesmo código (" + instance.code.ToString() + ")");


        //        codeMessagePair[instance.code] = type;                
        //    }
        //}

        //public void printAllMessages()
        //{            
        //    //foreach(var item in codeMessagePair)
        //    foreach(var item in codeMessagePair.ToArray().OrderBy(i => i.Key))
        //    {
        //        Debug.WriteLine("Código: {0}\tMensagem {1}", item.Key, item.Value);
        //    }
        //}

        //Type[] GetInheritedClasses(Type MyType)
        //{
        //    //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
        //    return (Type[])Assembly.GetAssembly(MyType).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(MyType)).ToArray();
        //}

        //private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    int bytesToRead = serialPort.ReadByte();
        //    if (bytesToRead == 0)
        //        return;

        //    if (!SpinWait.SpinUntil(() => serialPort.BytesToRead >= bytesToRead, 50))
        //    {
        //        serialPort.DiscardInBuffer();
        //        return;
        //    }

        //    byte[] buffer = new byte[bytesToRead];
        //    serialPort.Read(buffer, 0, bytesToRead);

        //    int code = buffer[0];
        //    int checksum = buffer[buffer.Length - 1];

        //    int sum = bytesToRead;
        //    for (int i = 0; i < bytesToRead - 1; i++)
        //        sum += buffer[i];
            
        //    Debug.WriteLine("Tam: " + bytesToRead.ToString() + " Msg: " + BitConverter.ToString(buffer));

        //    if (checksum != (sum % 256))
        //    {
        //        Debug.WriteLine("Erro de checksum");
        //        return;
        //    }
            
        //    // Encaminha mensagem recebida para a função adequada (se houver)
        //    if (onMessageReceived.ContainsKey(code))
        //        onMessageReceived[code](buffer);
        //}

        public override double GetPWMDuty()
        {
            throw new NotImplementedException();
        }

        public override int GetRPM()
        {
            throw new NotImplementedException();
        }

        public override void SetPWM(double duty)
        {
            if (duty < 0 || duty > 1)
                throw new Exception("duty: " + duty.ToString() + " está fora do intervalo: 0 <= duty <= 1");

            int value = Convert.ToInt32(Math.Round(duty * MAX_PWM));
            byte[] setPwmMessage = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB, 
                                                             Modbus.DataAccess.WRITE_SINGLE_REGISTER, 
                                                             (UInt16)Devices.ESP32_USB.HoldingRegisters.Pwm, 
                                                             (UInt16)value);

            sendMessage(setPwmMessage, setPwmMessage.Length);
        }

        public override void SetPWM(int duty)
        {
            SetPWM(Convert.ToDouble(duty) / 100);
        }

        public override void SetRPM(int rpm)
        {
            byte[] setRpmMessage = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                             Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                             (UInt16)Devices.ESP32_USB.HoldingRegisters.SetPointRPM,
                                                             (UInt16)rpm);

            sendMessage(setRpmMessage, setRpmMessage.Length);
        }

        public override void Start()
        {
            byte[] startMessage = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                            Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                            (UInt16)Devices.ESP32_USB.HoldingRegisters.DeviceState,
                                                            (UInt16)Devices.ESP32_USB.DeviceState.Running);

            sendMessage(startMessage, startMessage.Length);
        }

        public override void Stop()
        {
            byte[] stopMessage = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                            Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                            (UInt16)Devices.ESP32_USB.HoldingRegisters.DeviceState,
                                                            (UInt16)Devices.ESP32_USB.DeviceState.Idle);

            sendMessage(stopMessage, stopMessage.Length);
        }

        protected bool sendMessage(byte[] message, int responseLength)
        {
            bool success = false;
            if(serialPort.IsOpen)
            {
                serialPort.Write(message, 0, message.Length);

                if (!SpinWait.SpinUntil(() => serialPort.BytesToRead >= responseLength, 50))
                    serialPort.DiscardInBuffer();
                else
                {
                    response = Modbus.GetResponse(serialPort, responseLength);

                    success = Modbus.CheckResponse(response);
                }
            }

            // Aguarda o intervalo mínimo entre mensagens (tempo de 3.5 caracteres)
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.ElapsedTicks < messageIntervalInTicks) ;

            return success;
        }

        public override void SetMaxPwm(int duty)
        {
            byte[] maxPwmMessage = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                            Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                            (UInt16)Devices.ESP32_USB.HoldingRegisters.PwmMaxValue,
                                                            (UInt16)duty);

            sendMessage(maxPwmMessage, maxPwmMessage.Length);
        }

        public override void SetMaxPwm(double duty)
        {
            int value = Convert.ToInt32(Math.Round(duty * MAX_PWM));
            SetMaxPwm(value);
        }

        public override void SetMinPwm(int duty)
        {
            byte[] minPwmMessage = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                            Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                            (UInt16)Devices.ESP32_USB.HoldingRegisters.PwmMaxValue,
                                                            (UInt16)duty);

            sendMessage(minPwmMessage, minPwmMessage.Length);
        }

        public override void SetMinPwm(double duty)
        {
            int value = Convert.ToInt32(Math.Round(duty * MAX_PWM));
            SetMinPwm(value);
        }


        public override void SetP(double kp)
        {
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.Kp,
                                                       (UInt16)kp);

            sendMessage(message, message.Length);
        }

        public override void SetI(double ki)
        {
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.Ki,
                                                       (UInt16)ki);

            sendMessage(message, message.Length);
        }

        public override void SetD(double kd)
        {
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.WRITE_SINGLE_REGISTER,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.Kd,
                                                       (UInt16)kd);

            sendMessage(message, message.Length);
        }


        public override double GetCurrent()
        {
            int value = -1;

            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.READ_INPUT_REGISTER,
                                                       (UInt16)Devices.ESP32_USB.InputRegisters.Current,
                                                       1);

            if(sendMessage(message, message.Length - 2))
                value = BitConverter.ToInt32(new ArraySegment<byte>(response, 6, 4).ToArray(), 0);

            return value;
        }

        public override double GetMaxPwm()
        {
            double pwm = -1.0;
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.READ_HOLDING_REGISTERS,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.PwmMaxValue,
                                                       1);

            if(sendMessage(message, message.Length - 2))
                pwm = BitConverter.ToInt32(new ArraySegment<byte>(response, 6, 4).ToArray(), 0) / 1024;

            return pwm;
        }

        public override double GetMinPwm()
        {
            double pwm = -1.0;
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.READ_HOLDING_REGISTERS,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.PwmMinValue,
                                                       1);

            if (sendMessage(message, message.Length - 2))
                pwm = BitConverter.ToInt32(new ArraySegment<byte>(response, 6, 4).ToArray(), 0) / 1024;

            return pwm;
        }

        public override double GetKp()
        {
            double kp = -1.0;
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.READ_HOLDING_REGISTERS,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.Kp,
                                                       1);

            if (sendMessage(message, message.Length - 2))
                kp = BitConverter.ToInt32(new ArraySegment<byte>(response, 6, 4).ToArray(), 0);

            return kp;
        }

        public override double GetKi()
        {
            double ki = -1.0;
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.READ_HOLDING_REGISTERS,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.Ki,
                                                       1);

            if (sendMessage(message, message.Length - 2))
                ki = BitConverter.ToInt32(new ArraySegment<byte>(response, 6, 4).ToArray(), 0);

            return ki;
        }

        public override double GetKd()
        {
            double kd = -1.0;
            byte[] message = Modbus.BuildSingleMessage(Modbus.Device.ESP_USB,
                                                       Modbus.DataAccess.READ_HOLDING_REGISTERS,
                                                       (UInt16)Devices.ESP32_USB.HoldingRegisters.Kd,
                                                       1);

            if (sendMessage(message, message.Length - 2))
                kd = BitConverter.ToInt32(new ArraySegment<byte>(response, 6, 4).ToArray(), 0);

            return kd;
        }

        public override void Disconnect()
        {
            if (serialPort != null)
                serialPort.Close();
        }
    }
}
