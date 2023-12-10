namespace E9_Library
{
    partial class Category
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
            SearchCategoryButton = new Button();
            searchCategoryIdTextBox = new TextBox();
            categoryDataGridView = new DataGridView();
            ViewButton = new Button();
            groupBox1 = new GroupBox();
            categoryIdTextBox = new TextBox();
            label3 = new Label();
            categoryNameTextBox = new TextBox();
            DeleteCategoryButton = new Button();
            UpdateCategoryButton = new Button();
            label1 = new Label();
            AddCategoryButton = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)categoryDataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // SearchCategoryButton
            // 
            SearchCategoryButton.Location = new Point(657, 12);
            SearchCategoryButton.Name = "SearchCategoryButton";
            SearchCategoryButton.Size = new Size(117, 36);
            SearchCategoryButton.TabIndex = 12;
            SearchCategoryButton.Text = "Search";
            SearchCategoryButton.UseVisualStyleBackColor = true;
            SearchCategoryButton.Click += SearchCategoryButton_Click;
            // 
            // searchCategoryIdTextBox
            // 
            searchCategoryIdTextBox.Location = new Point(794, 12);
            searchCategoryIdTextBox.Multiline = true;
            searchCategoryIdTextBox.Name = "searchCategoryIdTextBox";
            searchCategoryIdTextBox.Size = new Size(344, 36);
            searchCategoryIdTextBox.TabIndex = 11;
            // 
            // categoryDataGridView
            // 
            categoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            categoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categoryDataGridView.Location = new Point(480, 62);
            categoryDataGridView.Name = "categoryDataGridView";
            categoryDataGridView.RowHeadersWidth = 51;
            categoryDataGridView.Size = new Size(658, 354);
            categoryDataGridView.TabIndex = 10;
            // 
            // ViewButton
            // 
            ViewButton.Location = new Point(480, 10);
            ViewButton.Name = "ViewButton";
            ViewButton.Size = new Size(117, 36);
            ViewButton.TabIndex = 9;
            ViewButton.Text = "View";
            ViewButton.UseVisualStyleBackColor = true;
            ViewButton.Click += ViewButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(categoryIdTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(categoryNameTextBox);
            groupBox1.Controls.Add(DeleteCategoryButton);
            groupBox1.Controls.Add(UpdateCategoryButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(AddCategoryButton);
            groupBox1.Location = new Point(17, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(424, 392);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Category Information";
            // 
            // categoryIdTextBox
            // 
            categoryIdTextBox.Location = new Point(134, 67);
            categoryIdTextBox.Multiline = true;
            categoryIdTextBox.Name = "categoryIdTextBox";
            categoryIdTextBox.Size = new Size(254, 32);
            categoryIdTextBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(6, 67);
            label3.Name = "label3";
            label3.Size = new Size(101, 23);
            label3.TabIndex = 12;
            label3.Text = "Category ID";
            // 
            // categoryNameTextBox
            // 
            categoryNameTextBox.Location = new Point(134, 149);
            categoryNameTextBox.Multiline = true;
            categoryNameTextBox.Name = "categoryNameTextBox";
            categoryNameTextBox.Size = new Size(254, 32);
            categoryNameTextBox.TabIndex = 7;
            // 
            // DeleteCategoryButton
            // 
            DeleteCategoryButton.Location = new Point(283, 235);
            DeleteCategoryButton.Name = "DeleteCategoryButton";
            DeleteCategoryButton.Size = new Size(117, 36);
            DeleteCategoryButton.TabIndex = 11;
            DeleteCategoryButton.Text = "Delete";
            DeleteCategoryButton.UseVisualStyleBackColor = true;
            DeleteCategoryButton.Click += DeleteCategoryButton_Click;
            // 
            // UpdateCategoryButton
            // 
            UpdateCategoryButton.Location = new Point(146, 235);
            UpdateCategoryButton.Name = "UpdateCategoryButton";
            UpdateCategoryButton.Size = new Size(117, 36);
            UpdateCategoryButton.TabIndex = 10;
            UpdateCategoryButton.Text = "Update";
            UpdateCategoryButton.UseVisualStyleBackColor = true;
            UpdateCategoryButton.Click += UpdateCategoryButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(0, 148);
            label1.Name = "label1";
            label1.Size = new Size(130, 23);
            label1.TabIndex = 5;
            label1.Text = "Category Name";
            // 
            // AddCategoryButton
            // 
            AddCategoryButton.Location = new Point(6, 235);
            AddCategoryButton.Name = "AddCategoryButton";
            AddCategoryButton.Size = new Size(117, 36);
            AddCategoryButton.TabIndex = 9;
            AddCategoryButton.Text = "Add";
            AddCategoryButton.UseVisualStyleBackColor = true;
            AddCategoryButton.Click += AddCategoryButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(23, 422);
            button1.Name = "button1";
            button1.Size = new Size(117, 36);
            button1.TabIndex = 9;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Category
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 495);
            Controls.Add(SearchCategoryButton);
            Controls.Add(searchCategoryIdTextBox);
            Controls.Add(categoryDataGridView);
            Controls.Add(ViewButton);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Name = "Category";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category";
            ((System.ComponentModel.ISupportInitialize)categoryDataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchCategoryButton;
        private TextBox searchCategoryIdTextBox;
        private DataGridView categoryDataGridView;
        private Button ViewButton;
        private GroupBox groupBox1;
        private TextBox categoryIdTextBox;
        private Label label3;
        private TextBox categoryNameTextBox;
        private Button DeleteCategoryButton;
        private Button UpdateCategoryButton;
        private Label label1;
        private Button AddCategoryButton;
        private Button button1;
    }
}