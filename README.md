# PdfLibrary
Library that relies upon PDFium SDK for managing PDF documents

## PdfManager ##
Class that exposes methods to manage PDF documents

### SendPdfToPrinter ###
Send an PDF to the printer.  Accepts the FQPN to the PDF file and the name of the printer to which it should be sent.

### Printed ###
Returns the status of printing the PDF.

### Unloaded ###
Returns the status of unloading a PDF.

### Closed ###
Returns the status of closing a PDF.
