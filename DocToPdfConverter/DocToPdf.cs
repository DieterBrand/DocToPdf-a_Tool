using Microsoft.Office.Interop.Word;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
            try
            {
                ConvertDocFilesToPdf(docDirectory, pdfDirectory, progress);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Conversion completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void ConvertDocFilesToPdf(string inputDirectory, string outputDirectory, IProgress<ProgressReport> progress)
        {
        string[] allDocFiles = Directory.GetFiles(inputDirectory)
                                          .Where(f => f.EndsWith(".doc", StringComparison.OrdinalIgnoreCase) ||
                                                      f.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))
                                          .ToArray();
            var count = allDocFiles.Count();
            Application wordApp = new Application();
            try
            {
             
                  var i = 1;
                  foreach (var file in allDocFiles)
                  {        
                    string pdfAFile = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".pdf");
                    progress.Report(new ProgressReport { StatusMessage = Path.GetFileNameWithoutExtension(file), PercentComplete = (i * 100 / count) });
                    ConvertDocxToPdfA(wordApp, file, pdfAFile);
                    i++;
                  }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during document conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit();
                Marshal.ReleaseComObject(wordApp);                
            }
            string statusMessage = count == 0 ? "Klaar: GEEN bestand geconverteerd" : $"Klaar: {count} {(count == 1 ? "bestand" : "bestanden")} geconverteerd";
            progress.Report(new ProgressReport { StatusMessage = statusMessage, PercentComplete = 100 });
        }

        static void ConvertDocxToPdfA(Application wordApp, string docxFilePath, string pdfAFilePath)
        {
            Document? doc = null;
            try
            {
                doc = wordApp.Documents.Open(docxFilePath);
                    // Save the document as a temporary PDF file
                    string tempPdfFile = Path.GetTempFileName();
                    doc.ExportAsFixedFormat(pdfAFilePath, WdExportFormat.wdExportFormatPDF,
                                OpenAfterExport: false, OptimizeFor: WdExportOptimizeFor.wdExportOptimizeForPrint,
                                Range: WdExportRange.wdExportAllDocument, From: 1, To: 1,
                                Item: WdExportItem.wdExportDocumentContent, IncludeDocProps: true,
                                KeepIRM: true, CreateBookmarks: WdExportCreateBookmarks.wdExportCreateWordBookmarks,
                                DocStructureTags: true, BitmapMissingFonts: true, UseISO19005_1: true);
            }
            catch (COMException comEx)
            {
                MessageBox.Show($"COM error occurred while converting {docxFilePath}: {comEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while converting {docxFilePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(false);
                    Marshal.ReleaseComObject(doc);
                }
            }
        }


  }
}
