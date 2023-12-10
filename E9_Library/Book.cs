using Mywebapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace E9_Library
{
    public partial class Book : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:7195/api";

        public Book()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Main frmMain= new Main();
            frmMain.Show();
            this.Close();
        }
        private async void ViewBooksButton_Click(object sender, EventArgs e)
        {
            await ViewAllBooksAsync();
        }
        private async Task ViewAllBooksAsync()
        {
            try
            {
                var books = await GetBooksAsync();

                if (books != null)
                {
                    // Set up columns for the DataGridView (assuming Book has properties named BookId, Title, and Author)
                    bookDataGridView.Columns.Clear();
                    bookDataGridView.AutoGenerateColumns = false;

                    bookDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "IBook",
                        HeaderText = "Book ID",
                        Width = 70
                    });

                    bookDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Title",
                        HeaderText = "Title",
                        Width = 150
                    });

                    bookDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Author",
                        HeaderText = "Author",
                        Width = 100
                    });
                    bookDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "CategoryId",
                        HeaderText = "Category ID",
                        Width = 50
                    });
                    // Set the data source for the DataGridView
                    bookDataGridView.DataSource = books;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Mywebapi.Models.Book>> GetBooksAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Book");

                if (response.IsSuccessStatusCode)
                {
                    var books = await response.Content.ReadFromJsonAsync<List<Mywebapi.Models.Book>>();
                    return books;
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve books. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async void AddBookButton_Click(object sender, EventArgs e)
        {
            await AddBookAsync();
        }

        private async Task AddBookAsync()
        {
            try
            {
                // Assuming you have TextBox controls for title, author, and categoryId
                string title = titleTextBox.Text;
                string author = authorTextBox.Text;

                if (!int.TryParse(categoryIdTextBox.Text, out int categoryId))
                {
                    MessageBox.Show("Invalid category ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newBook = new
                {
                    Title = title,
                    Author = author,
                    CategoryId = categoryId,
                    Category = new
                    {
                        CategoryId = categoryId,
                        CategoryName = "DummyCategory"
                    }
                };

                HttpResponseMessage response = await client.PostAsJsonAsync($"{BaseUrl}/Book/{categoryId}", newBook);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optionally, you can refresh the DataGridView to show the updated list
                    await ViewAllBooksAsync();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to add book. Status code: {response.StatusCode}, Error: {errorContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void UpdateBookButton_Click(object sender, EventArgs e)
        {
            await UpdateBookAsync();
        }

        private async Task UpdateBookAsync()
        {
            try
            {
                // Retrieve user-inputted book ID
                if (int.TryParse(bookIdTextBox.Text, out int selectedBookId))
                {
                    // Retrieve updated data from text fields
                    string updatedTitle = titleTextBox.Text;
                    string updatedAuthor = authorTextBox.Text;
                    string updatedCategoryId = categoryIdTextBox.Text;

                    // Create a new Book object with updated data
                    var updatedBook = new 
                    {
                        IBook=selectedBookId,
                        Title =updatedTitle ,
                        Author = updatedAuthor,
                        CategoryId = updatedCategoryId,
                        Category = new
                        {
                            CategoryId = updatedCategoryId,
                            CategoryName = "DummyCategory"
                        }
                    };

                    // Call the API to update the selected book
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Book/{selectedBookId}", updatedBook);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bookIdTextBox.Text = "";
                        titleTextBox.Text = "";
                        authorTextBox.Text = "";
                        // Refresh the DataGridView to show the updated list
                        await ViewAllBooksAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update book. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid book ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void DeleteBookButton_Click(object sender, EventArgs e)
        {
            await DeleteBookAsync();
        }

        private async Task DeleteBookAsync()
        {
            try
            {
                // Retrieve user-inputted book ID
                if (int.TryParse(bookIdTextBox.Text, out int selectedBookId))
                {
                    // Confirm the deletion with the user
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Call the API to delete the selected book
                        HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Book/{selectedBookId}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bookIdTextBox.Text = "";
                            titleTextBox.Text = "";
                            authorTextBox.Text = "";
                            // Refresh the DataGridView to show the updated list
                            await ViewAllBooksAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete book. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid book ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SearchBookButton_Click(object sender, EventArgs e)
        {
            await SearchBooksAsync();
        }

        private async Task SearchBooksAsync()
        {
            try
            {
                // Retrieve search term from the search TextBox
                if (int.TryParse(Searchbox.Text, out int searchBookId))
                {
                    // Call the API to search for books based on the search ID
                    HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Book/{searchBookId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var searchResult = await response.Content.ReadFromJsonAsync<Mywebapi.Models.Book>();

                        if (searchResult != null)
                        {
                            // Display search result in the DataGridView
                            bookDataGridView.DataSource = new List<Mywebapi.Models.Book> { searchResult };
                        }
                        else
                        {
                            MessageBox.Show($"No matching book found for ID: {searchBookId}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to search for book by ID. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid book ID for search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
