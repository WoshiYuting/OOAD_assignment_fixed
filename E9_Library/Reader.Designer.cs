namespace E9_Library
{
    partial class Reader
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
            ViewButton = new Button();
            readerDataGridView = new DataGridView();
            searchTextBox = new TextBox();
            SearchButton = new Button();
            label1 = new Label();
            label2 = new Label();
            nameTextBox = new TextBox();
            groupBox1 = new GroupBox();
            idTextBox = new TextBox();
            label3 = new Label();
            DeleteButton = new Button();
            UpdateButton = new Button();
            ButtonAdd = new Button();
            contactTextBox = new TextBox();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)readerDataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ViewButton
            // 
            ViewButton.Location = new Point(489, 23);
            ViewButton.Name = "ViewButton";
            ViewButton.Size = new Size(117, 36);
            ViewButton.TabIndex = 1;
            ViewButton.Text = "View";
            ViewButton.UseVisualStyleBackColor = true;
            ViewButton.Click += ViewButton_Click;
            // 
            // readerDataGridView
            // 
            readerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            readerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            readerDataGridView.Location = new Point(489, 75);
            readerDataGridView.Name = "readerDataGridView";
            readerDataGridView.RowHeadersWidth = 51;
            readerDataGridView.Size = new Size(658, 354);
            readerDataGridView.TabIndex = 2;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(803, 25);
            searchTextBox.Multiline = true;
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(344, 36);
            searchTextBox.TabIndex = 3;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(666, 25);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(117, 36);
            SearchButton.TabIndex = 4;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(0, 100);
            label1.Name = "label1";
            label1.Size = new Size(114, 23);
            label1.TabIndex = 5;
            label1.Text = "Reader Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(0, 163);
            label2.Name = "label2";
            label2.Size = new Size(128, 23);
            label2.TabIndex = 6;
            label2.Text = "Reader Contact";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(134, 101);
            nameTextBox.Multiline = true;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(254, 32);
            nameTextBox.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(idTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(nameTextBox);
            groupBox1.Controls.Add(DeleteButton);
            groupBox1.Controls.Add(UpdateButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ButtonAdd);
            groupBox1.Controls.Add(contactTextBox);
            groupBox1.Location = new Point(26, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(424, 392);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reader Information";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(134, 45);
            idTextBox.Multiline = true;
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(254, 32);
            idTextBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(6, 47);
            label3.Name = "label3";
            label3.Size = new Size(85, 23);
            label3.TabIndex = 12;
            label3.Text = "Reader ID";
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(283, 235);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(117, 36);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(146, 235);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(117, 36);
            UpdateButton.TabIndex = 10;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Location = new Point(6, 235);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(117, 36);
            ButtonAdd.TabIndex = 9;
            ButtonAdd.Text = "Add";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(134, 164);
            contactTextBox.Multiline = true;
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(254, 32);
            contactTextBox.TabIndex = 9;
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(26, 438);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(117, 36);
            BtnBack.TabIndex = 9;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // Reader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 486);
            Controls.Add(SearchButton);
            Controls.Add(searchTextBox);
            Controls.Add(readerDataGridView);
            Controls.Add(ViewButton);
            Controls.Add(groupBox1);
            Controls.Add(BtnBack);
            Name = "Reader";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reader";
            ((System.ComponentModel.ISupportInitialize)readerDataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ViewButton;
        private DataGridView readerDataGridView;
        private TextBox searchTextBox;
        private Button SearchButton;
        private Label label1;
        private Label label2;
        private TextBox nameTextBox;
        private GroupBox groupBox1;
        private Button ButtonAdd;
        private TextBox contactTextBox;
        private Button DeleteButton;
        private Button UpdateButton;
        private TextBox idTextBox;
        private Label label3;
        private Button BtnBack;
    }
}
