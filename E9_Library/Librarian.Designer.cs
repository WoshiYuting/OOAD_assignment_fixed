namespace E9_Library
{
    partial class Librarian
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
            librarianDataGridView = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            DeleteLibrarianButton = new Button();
            UpdateLibrarianButton = new Button();
            label1 = new Label();
            AddLibrarianButton = new Button();
            SearchLibrarianButton = new Button();
            SearchIdTextBox = new TextBox();
            ViewLibrariansButton = new Button();
            groupBox1 = new GroupBox();
            label5 = new Label();
            RoleTextBox = new TextBox();
            label4 = new Label();
            ContactTextBox = new TextBox();
            UserIdTextBox = new TextBox();
            UserTextBox = new TextBox();
            PassTextBox = new TextBox();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)librarianDataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // librarianDataGridView
            // 
            librarianDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            librarianDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            librarianDataGridView.Location = new Point(466, 73);
            librarianDataGridView.Name = "librarianDataGridView";
            librarianDataGridView.RowHeadersWidth = 51;
            librarianDataGridView.Size = new Size(658, 390);
            librarianDataGridView.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(0, 163);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(6, 47);
            label3.Name = "label3";
            label3.Size = new Size(98, 23);
            label3.TabIndex = 12;
            label3.Text = "Librarian ID";
            // 
            // DeleteLibrarianButton
            // 
            DeleteLibrarianButton.Location = new Point(271, 334);
            DeleteLibrarianButton.Name = "DeleteLibrarianButton";
            DeleteLibrarianButton.Size = new Size(117, 36);
            DeleteLibrarianButton.TabIndex = 11;
            DeleteLibrarianButton.Text = "Delete";
            DeleteLibrarianButton.UseVisualStyleBackColor = true;
            DeleteLibrarianButton.Click += DeleteLibrarianButton_Click;
            // 
            // UpdateLibrarianButton
            // 
            UpdateLibrarianButton.Location = new Point(134, 334);
            UpdateLibrarianButton.Name = "UpdateLibrarianButton";
            UpdateLibrarianButton.Size = new Size(117, 36);
            UpdateLibrarianButton.TabIndex = 10;
            UpdateLibrarianButton.Text = "Update";
            UpdateLibrarianButton.UseVisualStyleBackColor = true;
            UpdateLibrarianButton.Click += UpdateLibrarianButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(0, 100);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 5;
            label1.Text = "UserName";
            // 
            // AddLibrarianButton
            // 
            AddLibrarianButton.Location = new Point(7, 334);
            AddLibrarianButton.Name = "AddLibrarianButton";
            AddLibrarianButton.Size = new Size(117, 36);
            AddLibrarianButton.TabIndex = 9;
            AddLibrarianButton.Text = "Add";
            AddLibrarianButton.UseVisualStyleBackColor = true;
            AddLibrarianButton.Click += AddLibrarianButton_Click;
            // 
            // SearchLibrarianButton
            // 
            SearchLibrarianButton.Location = new Point(643, 23);
            SearchLibrarianButton.Name = "SearchLibrarianButton";
            SearchLibrarianButton.Size = new Size(117, 36);
            SearchLibrarianButton.TabIndex = 12;
            SearchLibrarianButton.Text = "Search";
            SearchLibrarianButton.UseVisualStyleBackColor = true;
            SearchLibrarianButton.Click += SearchLibrarianButton_Click;
            // 
            // SearchIdTextBox
            // 
            SearchIdTextBox.Location = new Point(780, 23);
            SearchIdTextBox.Multiline = true;
            SearchIdTextBox.Name = "SearchIdTextBox";
            SearchIdTextBox.Size = new Size(344, 36);
            SearchIdTextBox.TabIndex = 11;
            // 
            // ViewLibrariansButton
            // 
            ViewLibrariansButton.Location = new Point(466, 21);
            ViewLibrariansButton.Name = "ViewLibrariansButton";
            ViewLibrariansButton.Size = new Size(117, 36);
            ViewLibrariansButton.TabIndex = 9;
            ViewLibrariansButton.Text = "View";
            ViewLibrariansButton.UseVisualStyleBackColor = true;
            ViewLibrariansButton.Click += ViewLibrariansButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(RoleTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(ContactTextBox);
            groupBox1.Controls.Add(UserIdTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(UserTextBox);
            groupBox1.Controls.Add(DeleteLibrarianButton);
            groupBox1.Controls.Add(UpdateLibrarianButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(AddLibrarianButton);
            groupBox1.Controls.Add(PassTextBox);
            groupBox1.Location = new Point(14, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(424, 428);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Librian_Infomation";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(0, 281);
            label5.Name = "label5";
            label5.Size = new Size(43, 23);
            label5.TabIndex = 16;
            label5.Text = "Role";
            // 
            // RoleTextBox
            // 
            RoleTextBox.Location = new Point(134, 282);
            RoleTextBox.Multiline = true;
            RoleTextBox.Name = "RoleTextBox";
            RoleTextBox.Size = new Size(254, 32);
            RoleTextBox.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(0, 226);
            label4.Name = "label4";
            label4.Size = new Size(70, 23);
            label4.TabIndex = 14;
            label4.Text = "Contact";
            // 
            // ContactTextBox
            // 
            ContactTextBox.Location = new Point(134, 227);
            ContactTextBox.Multiline = true;
            ContactTextBox.Name = "ContactTextBox";
            ContactTextBox.Size = new Size(254, 32);
            ContactTextBox.TabIndex = 15;
            // 
            // UserIdTextBox
            // 
            UserIdTextBox.Location = new Point(134, 45);
            UserIdTextBox.Multiline = true;
            UserIdTextBox.Name = "UserIdTextBox";
            UserIdTextBox.Size = new Size(254, 32);
            UserIdTextBox.TabIndex = 13;
            // 
            // UserTextBox
            // 
            UserTextBox.Location = new Point(134, 101);
            UserTextBox.Multiline = true;
            UserTextBox.Name = "UserTextBox";
            UserTextBox.Size = new Size(254, 32);
            UserTextBox.TabIndex = 7;
            // 
            // PassTextBox
            // 
            PassTextBox.Location = new Point(134, 164);
            PassTextBox.Multiline = true;
            PassTextBox.Name = "PassTextBox";
            PassTextBox.Size = new Size(254, 32);
            PassTextBox.TabIndex = 9;
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(14, 467);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(117, 36);
            BtnBack.TabIndex = 9;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // Librarian
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 520);
            Controls.Add(librarianDataGridView);
            Controls.Add(SearchLibrarianButton);
            Controls.Add(SearchIdTextBox);
            Controls.Add(ViewLibrariansButton);
            Controls.Add(groupBox1);
            Controls.Add(BtnBack);
            Name = "Librarian";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Librarain";
            ((System.ComponentModel.ISupportInitialize)librarianDataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private DataGridView librarianDataGridView;
        private Label label2;
        private Label label3;
        private Button DeleteLibrarianButton;
        private Button UpdateLibrarianButton;
        private Label label1;
        private Button AddLibrarianButton;
        private Button SearchLibrarianButton;
        private TextBox SearchIdTextBox;
        private Button ViewLibrariansButton;
        private GroupBox groupBox1;
        private TextBox UserIdTextBox;
        private TextBox UserTextBox;
        private TextBox PassTextBox;
        private Label label5;
        private TextBox RoleTextBox;
        private Label label4;
        private TextBox ContactTextBox;
        private Button BtnBack;
    }
}