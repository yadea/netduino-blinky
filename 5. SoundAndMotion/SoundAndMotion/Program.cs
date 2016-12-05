using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace SoundAndMotion
{
    public class Program
    {
        public static void Main()
        {
            Hashtable scale = new Hashtable();

            // low octave
            scale.Add("c", 1915u);
            scale.Add("d", 1700u);
            scale.Add("e", 1519u);
            scale.Add("f", 1432u);
            scale.Add("g", 1275u);
            scale.Add("a", 1136u);
            scale.Add("b", 1014u);

            // high octave
            scale.Add("C", 956u);
            scale.Add("D", 851u);
            scale.Add("E", 758u);

            // silence ("hold note")
            scale.Add("h", 0u);

            int beatsPerMinute = 90;
            int beatTimeInMilliseconds = 60000 / beatsPerMinute; // 60,000 ms per min
            int pauseTimeInMilliseconds = (int)(beatTimeInMilliseconds * 0.1);

            // define the song(letter of note followed by length of note)
            string song = "C1C1C1g1a1a1g2E1E1D1D1C2";

            // define the speaker
            PWM speaker = new PWM(Pins.GPIO_PIN_D5);

            while (true)
            {
                for (int i = 0; i < song.Length; i += 2)
                {
                    // song loop
                    // extract each note and its length in beats
                    string note = song.Substring(i, 1);
                    int beatCount = int.Parse(song.Substring(i + 1, 1));

                    // look up the note duration(in microseconds)
                    uint noteDuration = (uint)scale[note];

                    // play the note for the desired number of beats
                    speaker.SetPulse(noteDuration * 2, noteDuration);
                    Thread.Sleep(beatTimeInMilliseconds * beatCount - pauseTimeInMilliseconds);

                    // pause for 1/10th of a beat in between every note.
                    speaker.SetDutyCycle(0);
                    Thread.Sleep(pauseTimeInMilliseconds);
                }

                //Thread.Sleep(Timeout.Infinite);
                Thread.Sleep(1000);
            }
        }

    }
}
