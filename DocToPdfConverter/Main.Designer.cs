namespace WinFormsApp1
{
  partial class Main
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      folderBrowserDialog1 = new FolderBrowserDialog();
      btnSelectFolder = new Button();
      textBox1 = new TextBox();
      btnRun = new Button();
      statusLabel = new Label();
      statusStrip1 = new StatusStrip();
      toolStripProgressBar1 = new ToolStripProgressBar();
      lblStatus = new Label();
      lInfo = new Label();
      statusStrip1.SuspendLayout();
      SuspendLayout();
      // 
      // btnSelectFolder
      // 
      btnSelectFolder.Location = new Point(12, 32);
      btnSelectFolder.Name = "btnSelectFolder";
      btnSelectFolder.Size = new Size(142, 23);
      btnSelectFolder.TabIndex = 0;
      btnSelectFolder.Text = "Selecteer folder";
      btnSelectFolder.UseVisualStyleBackColor = true;
      btnSelectFolder.Click += button1_Click;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(12, 61);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(294, 23);
      textBox1.TabIndex = 1;
      // 
      // btnRun
      // 
      btnRun.Location = new Point(160, 32);
      btnRun.Name = "btnRun";
      btnRun.Size = new Size(146, 23);
      btnRun.TabIndex = 2;
      btnRun.Text = "Uitvoeren";
      btnRun.UseVisualStyleBackColor = true;
      btnRun.Click += btnRun_Click;
      // 
      // statusLabel
      // 
      statusLabel.AutoSize = true;
      statusLabel.Location = new Point(12, 66);
      statusLabel.Name = "statusLabel";
      statusLabel.Size = new Size(0, 13);
      statusLabel.TabIndex = 2;
      // 
      // statusStrip1
      // 
      statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
      statusStrip1.Location = new Point(0, 139);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new Size(328, 22);
      statusStrip1.TabIndex = 3;
      statusStrip1.Text = "statusStrip1";
      // 
      // toolStripProgressBar1
      // 
      toolStripProgressBar1.Name = "toolStripProgressBar1";
      toolStripProgressBar1.Size = new Size(300, 16);
      // 
      // lblStatus
      // 
      lblStatus.Dock = DockStyle.Bottom;
      lblStatus.Location = new Point(0, 124);
      lblStatus.Name = "lblStatus";
      lblStatus.Size = new Size(328, 15);
      lblStatus.TabIndex = 4;
      // 
      // lInfo
      // 
      lInfo.AutoSize = true;
      lInfo.Location = new Point(13, 5);
      lInfo.Name = "lInfo";
      lInfo.Size = new Size(222, 15);
      lInfo.TabIndex = 5;
      lInfo.Text = "converteer word documenten naar pdf/a";
      // 
      // Main
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(328, 161);
      Controls.Add(lInfo);
      Controls.Add(lblStatus);
      Controls.Add(statusStrip1);
      Controls.Add(btnRun);
      Controls.Add(textBox1);
      Controls.Add(btnSelectFolder);
      MaximizeBox = false;
      Name = "Main";
      ShowIcon = false;
      SizeGripStyle = SizeGripStyle.Show;
      Text = "Word naar Pdf";
      statusStrip1.ResumeLayout(false);
      statusStrip1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private FolderBrowserDialog folderBrowserDialog1;
    private Button btnSelectFolder;
    private TextBox textBox1;
    private Button btnRun;
    private Label statusLabel;
    private StatusStrip statusStrip1;
    private ToolStripProgressBar toolStripProgressBar1;
    private Label lblStatus;
    private Label lInfo;
  }
}
