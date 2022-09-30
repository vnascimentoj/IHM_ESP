using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_ESP
{   
    public static class Modbus
    {
        public enum Device : byte
        {
            ESP_USB = 0x01
        }
        public enum DataAccess : byte
        {
            READ_DISCRETE_INPUT             = 0x02,
            READ_COILS                      = 0x01,
            WRITE_SINGLE_COIL               = 0x05,
            WRITE_MULTIPLE_COILS            = 0x0F,
            READ_INPUT_REGISTER             = 0x04,
            READ_HOLDING_REGISTERS          = 0x03,
            WRITE_SINGLE_REGISTER           = 0x06,
            WRITE_MULTIPLE_REGISTERS        = 0x10,
            READ_WRITE_MULTIPLE_REGISTERS   = 0x17,
            MASK_WRITE_REGISTER             = 0x16,
            READ_FIFO_QUEUE                 = 0x18
        }

        private static byte[] GetCRC(byte[] message)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:
            byte[] CRC = new byte[2];
            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);

            return CRC;
        }

        /// <summary>
        /// Formata uma mensagem de leitura ou escrita simples.
        /// </summary>
        /// <param name="device">Dispositivo para o qual a mensagem é endereçada.</param>
        /// <param name="fnCode">Tipo de mensagem.</param>
        /// <param name="startingAddress">Endereço inicial a ser lido/escrito.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] SingleMessage(Device device, DataAccess fnCode, UInt16 startingAddress, UInt16 value)
        {
            byte[] message = new byte[8];

            message[0] = (byte)device;
            message[1] = (byte)fnCode;
            message[2] = (byte)(startingAddress >> 8);
            message[3] = (byte)startingAddress;
            message[4] = (byte)(value >> 8);
            message[5] = (byte)value;
            
            return message.Concat(GetCRC(message)).ToArray();
        }

    }
}
