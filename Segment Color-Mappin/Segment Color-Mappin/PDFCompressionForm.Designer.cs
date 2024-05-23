namespace Segment_Color_Mappin
{
    partial class PDFCompressionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonCompressPDF;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.TextBox textBoxPDFInput;
        private System.Windows.Forms.TextBox textBoxPDFOutput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonCompressPDF = new System.Windows.Forms.Button();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.textBoxPDFInput = new System.Windows.Forms.TextBox();
            this.textBoxPDFOutput = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCompressPDF
            // 
            this.buttonCompressPDF.Location = new System.Drawing.Point(567, 150);
            this.buttonCompressPDF.Name = "buttonCompressPDF";
            this.buttonCompressPDF.Size = new System.Drawing.Size(150, 23);
            this.buttonCompressPDF.TabIndex = 0;
            this.buttonCompressPDF.Text = "Compress PDF";
            this.buttonCompressPDF.UseVisualStyleBackColor = true;
            this.buttonCompressPDF.Click += new System.EventHandler(this.buttonCompressPDF_Click);
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(567, 50);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(150, 23);
            this.buttonChooseFile.TabIndex = 1;
            this.buttonChooseFile.Text = "Choose File";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // textBoxPDFInput
            // 
            this.textBoxPDFInput.Location = new System.Drawing.Point(150, 50);
            this.textBoxPDFInput.Name = "textBoxPDFInput";
            this.textBoxPDFInput.Size = new System.Drawing.Size(400, 22);
            this.textBoxPDFInput.TabIndex = 2;
            // 
            // textBoxPDFOutput
            // 
            this.textBoxPDFOutput.Location = new System.Drawing.Point(150, 100);
            this.textBoxPDFOutput.Name = "textBoxPDFOutput";
            this.textBoxPDFOutput.Size = new System.Drawing.Size(400, 22);
            this.textBoxPDFOutput.TabIndex = 3;
            // 
            // labelInput
            // 
            this.labelInput.Location = new System.Drawing.Point(50, 50);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(100, 23);
            this.labelInput.TabIndex = 4;
            this.labelInput.Text = "Input PDF Path";
            // 
            // labelOutput
            // 
            this.labelOutput.Location = new System.Drawing.Point(50, 100);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(100, 23);
            this.labelOutput.TabIndex = 5;
            this.labelOutput.Text = "Output PDF Path";
            // 
            // PDFCompressionForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.textBoxPDFOutput);
            this.Controls.Add(this.textBoxPDFInput);
            this.Controls.Add(this.buttonChooseFile);
            this.Controls.Add(this.buttonCompressPDF);
            this.Name = "PDFCompressionForm";
            this.Text = "PDF Compression";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
