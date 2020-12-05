using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Fax : BaseDevice, IFax
    {
        public int ReceivedFaxCounter { get; set; }
        public int SentFaxCounter { get; set; }

        public void ReceiveFax(in IDocument document, int phoneNumber)
        {
            if (state == IDevice.State.on)
            {
                ReceivedFaxCounter++;

                Console.WriteLine($"Received document: { document.GetFileName() } from: { phoneNumber }");
            }
        }

        public void SendFax(in IDocument document, int phoneNumber)
        {
            if (state == IDevice.State.on)
            {
                SentFaxCounter++;

                Console.WriteLine($"Sending document: { document.GetFileName() } to: { phoneNumber }");
            }
        }
    }
}
