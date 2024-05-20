using WinFormsApp1.helper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {
        textBox1.Text = folderBrowserDialog1.SelectedPath;
      }
    }

    private async void btnRun_Click(object sender, EventArgs e)
    {
      string inputPath = textBox1.Text;
      // Progress object to update the UI
      var progress = new Progress<ProgressReport>(report =>
      {
        // This code runs on the UI thread
        lblStatus.Text = report.StatusMessage; 
        toolStripProgressBar1.Value = report.PercentComplete;
      });

      // Run the conversion in a background task
      await Task.Run(() => DocToPdf.Main(inputPath, progress));
    }
  }
}
