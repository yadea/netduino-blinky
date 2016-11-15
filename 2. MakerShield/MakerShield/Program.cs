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
            // write your code here
            OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);
            InputPort button = new InputPort(Pins.GPIO_PIN_D1, false, Port.ResistorMode.PullUp);
            bool buttonState = false;

            while (true)
            {
                buttonState = !button.Read();
                led.Write(buttonState);
            }
        }

    }
}
