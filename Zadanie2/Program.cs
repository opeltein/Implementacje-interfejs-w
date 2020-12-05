using System;
using Zadanie1;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            var multiFuncDevice = new MultifunctionalDevice();
            multiFuncDevice.PowerOn();
            IDocument doc3;
            multiFuncDevice.SendFax(out doc3, 0700800800);

            IDocument doc4 = new ImageDocument("ImgDoc.jpg");

            multiFuncDevice.ReceiveFax(in doc4, 0800700700);

            Console.WriteLine(multiFuncDevice.ReceivedFaxCounter);
            Console.WriteLine(multiFuncDevice.SentFaxCounter);
        }
    }
}
