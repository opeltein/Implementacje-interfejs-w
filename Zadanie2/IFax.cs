using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;

namespace Zadanie2
{
    public interface IFax : IDevice
    {
        int ReceivedFaxCounter { get; set; }
        int SentFaxCounter { get; set; }
        void SendFax(out IDocument document, int phoneNumber);
        void ReceiveFax(in IDocument document, int phoneNumber);
    }
}
