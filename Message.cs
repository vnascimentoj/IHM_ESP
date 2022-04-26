using System;
using System.Collections.Generic;
using System.Linq;

namespace IHM_ESP
{
    public abstract class Message
    {   
        const int CHECKSUM_SIZE = 1; //Em bytes
        public byte length { get; protected set; }
        public abstract byte code { get; }
        public byte[] data { get; protected set; }
        byte checkSum;

        public Message() { }
        public Message(byte[] data)
        {
            this.data = data;
        }

        public byte[] Encode()
        {
            List<byte> buffer = new List<byte>();

            buffer.Add(code);

            if(data != null)
                foreach (byte d in data)
                    buffer.Add(d);

            length = Convert.ToByte(buffer.Count + CHECKSUM_SIZE);
            buffer.Insert(0, length);

            checkSum = Convert.ToByte(buffer.Sum(b => b) % 256);
            buffer.Add(checkSum);

            return buffer.ToArray();
        }

        #region EVENTOS
        public delegate void MessageEventHandler(Message message);
        public event MessageEventHandler OnMessageReceived;

        public virtual void MessageReceived(Message message)
        {
            if (OnMessageReceived != null) OnMessageReceived(message);
        }
        #endregion
    }
}
