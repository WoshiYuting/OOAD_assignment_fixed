namespace E9_Library
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonBook = new Button();
            ButtonCategory = new Button();
            ButtonReader = new Button();
            ButtonLibrarian = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // ButtonBook
            // 
            ButtonBook.BackColor = SystemColors.Info;
            ButtonBook.ForeColor = SystemColors.InfoText;
            ButtonBook.Location = new Point(96, 171);
            ButtonBook.Name = "ButtonBook";
            ButtonBook.Size = new Size(117, 181);
            ButtonBook.TabIndex = 10;
            ButtonBook.Text = "Book";
            ButtonBook.UseVisualStyleBackColor = false;
            ButtonBook.Click += ButtonBook_Click;
            // 
            // ButtonCategory
            // 
            ButtonCategory.BackColor = SystemColors.ActiveCaption;
            ButtonCategory.Location = new Point(282, 171);
            ButtonCategory.Name = "ButtonCategory";
            ButtonCategory.Size = new Size(117, 181);
            ButtonCategory.TabIndex = 10;
            ButtonCategory.Text = "Category";
            ButtonCategory.UseVisualStyleBackColor = false;
            ButtonCategory.Click += ButtonCategory_Click;
            // 
            // ButtonReader
            // 
            ButtonReader.BackColor = SystemColors.MenuHighlight;
            ButtonReader.Location = new Point(461, 171);
            ButtonReader.Name = "ButtonReader";
            ButtonReader.Size = new Size(117, 181);
            ButtonReader.TabIndex = 10;
            ButtonReader.Text = "Reader";
            ButtonReader.UseVisualStyleBackColor = false;
            ButtonReader.Click += ButtonReader_Click;
            // 
            // ButtonLibrarian
            // 
            ButtonLibrarian.BackColor = SystemColors.ScrollBar;
            ButtonLibrarian.Location = new Point(652, 171);
            ButtonLibrarian.Name = "ButtonLibrarian";
            ButtonLibrarian.Size = new Size(117, 181);
            ButtonLibrarian.TabIndex = 10;
            ButtonLibrarian.Text = "Librarian";
            ButtonLibrarian.UseVisualStyleBackColor = false;
            ButtonLibrarian.Click += ButtonLibrarian_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 32F);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(251, 49);
            label1.Name = "label1";
            label1.Size = new Size(398, 72);
            label1.TabIndex = 11;
            label1.Text = "Library Systems";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 505);
            Controls.Add(label1);
            Controls.Add(ButtonLibrarian);
            Controls.Add(ButtonReader);
            Controls.Add(ButtonCategory);
            Controls.Add(ButtonBook);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonBook;
        private Button ButtonCategory;
        private Button ButtonReader;
        private Button ButtonLibrarian;
        private Label label1;
    }
}