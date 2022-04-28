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

        public ESPComm(string comPort, int baudRate)
        {
            serialPort = new SerialPort(comPort, baudRate);
            serialPort.DataReceived += serialPort_DataReceived;
            onMessageReceived = new Dictionary<int, MessageReceivedEventHandler>();

            serialPort.Open();

            checkDuplicateMessageCodes();
            printAllMessages();
        }

        public override void RegisterEvent(int code, MessageReceivedEventHandler func)
        {
            onMessageReceived[code] = func;
        }

        private void checkDuplicateMessageCodes()
        {
            Type[] types = GetInheritedClasses(typeof(Message));
            
            foreach(var type in types)
            {
                Message instance = (Message)Activator.CreateInstance(type);
                
                if(codeMessagePair.ContainsKey(instance.code))
                    Debug.Assert(!codeMessagePair.ContainsKey(instance.code), codeMessagePair[instance.code].Name + " e " + type.Name +
                             " compartilham o mesmo código (" + instance.code.ToString() + ")");


                codeMessagePair[instance.code] = type;                
            }
        }

        public void printAllMessages()
        {            
            //foreach(var item in codeMessagePair)
            foreach(var item in codeMessagePair.ToArray().OrderBy(i => i.Key))
            {
                Debug.WriteLine("Código: {0}\tMensagem {1}", item.Key, item.Value);
            }
        }

        Type[] GetInheritedClasses(Type MyType)
        {
            //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
            return (Type[])Assembly.GetAssembly(MyType).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(MyType)).ToArray();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort.ReadByte();
            if (bytesToRead == 0)
                return;

            if (!SpinWait.SpinUntil(() => serialPort.BytesToRead >= bytesToRead, 50))
            {
                serialPort.DiscardInBuffer();
                return;
            }

            byte[] buffer = new byte[bytesToRead];
            serialPort.Read(buffer, 0, bytesToRead);

            int code = buffer[0];
            int checksum = buffer[buffer.Length - 1];

            int sum = bytesToRead;
            for (int i = 0; i < bytesToRead - 1; i++)
                sum += buffer[i];
            
            Debug.WriteLine("Tam: " + bytesToRead.ToString() + " Msg: " + BitConverter.ToString(buffer));

            if (checksum != (sum % 256))
            {
                Debug.WriteLine("Erro de checksum");
                return;
            }
            
            // Encaminha mensagem recebida para a função adequada (se houver)
            if (onMessageReceived.ContainsKey(code))
                onMessageReceived[code](buffer);
        }

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
            SetPwmMessage setPwmMessage = new SetPwmMessage(BitConverter.GetBytes(value));
            sendMessage(setPwmMessage);
        }

        public override void SetPWM(int duty)
        {
            SetPWM(Convert.ToDouble(duty) / 100);
        }

        public override void SetRPM(int rpm)
        {
            sendMessage(new SetRpmMessage(rpm));
        }

        public override void Start()
        {
            sendMessage(new StartMessage());
        }

        public override void Stop()
        {
            sendMessage(new StopMessage());
        }

        protected void sendMessage(Message message)
        {
            if(serialPort.IsOpen)
            {
                serialPort.Write(message.Encode(), 0, message.length + 1);
            }
        }

        public override void SetMaxPwm(int duty)
        {
            sendMessage(new SetMaxPwmMessage(duty));
        }

        public override void SetMaxPwm(double duty)
        {
            int value = Convert.ToInt32(Math.Round(duty * MAX_PWM));
            SetMaxPwm(value);
        }

        public override void SetMinPwm(int duty)
        {
            sendMessage(new SetMinPwmMessage(duty));
        }

        public override void SetMinPwm(double duty)
        {
            int value = Convert.ToInt32(Math.Round(duty * MAX_PWM));
            SetMinPwm(value);
        }

        public override void SetMaxCurrent(double current)
        {
            throw new NotImplementedException();
        }

        public override void SetP(double p)
        {
            throw new NotImplementedException();
        }

        public override void SetI(double i)
        {
            throw new NotImplementedException();
        }

        public override void SetD(double d)
        {
            throw new NotImplementedException();
        }

        public override double GetMaxCurrent()
        {
            throw new NotImplementedException();
        }

        public override double GetCurrent()
        {
            bool ready = false;
            int value = -1;
            GetCurrentMessage getCurrentMessage = new GetCurrentMessage();
            getCurrentMessage.OnMessageReceived += (msg) =>
            {
                ready = true;
                //value = Convert.ToInt32(new ArraySegment<byte>(msg.data, 1, 4));
                value = BitConverter.ToInt32(new ArraySegment<byte> (msg.data, 1, 4).ToArray(), 0);
            };
            sendMessage(getCurrentMessage);
            System.Threading.SpinWait.SpinUntil(() => ready, 100);

            return value;
        }

        public override double GetMaxPwm()
        {
            throw new NotImplementedException();
        }

        public override double GetMinPwm()
        {
            throw new NotImplementedException();
        }

        public override double GetP()
        {
            throw new NotImplementedException();
        }

        public override double GetI()
        {
            throw new NotImplementedException();
        }

        public override double GetD()
        {
            throw new NotImplementedException();
        }
    }
}
