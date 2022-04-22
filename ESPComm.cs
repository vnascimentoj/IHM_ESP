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
        SerialPort serialPort;
        public delegate void MessageReceivedEventHandler(byte[] message);
        Dictionary<int, MessageReceivedEventHandler> onMessageReceived;

        public ESPComm(string comPort, int baudRate)
        {
            serialPort = new SerialPort(comPort, baudRate);
            serialPort.DataReceived += serialPort_DataReceived;
            onMessageReceived = new Dictionary<int, MessageReceivedEventHandler>();
            //onMessageReceived[new SetPMessage().code] = (b) => Debug.WriteLine("Era pra fazer algo aqui");

            checkDuplicateMessageCodes();
        }

        private void checkDuplicateMessageCodes()
        {
            Type[] types = GetInheritedClasses(typeof(Message));
            Dictionary<int, Type> codeMessagePair = new Dictionary<int, Type>();
            foreach(var type in types)
            {
                Message instance = (Message)Activator.CreateInstance(type);
                
                if(codeMessagePair.ContainsKey(instance.code))
                    Debug.Assert(!codeMessagePair.ContainsKey(instance.code), codeMessagePair[instance.code].Name + " e " + type.Name +
                             " compartilham o mesmo código (" + instance.code.ToString() + ")");


                codeMessagePair[instance.code] = type;
                
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
            if (!SpinWait.SpinUntil(() => serialPort.BytesToRead >= bytesToRead, 50))
            {
                serialPort.DiscardInBuffer();
                return;
            }

            byte[] buffer = new byte[bytesToRead];
            serialPort.Read(buffer, 0, bytesToRead);

            int code = buffer[0];
            int checksum = buffer[buffer.Length - 1];

            int sum = 0;
            for (int i = 0; i < bytesToRead - 1; i++)
                sum += buffer[i];

            
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
            throw new NotImplementedException();
        }

        public override void SetPWM(int duty)
        {
            throw new NotImplementedException();
        }

        public override void SetRPM(int rpm)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void SetMaxPwm(double duty)
        {
            throw new NotImplementedException();
        }

        public override void SetMinPwm(int duty)
        {
            throw new NotImplementedException();
        }

        public override void SetMinPwm(double duty)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
