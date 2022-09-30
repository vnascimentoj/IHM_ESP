using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_ESP.Devices
{
    class ESP32_USB
    {
        public const byte Address = 0x01;

        /// <summary>
        /// Estado atual do dispositivo
        /// </summary>
        public enum DeviceState : UInt16
        {
            Idle = 1,
            Running = 2,
            Failure = 3
        }

        /// <summary>
        /// Registradores de entrada (apenas leitura)
        /// </summary>
        public enum InputRegisters : UInt16
        {
            Voltage = 1,
            Current = 2,
            RPM = 3
        }

        /// <summary>
        /// Registradores de uso geral (leitura e escrita)
        /// </summary>
        public enum HoldingRegisters : UInt16
        {
            Kp = 1,
            Ki = 2,
            Kd = 3,
            Pwm = 4,
            PwmInitialValue = 5,
            PwmMinValue = 6,
            PwmMaxValue = 7,
            SetPointRPM = 8,
            DeviceState = 9
        }
    }
}
