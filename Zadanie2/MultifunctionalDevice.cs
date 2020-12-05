using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;

namespace Zadanie2
{
    public class MultifunctionalDevice : Copier, IFax
    {
        public int ReceivedFaxCounter { get; set; } = 0;
        public int SentFaxCounter { get; set; } = 0;

        public void ReceiveFax(in IDocument document, int phoneNumber)
        {
            if (state == IDevice.State.on)
            {
                ReceivedFaxCounter++;

                Console.WriteLine($"Received document: { document.GetFileName() } from: { phoneNumber }");
            }
            Print(document);
        }

        public void SendFax(out IDocument document, int phoneNumber)
        {
            Scan(out document);

            if (state == IDevice.State.on)
            {
                SentFaxCounter++;

                Console.WriteLine($"Sending document: { document.GetFileName() } to: { phoneNumber }");
            }
        }




    }
}
