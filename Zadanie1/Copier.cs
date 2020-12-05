using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        
        public int PrintCounter { get; set; } = 0;

        public int ScanCounter { get; set; } = 0;


        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                PrintCounter++;
                Console.WriteLine($"{ DateTime.Now } Print: {document.GetFileName()}");
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            switch (formatType)
            {
                case IDocument.FormatType.TXT:
                    document = new TextDocument("TextScan" + ScanCounter.ToString("0000.##") + ".txt");
                    break;
                case IDocument.FormatType.PDF:
                    document = new PDFDocument("PDFScan" + ScanCounter.ToString("0000.##") + ".pdf");
                    break;
                case IDocument.FormatType.JPG:
                    document = new TextDocument("ImageScan" + ScanCounter.ToString("0000.##") + ".jpg");
                    break;
                default:
                    throw new Exception();
            }

            if (state == IDevice.State.on)
            {
                ScanCounter++;
                Console.WriteLine($"{ DateTime.Now } Scan: { document.GetFileName() }");
            }
            
        }

        public void ScanAndPrint()
        {
            if (state == IDevice.State.on)
            {
                IDocument document;
                Scan(out document, IDocument.FormatType.JPG);
                Print(document);
            }
        }

    }
}
