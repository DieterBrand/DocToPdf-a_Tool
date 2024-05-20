using Microsoft.Office.Interop.Word;
using System;
using System.Diagnostics;
using WinFormsApp1.helper;
using Application = Microsoft.Office.Interop.Word.Application;

namespace WinFormsApp1
{
  internal class DocToPdf
  {
    public static void Main(string inputPath, IProgress<ProgressReport> progress)
    {
      string currentDirectory = inputPath;
      string docDirectory = currentDirectory; // Assuming the DOC/DOCX files are in the startup directory
      string pdfDirectory = Path.Combine(currentDirectory, "pdf");

      progress.Report(new ProgressReport { StatusMessage = "Starting conversion...", PercentComplete = 0 });

      if (!Directory.Exists(pdfDirectory))
      {
        Directory.CreateDirectory(pdfDirectory);
      }
      ConvertDocFilesToPdf(docDirectory, pdfDirectory, progress);     
    }

    static void ConvertDocFilesToPdf(string inputDirectory, string outputDirectory, IProgress<ProgressReport> progress)
    {
      string[] allDocFiles = Directory.GetFiles(inputDirectory)
                                          .Where(f => f.EndsWith(".doc", StringComparison.OrdinalIgnoreCase) ||
                                                      f.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))
                                          .ToArray();

      var count = allDocFiles.Count();
      var i = 1;
      foreach (var file in allDocFiles)
      {        
        string pdfAFile = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".pdf");
        progress.Report(new ProgressReport { StatusMessage = Path.GetFileNameWithoutExtension(file), PercentComplete = (i * 100 / count) });
        ConvertDocxToPdfA(file, pdfAFile);
        i++;
      }
      string statusMessage = count == 0 ? "Klaar: GEEN bestand geconverteerd" : $"Klaar: {count} {(count == 1 ? "bestand" : "bestanden")} geconverteerd";
      progress.Report(new ProgressReport { StatusMessage = statusMessage, PercentComplete = 100 });
    }

    static void ConvertDocxToPdfA(string docxFilePath, string pdfAFilePath)
    {
      // Create a Word application instance
      Application wordApp = new Application();
      Document doc = wordApp.Documents.Open(docxFilePath);

      // Save the document as a temporary PDF file
      string tempPdfFile = Path.GetTempFileName();
      doc.ExportAsFixedFormat(pdfAFilePath, WdExportFormat.wdExportFormatPDF,
                  OpenAfterExport: false, OptimizeFor: WdExportOptimizeFor.wdExportOptimizeForPrint,
                  Range: WdExportRange.wdExportAllDocument, From: 1, To: 1,
                  Item: WdExportItem.wdExportDocumentContent, IncludeDocProps: true,
                  KeepIRM: true, CreateBookmarks: WdExportCreateBookmarks.wdExportCreateWordBookmarks,
                  DocStructureTags: true, BitmapMissingFonts: true, UseISO19005_1: true);

      doc.Close();

    }


  }
}
