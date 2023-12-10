using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mywebapi.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace E9_Library
{
    public partial class Reader : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:7195/api";
        public Reader()
        {
            InitializeComponent();
        }

        private async void ViewButton_Click(object sender, EventArgs e)
        {
            // Call the ViewAllReadersAsync method when the "View" button is clicked
            await ViewAllReadersAsync();
        }

        private async Task ViewAllReadersAsync()
        {
            try
            {
                var readers = await GetReadersAsync();

                if (readers != null)
                {
                    // Set up columns for the DataGridView (assuming Reader has properties named Rid, RName, and RContact)
                    readerDataGridView.Columns.Clear();
                    readerDataGridView.AutoGenerateColumns = false;

                    readerDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Rid",
                        HeaderText = "Reader ID",
                        Width = 70
                    });

                    readerDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "RName",
                        HeaderText = "Reader Name",
                        Width = 150
                    });

                    readerDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "RContact",
                        HeaderText = "Reader Contact",
                        Width = 100
                    });

                    // Set the data source for the DataGridView
                    readerDataGridView.DataSource = readers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Mywebapi.Models.Reader>> GetReadersAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Reader");

                if (response.IsSuccessStatusCode)
                {
                    var readers = await response.Content.ReadFromJsonAsync<List<Mywebapi.Models.Reader>>();
                    return readers;
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve readers. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async Task AddReaderAsync()
        {
            try
            {
                // Retrieve data from text fields
                string name = nameTextBox.Text;
                string contact = contactTextBox.Text;

                // Create a new Reader object
                var newReader = new Mywebapi.Models.Reader
                {
                    RName = name,
                    RContact = contact
                };

                // Call the API to add a new reader
                HttpResponseMessage response = await client.PostAsJsonAsync($"{BaseUrl}/Reader", newReader);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reader added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the DataGridView to show the updated list
                    idTextBox.Text = "";
                    nameTextBox.Text = "";
                    contactTextBox.Text = "";
                    await ViewAllReadersAsync();
                    
                }
                else
                {
                    MessageBox.Show($"Failed to add reader. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            // Call the UpdateReaderAsync method when the "Update" button is clicked
            await UpdateReaderAsync();
        }

        private async Task UpdateReaderAsync()
        {
            try
            {
                // Retrieve user-inputted reader ID
                if (int.TryParse(idTextBox.Text, out int selectedReaderId))
                {
                    // Retrieve updated data from text fields
                    string updatedName = nameTextBox.Text;
                    string updatedContact = contactTextBox.Text;

                    // Create a new Reader object with updated data
                    var updatedReader = new Mywebapi.Models.Reader
                    {
                        Rid = selectedReaderId,
                        RName = updatedName,
                        RContact = updatedContact
                    };

                    // Call the API to update the selected reader
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Reader/{selectedReaderId}", updatedReader);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Reader updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        idTextBox.Text = "";
                        nameTextBox.Text = "";
                        contactTextBox.Text = "";
                        // Refresh the DataGridView to show the updated list
                        await ViewAllReadersAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update reader. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid reader ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            // Call the DeleteReaderAsync method when the "Delete" button is clicked
            await DeleteReaderAsync();
        }

        private async Task DeleteReaderAsync()
        {
            try
            {
                // Retrieve user-inputted reader ID
                if (int.TryParse(idTextBox.Text, out int selectedReaderId))
                {
                    // Confirm the deletion with the user
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this reader?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Call the API to delete the selected reader
                        HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Reader/{selectedReaderId}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Reader deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            idTextBox.Text = "";
                            nameTextBox.Text = "";
                            contactTextBox.Text = "";
                            // Refresh the DataGridView to show the updated list
                            await ViewAllReadersAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete reader. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid reader ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            // Call the SearchReadersAsync method when the "Search" button is clicked
            await SearchReadersAsync();
        }

        private async Task SearchReadersAsync()
        {
            try
            {
                // Retrieve search term from the search TextBox
                if (int.TryParse(searchTextBox.Text, out int searchId))
                {
                    // Call the API to search for readers based on the search ID
                    HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Reader/{searchId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var searchResult = await response.Content.ReadFromJsonAsync<Mywebapi.Models.Reader>();

                        if (searchResult != null)
                        {
                            // Display search result in the DataGridView
                            readerDataGridView.DataSource = new List<Mywebapi.Models.Reader> { searchResult };
                        }
                        else
                        {
                            MessageBox.Show($"No matching reader found for ID: {searchId}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to search for reader by ID. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid reader ID for search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void ButtonAdd_Click(object sender, EventArgs e)
        {
            await AddReaderAsync();
        }
        private  void BtnBack_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            frm.Show();
            this.Close();
        }
    }
}
