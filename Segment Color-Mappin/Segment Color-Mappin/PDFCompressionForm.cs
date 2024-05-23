using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;

namespace Segment_Color_Mappin
{
    public partial class PDFCompressionForm : Form
    {
        public PDFCompressionForm()
        {
            InitializeComponent();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.Title = "Select a PDF file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPDFInput.Text = openFileDialog.FileName;
                }
            }
        }

        private void buttonCompressPDF_Click(object sender, EventArgs e)
        {
            string inputFilePath = textBoxPDFInput.Text; // Get input file path from textBoxPDFInput
            string outputFilePath = textBoxPDFOutput.Text; // Get output file path from textBoxPDFOutput

            if (string.IsNullOrEmpty(inputFilePath) || string.IsNullOrEmpty(outputFilePath))
            {
                MessageBox.Show("Please provide both input and output file paths.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                CreateCompressedPDF(inputFilePath, outputFilePath);
                MessageBox.Show("PDF compressed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error compressing PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  PDF Compression using Entropy Function
        private void CreateCompressedPDF(string inputFilePath, string outputFilePath)
        {
            using (Stream inputPdfStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outputPdfStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (PdfReader pdfReader = new PdfReader(inputPdfStream))
            using (PdfStamper pdfStamper = new PdfStamper(pdfReader, outputPdfStream, PdfWriter.VERSION_1_5))
            {
                pdfStamper.SetFullCompression();
                pdfReader.RemoveUnusedObjects();
                pdfStamper.Writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
            }
        }
    }
}
