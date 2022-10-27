using IHM_ESP.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IHM_ESP
{
    public class ControllerSettings
    {       
        [ESP32Register("Ganho proporcional x 1k", ESP32_USB.HoldingRegisters.Kp)]
        public UInt16 Kp { get; set; }

        [ESP32Register("Ganho integral x 1k", ESP32_USB.HoldingRegisters.Ki)] 
        public UInt16 Ki { get; set; }

        [ESP32Register("Ganho derivativo x 1k", ESP32_USB.HoldingRegisters.Kd)]
        public UInt16 Kd { get; set; }
        
        [ESP32Register("Valor atual do PWM", ESP32_USB.HoldingRegisters.Pwm)] 
        public UInt16 Pwm { get; set; }

        [ESP32Register("Valor inicial do PWM", ESP32_USB.HoldingRegisters.PwmInitialValue)]
        public UInt16 PwmInitial { get; set; }

        [ESP32Register("Valor mínimo de PWM", ESP32_USB.HoldingRegisters.PwmMinValue)]
        public UInt16 PwmMin { get; set; }

        [ESP32Register("Valor máximo de PWM", ESP32_USB.HoldingRegisters.PwmMaxValue)]
        public UInt16 PwmMax { get; set; }

        [ESP32Register("Valor do PWM de campo", ESP32_USB.HoldingRegisters.FieldPwm)]
        public UInt16 FieldPwm { get; set; }

        [ESP32Register("Velocidade alvo", ESP32_USB.HoldingRegisters.SetPointRPM)]
        public UInt16 SetPointRPM { get; set; }

        [ESP32Register("Estado do controlador", ESP32_USB.HoldingRegisters.DeviceState)]
        public UInt16 DeviceState { get; set; }

        public void FillFromBytes(byte[] data)
        {
            const int register_index_offset = 1;

            foreach(FieldInfo field in GetType().GetFields())
            {
                ESP32RegisterAttribute attr = field.GetCustomAttribute<ESP32RegisterAttribute>();
                
                int i = ((int)attr.register - register_index_offset) * sizeof(UInt16);
                UInt16 value = (UInt16)((data[i] << 8) + data[i + 1]);
                field.SetValue(this, value);
            }
            
        }
    }
}
