namespace Segment_Color_Mappin
{
    partial class ImageCompare
    {
        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        // UI components
        private System.Windows.Forms.Button uploadImageButton1;
        private System.Windows.Forms.Button uploadImageButton2;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button saveTextButton;
        private System.Windows.Forms.RadioButton radioButtonImage1;
        private System.Windows.Forms.RadioButton radioButtonImage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button compressButton;

        // Disposing resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Initializing UI components
        // Initialize the components including the new compressButton
        private void InitializeComponent()
        {
            this.uploadImageButton1 = new System.Windows.Forms.Button();
            this.uploadImageButton2 = new System.Windows.Forms.Button();
            this.compareButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.saveTextButton = new System.Windows.Forms.Button();
            this.compressButton = new System.Windows.Forms.Button(); // New button for compression
            this.radioButtonImage1 = new System.Windows.Forms.RadioButton();
            this.radioButtonImage2 = new System.Windows.Forms.RadioButton();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();

            // 
            // uploadImageButton1
            // 
            this.uploadImageButton1.Location = new System.Drawing.Point(82, 433);
            this.uploadImageButton1.Margin = new System.Windows.Forms.Padding(4);
            this.uploadImageButton1.Name = "uploadImageButton1";
            this.uploadImageButton1.Size = new System.Drawing.Size(200, 62);
            this.uploadImageButton1.TabIndex = 0;
            this.uploadImageButton1.Text = "Upload Image 1";
            this.uploadImageButton1.UseVisualStyleBackColor = true;
            this.uploadImageButton1.Click += new System.EventHandler(this.UploadImageButton1_Click);

            // 
            // uploadImageButton2
            // 
            this.uploadImageButton2.Location = new System.Drawing.Point(351, 433);
            this.uploadImageButton2.Margin = new System.Windows.Forms.Padding(4);
            this.uploadImageButton2.Name = "uploadImageButton2";
            this.uploadImageButton2.Size = new System.Drawing.Size(200, 62);
            this.uploadImageButton2.TabIndex = 1;
            this.uploadImageButton2.Text = "Upload Image 2";
            this.uploadImageButton2.UseVisualStyleBackColor = true;
            this.uploadImageButton2.Click += new System.EventHandler(this.UploadImageButton2_Click);

            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(600, 433);
            this.compareButton.Margin = new System.Windows.Forms.Padding(4);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(200, 62);
            this.compareButton.TabIndex = 2;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.CompareButton_Click);

            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(600, 510); // New button for compression
            this.compressButton.Margin = new System.Windows.Forms.Padding(4);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(200, 62);
            this.compressButton.TabIndex = 10;
            this.compressButton.Text = "Compress Image";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.CompressButton_Click);

            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(600, 642);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(200, 62);
            this.recordButton.TabIndex = 5;
            this.recordButton.Text = "Record Comment";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.RecordButton_Click);

            // 
            // saveTextButton
            // 
            this.saveTextButton.Location = new System.Drawing.Point(600, 550);
            this.saveTextButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveTextButton.Name = "saveTextButton";
            this.saveTextButton.Size = new System.Drawing.Size(200, 62);
            this.saveTextButton.TabIndex = 7;
            this.saveTextButton.Text = "Save Text Comment";
            this.saveTextButton.UseVisualStyleBackColor = true;
            this.saveTextButton.Click += new System.EventHandler(this.SaveTextButton_Click);

            // 
            // radioButtonImage1
            // 
            this.radioButtonImage1.Location = new System.Drawing.Point(82, 520);
            this.radioButtonImage1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonImage1.Name = "radioButtonImage1";
            this.radioButtonImage1.Size = new System.Drawing.Size(200, 62);
            this.radioButtonImage1.TabIndex = 8;
            this.radioButtonImage1.TabStop = true;
            this.radioButtonImage1.Text = "Select Image 1";
            this.radioButtonImage1.UseVisualStyleBackColor = true;

            // 
            // radioButtonImage2
            // 
            this.radioButtonImage2.Location = new System.Drawing.Point(351, 520);
            this.radioButtonImage2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonImage2.Name = "radioButtonImage2";
            this.radioButtonImage2.Size = new System.Drawing.Size(200, 62);
            this.radioButtonImage2.TabIndex = 9;
            this.radioButtonImage2.TabStop = true;
            this.radioButtonImage2.Text = "Select Image 2";
            this.radioButtonImage2.UseVisualStyleBackColor = true;

            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(71, 590);
            this.textBoxComment.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(465, 22);
            this.textBoxComment.TabIndex = 6;

            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(33, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;

            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(333, 31);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 369);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);

            // 
            // ImageCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 752);
            this.Controls.Add(this.radioButtonImage1);
            this.Controls.Add(this.radioButtonImage2);
            this.Controls.Add(this.saveTextButton);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.compressButton); // Adding the new button to the form
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uploadImageButton2);
            this.Controls.Add(this.uploadImageButton1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImageCompare";
            this.Text = "Upload Two Images";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }



    }
}
