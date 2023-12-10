using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.DataFormats;

namespace E9_Library
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ButtonBook_Click(object sender, EventArgs e)
        {
            // Create an instance of the second form
            // Hide the main form

            // Create an instance of Form1
            Book frmBook = new Book();

            // Show Form1
            frmBook.Show();
            this.Close();
        }

        private void ButtonCategory_Click(object sender, EventArgs e)
        {
            // Create an instance of the second form
            // Hide the main form


            // Create an instance of Form1
            Category frmCategory = new Category();

            // Show Form1
            frmCategory.Show();
            this.Close();
        }

        private void ButtonReader_Click(object sender, EventArgs e)
        {
            // Create an instance of the second form
            Reader frmReader = new Reader();

            // Show the second form
            frmReader.Show();

            // Close the current form (optional)
            this.Close();
        }

        private void ButtonLibrarian_Click(object sender, EventArgs e)
        {
            // Create an instance of the second form
            Librarian frmLibrian = new Librarian();
            // Show the second form
            frmLibrian.Show();
            this.Close();
        }
    }

}
