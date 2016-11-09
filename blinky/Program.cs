using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace blinky
{
    public class Program
    {
        public static void Main()
        {
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            InputPort button = new InputPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled);
            bool buttonState = false;

            while(true)
            {
                buttonState = button.Read();
                led.Write(buttonState);
                //led.Write(true);
                //Thread.Sleep(250);
                //led.Write(false);
                //Thread.Sleep(250);
            }
        }

    }
}
