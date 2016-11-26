using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace MakerShield
{
    public class Program
    {
        public static void Main()
        {
            // Toggle light when shield button is pressed.
            /*OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);
            InputPort button = new InputPort(Pins.GPIO_PIN_D1, false, Port.ResistorMode.PullUp);
            bool buttonState = false;

            while (true)
            {
                buttonState = !button.Read();
                led.Write(buttonState);
            }*/

            // Measure voltage from potentiometer
            OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);
            var pot = new SecretLabs.NETMF.Hardware.AnalogInput(Pins.GPIO_PIN_A0); //need to inport SecretLabs.NETMF.Hardware.AnalogInput reference.

            int potValue = 0;

            while(true)
            {
                //read the potentiometer value
                potValue = pot.Read();
                Debug.Print(potValue.ToString());

                //blink value based on value (0-1023 ms)
                led.Write(true);
                Thread.Sleep(potValue);
                led.Write(false);
                Thread.Sleep(potValue);
            }
        }
    }
}
