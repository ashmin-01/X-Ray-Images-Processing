namespace Segment_Color_Mappin
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Label labelMinSize;
        private System.Windows.Forms.Label labelMaxSize;
        private System.Windows.Forms.TextBox textBoxMinSize;
        private System.Windows.Forms.TextBox textBoxMaxSize;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;

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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.labelMinSize = new System.Windows.Forms.Label();
            this.labelMaxSize = new System.Windows.Forms.Label();
            this.textBoxMinSize = new System.Windows.Forms.TextBox();
            this.textBoxMaxSize = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(562, 387);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(139, 33);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(615, 22);
            this.textBoxSearch.TabIndex = 1;
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 16;
            this.listBoxResults.Location = new System.Drawing.Point(50, 170);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(704, 196);
            this.listBoxResults.TabIndex = 2;
            // 
            // labelMinSize
            // 
            this.labelMinSize.Location = new System.Drawing.Point(47, 75);
            this.labelMinSize.Name = "labelMinSize";
            this.labelMinSize.Size = new System.Drawing.Size(100, 23);
            this.labelMinSize.TabIndex = 3;
            this.labelMinSize.Text = "Min Size (KB)";
            // 
            // labelMaxSize
            // 
            this.labelMaxSize.Location = new System.Drawing.Point(382, 75);
            this.labelMaxSize.Name = "labelMaxSize";
            this.labelMaxSize.Size = new System.Drawing.Size(100, 23);
            this.labelMaxSize.TabIndex = 4;
            this.labelMaxSize.Text = "Max Size (KB)";
            // 
            // textBoxMinSize
            // 
            this.textBoxMinSize.Location = new System.Drawing.Point(139, 76);
            this.textBoxMinSize.Name = "textBoxMinSize";
            this.textBoxMinSize.Size = new System.Drawing.Size(227, 22);
            this.textBoxMinSize.TabIndex = 5;
            // 
            // textBoxMaxSize
            // 
            this.textBoxMaxSize.Location = new System.Drawing.Point(488, 72);
            this.textBoxMaxSize.Name = "textBoxMaxSize";
            this.textBoxMaxSize.Size = new System.Drawing.Size(266, 22);
            this.textBoxMaxSize.TabIndex = 6;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Location = new System.Drawing.Point(47, 120);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(100, 23);
            this.labelStartDate.TabIndex = 7;
            this.labelStartDate.Text = "Start Date";
            // 
            // labelEndDate
            // 
            this.labelEndDate.Location = new System.Drawing.Point(399, 116);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(68, 23);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(119, 116);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(247, 22);
            this.dateTimePickerStartDate.TabIndex = 9;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(488, 115);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(266, 22);
            this.dateTimePickerEndDate.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "file name: ";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.textBoxMaxSize);
            this.Controls.Add(this.textBoxMinSize);
            this.Controls.Add(this.labelMaxSize);
            this.Controls.Add(this.labelMinSize);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}
