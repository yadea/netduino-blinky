using System;
using System.Threading;
using SecretLabs.NETMF.Hardware.Netduino;
using SecretLabs.NETMF.Hardware;

namespace _3.PulseWidthModulation
{
    public class Program
    {
        public static void Main()
        {
            // 
            SecretLabs.NETMF.Hardware.PWM led = new SecretLabs.NETMF.Hardware.PWM(Pins.GPIO_PIN_D5);
            AnalogInput pot = new AnalogInput(Pins.GPIO_PIN_A0);
            pot.SetRange(0, 100);

            int potValue = 0;

            while(true)
            {
                //read potentiometer value
                potValue = pot.Read();

                //change LED intensity based on potentiometer value
                led.SetDutyCycle((uint)potValue);
            }
        }

    }
}
