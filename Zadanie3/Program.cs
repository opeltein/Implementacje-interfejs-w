using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var xerox = new Copier();

            xerox.PowerOn();
            xerox.TurnPrinterOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            xerox.TurnScannerOn();
            IDocument doc2;
            xerox.Scan(out doc2);

            xerox.ScanAndPrint();
            Console.WriteLine(xerox.Counter);
            Console.WriteLine(xerox.PrintCounter);
            Console.WriteLine(xerox.ScanCounter);

            Console.WriteLine();
            Console.WriteLine();

            var multiFuncDevice = new MultidimensionalDevice();
            multiFuncDevice.PowerOn();
            multiFuncDevice.TurnFaxOn();
            multiFuncDevice.TurnPrinterOn();
            multiFuncDevice.TurnScannerOn();

            IDocument doc3;
            multiFuncDevice.SendFax(out doc3, 0700800800);

            IDocument doc4 = new ImageDocument("ImgDoc.jpg");

            multiFuncDevice.ReceiveFax(in doc4, 0800700700);

            Console.WriteLine(multiFuncDevice.ReceivedFaxCounter);
            Console.WriteLine(multiFuncDevice.SentFaxCounter);
        }
    }
}
