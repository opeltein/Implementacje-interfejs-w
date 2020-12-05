using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie1;
using Zadanie1UnitTests;
using Zadanie2;

namespace Zadanie2UnitTests
{
    [TestClass]
    public class UnitTestFax
    {
        [TestMethod]
        public void MultiFunctionalDevice_SentFaxCounter()
        {
            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();

            IDocument doc1;
            multifunctionalDevice.SendFax(out doc1, 0700800800);
            IDocument doc2;
            multifunctionalDevice.SendFax(out doc2, 0700800800);
            IDocument doc3;
            multifunctionalDevice.SendFax(out doc3, 0700800800);

            multifunctionalDevice.PowerOff();
            multifunctionalDevice.SendFax(out doc3, 0700800800);
            multifunctionalDevice.PowerOn();

            multifunctionalDevice.ScanAndPrint();
            multifunctionalDevice.ScanAndPrint();

            Assert.AreEqual(3, multifunctionalDevice.SentFaxCounter);
        }

        [TestMethod]
        public void MultiFunctionalDevice_ReceivedFaxCounter()
        {
            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();

            IDocument doc1 = new ImageDocument("aaa.jpg"); ;
            multifunctionalDevice.ReceiveFax(in doc1, 0700800800);
            IDocument doc2 = new ImageDocument("aaa.jpg"); ;
            multifunctionalDevice.ReceiveFax(in doc2, 0700800800);

            IDocument doc3 = new ImageDocument("aaa.jpg");
            multifunctionalDevice.ReceiveFax(in doc3, 0700800800);

            multifunctionalDevice.PowerOff();
            multifunctionalDevice.ReceiveFax(in doc3, 0700800800);
            multifunctionalDevice.PowerOn();


            Assert.AreEqual(3, multifunctionalDevice.ReceivedFaxCounter);
        }


        [TestMethod]
        public void Fax_ReceiveFax_DeviceOn()
        {
            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionalDevice.ReceiveFax(in doc1, 0800700700);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Received"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }


        [TestMethod]
        public void Fax_SendFax_DeviceOn()
        {
            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multifunctionalDevice.SendFax(out doc1, 0700800800);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Sending"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void Fax_ReceiveFax_DeviceOff()
        {
            var multifunctionalDevice = new MultifunctionalDevice();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionalDevice.ReceiveFax(in doc1, 0800700700);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Received"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }


        [TestMethod]
        public void Fax_SendFax_DeviceOff()
        {
            var multifunctionalDevice = new MultifunctionalDevice();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multifunctionalDevice.SendFax(out doc1, 0700800800);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Sending"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}
