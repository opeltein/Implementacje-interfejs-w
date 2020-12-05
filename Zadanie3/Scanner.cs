using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Scanner : BaseDevice, IScanner
    {
        public int ScanCounter { get; set; } = 0;

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
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
    }
}
