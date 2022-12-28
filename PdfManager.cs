using PdfiumViewer;
using System.Drawing.Printing;
using System;

namespace PdfLibrary
{
    public class PdfManager
    {
        private string filepath;

        public event EventHandler<PrintEventArgs> PdfPrinted;
        public event EventHandler<EventArgs> PdfUnloaded;
        public event EventHandler<EventArgs> PdfClosed;

        public void SendPdfToPrinter(string filepath, string printer)
        {
            this.filepath = filepath;
            using (var doc = PdfDocument.Load(filepath))
            {
                using (var pd = doc.CreatePrintDocument())
                {
                    pd.EndPrint += new PrintEventHandler(Printed);
                    pd.PrinterSettings = new PrinterSettings
                    {
                        PrinterName = printer,
                        Copies = 1
                    };
                    pd.PrintController = new StandardPrintController();

                    pd.Print();
                }

                Closed(this, new EventArgs());
            }

            Unloaded(this, new EventArgs());
        }

        public void Printed(object obj, PrintEventArgs ev)
        {
            PdfPrinted?.Invoke(this, ev);
        }

        public void Unloaded(object obj, EventArgs ev)
        {
            PdfUnloaded?.Invoke(this, ev);
        }

        public void Closed(object obj, EventArgs ev)
        {
            PdfClosed?.Invoke(this, ev);
        }
    }
}
