using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Zadanie4
{
    public class Copier : IPrinter, IScanner
    {
        private IPrinter _printer;
        private IScanner _scanner;
        private IDevice.State _printerState = IDevice.State.off;
        private IDevice.State _scannerState = IDevice.State.off;

        void IDevice.SetState(IDevice.State state)
        {
            _printer.SetState(state);
            _scanner.SetState(state);
        }

        void IPrinter.SetState(IDevice.State state)
        {
            _printerState = state;
        }

        void IScanner.SetState(IDevice.State state)
        {
            _scannerState = state;
        }

        public IDevice.State GetState() 
        {
            if (_printerState == IDevice.State.off && _scannerState == IDevice.State.off)
                return IDevice.State.off;
            else if (_printerState == IDevice.State.standby && _scannerState == IDevice.State.standby)
                return IDevice.State.standby;
            else
                return IDevice.State.on;
        }

        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;

        public int Counter { get; set; } = 0;

        public Copier()
        {
            _printer = this;
            _scanner = this;
        }

        public void TurnCopierOn()
        {
            if (GetState() == IDevice.State.off)
            {
                _printer.StandbyOn();
                _scanner.StandbyOn();
                Counter++;
            }
        }
        public void TurnCopierOff()
        {
            if (GetState() != IDevice.State.off)
            {
                ((IDevice)this).PowerOff();
            }
        }
        public void TurnCopierStandbyOn()
        {
            if (GetState() != IDevice.State.standby)
            {
                ((IDevice)this).StandbyOn();
            }
        }
        public void TurnCopierStandbyOff()
        {
            if (GetState() == IDevice.State.standby)
            {
                ((IDevice)this).StandbyOff();
            }
        }

        public void Print(in IDocument document)
        {
            _printer.StandbyOff();
            _scanner.StandbyOn();
            if (PrintCounter % 3 == 0 && PrintCounter != 0)
            {
                _printer.StandbyOn();
                Console.WriteLine($"{ PrintCounter } pages was printed. Initialization...");
                Thread.Sleep(3000);
                _printer.StandbyOff();

            }
            Console.WriteLine($"{ DateTime.Now } Print: {document.GetFileName()}");
            PrintCounter++;
            
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {

            _scanner.StandbyOff();
            _printer.StandbyOn();

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

            if (ScanCounter % 3 == 0 && ScanCounter != 0)
            {
                _scanner.StandbyOn();
                Console.WriteLine($"{ ScanCounter } pages was scanned. Initialization...");
                Thread.Sleep(3000);
                _scanner.StandbyOff();

            }

            ScanCounter++;
            Console.WriteLine($"{ DateTime.Now } Scan: { document.GetFileName() }");
        }

        public void ScanAndPrint()
        {
            Console.WriteLine("Scanning and printing...");
            IDocument document;
            Scan(out document, IDocument.FormatType.JPG);
            Print(document);

        }

        
    }
}
