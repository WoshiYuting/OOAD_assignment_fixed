namespace E9_Library
{
    partial class Book
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
            SearchBookButton = new Button();
            Searchbox = new TextBox();
            bookDataGridView = new DataGridView();
            ViewBooksButton = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            categoryIdTextBox = new TextBox();
            bookIdTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            titleTextBox = new TextBox();
            DeleteBookButton = new Button();
            UpdateBookButton = new Button();
            label1 = new Label();
            AddBookButton = new Button();
            authorTextBox = new TextBox();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)bookDataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // SearchBookButton
            // 
            SearchBookButton.Location = new Point(684, 16);
            SearchBookButton.Name = "SearchBookButton";
            SearchBookButton.Size = new Size(117, 36);
            SearchBookButton.TabIndex = 12;
            SearchBookButton.Text = "Search";
            SearchBookButton.UseVisualStyleBackColor = true;
            SearchBookButton.Click += SearchBookButton_Click;
            // 
            // Searchbox
            // 
            Searchbox.Location = new Point(821, 16);
            Searchbox.Multiline = true;
            Searchbox.Name = "Searchbox";
            Searchbox.Size = new Size(344, 36);
            Searchbox.TabIndex = 11;
            // 
            // bookDataGridView
            // 
            bookDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bookDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookDataGridView.Location = new Point(507, 66);
            bookDataGridView.Name = "bookDataGridView";
            bookDataGridView.RowHeadersWidth = 51;
            bookDataGridView.Size = new Size(658, 354);
            bookDataGridView.TabIndex = 10;
            // 
            // ViewBooksButton
            // 
            ViewBooksButton.Location = new Point(507, 14);
            ViewBooksButton.Name = "ViewBooksButton";
            ViewBooksButton.Size = new Size(117, 36);
            ViewBooksButton.TabIndex = 9;
            ViewBooksButton.Text = "View";
            ViewBooksButton.UseVisualStyleBackColor = true;
            ViewBooksButton.Click += ViewBooksButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(categoryIdTextBox);
            groupBox1.Controls.Add(bookIdTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(titleTextBox);
            groupBox1.Controls.Add(DeleteBookButton);
            groupBox1.Controls.Add(UpdateBookButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(AddBookButton);
            groupBox1.Controls.Add(authorTextBox);
            groupBox1.Location = new Point(46, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(422, 392);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Book Information";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(12, 226);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 14;
            label4.Text = "Category ID";
            // 
            // categoryIdTextBox
            // 
            categoryIdTextBox.Location = new Point(146, 227);
            categoryIdTextBox.Multiline = true;
            categoryIdTextBox.Name = "categoryIdTextBox";
            categoryIdTextBox.Size = new Size(254, 32);
            categoryIdTextBox.TabIndex = 15;
            // 
            // bookIdTextBox
            // 
            bookIdTextBox.Location = new Point(146, 45);
            bookIdTextBox.Multiline = true;
            bookIdTextBox.Name = "bookIdTextBox";
            bookIdTextBox.Size = new Size(254, 32);
            bookIdTextBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(12, 163);
            label2.Name = "label2";
            label2.Size = new Size(106, 23);
            label2.TabIndex = 6;
            label2.Text = "Book Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(18, 47);
            label3.Name = "label3";
            label3.Size = new Size(70, 23);
            label3.TabIndex = 12;
            label3.Text = "Book ID";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(146, 101);
            titleTextBox.Multiline = true;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(254, 32);
            titleTextBox.TabIndex = 7;
            // 
            // DeleteBookButton
            // 
            DeleteBookButton.Location = new Point(283, 300);
            DeleteBookButton.Name = "DeleteBookButton";
            DeleteBookButton.Size = new Size(117, 36);
            DeleteBookButton.TabIndex = 11;
            DeleteBookButton.Text = "Delete";
            DeleteBookButton.UseVisualStyleBackColor = true;
            DeleteBookButton.Click += DeleteBookButton_Click;
            // 
            // UpdateBookButton
            // 
            UpdateBookButton.Location = new Point(146, 300);
            UpdateBookButton.Name = "UpdateBookButton";
            UpdateBookButton.Size = new Size(117, 36);
            UpdateBookButton.TabIndex = 10;
            UpdateBookButton.Text = "Update";
            UpdateBookButton.UseVisualStyleBackColor = true;
            UpdateBookButton.Click += UpdateBookButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 100);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 5;
            label1.Text = "Book Title";
            // 
            // AddBookButton
            // 
            AddBookButton.Location = new Point(6, 300);
            AddBookButton.Name = "AddBookButton";
            AddBookButton.Size = new Size(117, 36);
            AddBookButton.TabIndex = 9;
            AddBookButton.Text = "Add";
            AddBookButton.UseVisualStyleBackColor = true;
            AddBookButton.Click += AddBookButton_Click;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(146, 164);
            authorTextBox.Multiline = true;
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(254, 32);
            authorTextBox.TabIndex = 9;
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(47, 426);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(117, 36);
            BtnBack.TabIndex = 9;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // Book
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 486);
            Controls.Add(SearchBookButton);
            Controls.Add(Searchbox);
            Controls.Add(bookDataGridView);
            Controls.Add(ViewBooksButton);
            Controls.Add(groupBox1);
            Controls.Add(BtnBack);
            Name = "Book";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book";
            ((System.ComponentModel.ISupportInitialize)bookDataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchBookButton;
        private TextBox Searchbox;
        private DataGridView bookDataGridView;
        private Button ViewBooksButton;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox categoryIdTextBox;
        private TextBox bookIdTextBox;
        private Label label2;
        private Label label3;
        private TextBox titleTextBox;
        private Button DeleteBookButton;
        private Button UpdateBookButton;
        private Label label1;
        private Button AddBookButton;
        private TextBox authorTextBox;
        private Button BtnBack;
    }
}