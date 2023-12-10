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

namespace E9_Library
{
    public partial class Librarian : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:7195/api";
        public Librarian()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Main frmMain = new Main();
            frmMain.Show();
            this.Close();
        }
        private async void ViewLibrariansButton_Click(object sender, EventArgs e)
        {
            await ViewAllLibrariansAsync();
        }
        private async Task ViewAllLibrariansAsync()
        {
            try
            {
                var librarians = await GetLibrariansAsync();

                if (librarians != null)
                {
                    // Log the number of librarians retrieved (for debugging)
                    Console.WriteLine($"Number of librarians retrieved: {librarians.Count}");

                    librarianDataGridView.Columns.Clear();
                    librarianDataGridView.AutoGenerateColumns = false;

                    librarianDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Lid",
                        HeaderText = "Librarian ID",
                        Width = 70
                    });

                    librarianDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Username",
                        HeaderText = "Librarian Name",
                        Width = 150
                    });

                    librarianDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Password",
                        HeaderText = "Librarian Password",
                        Width = 100
                    });

                    librarianDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Contact",
                        HeaderText = "Librarian Contact",
                        Width = 150
                    });

                    librarianDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Role",
                        HeaderText = "Librarian Role",
                        Width = 100
                    });

                    librarianDataGridView.DataSource = librarians;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Mywebapi.Models.Librarian>> GetLibrariansAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Librarain");

                if (response.IsSuccessStatusCode)
                {
                    var librarians = await response.Content.ReadFromJsonAsync<List<Mywebapi.Models.Librarian>>();
                    return librarians;
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve librarians. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task AddLibrarianAsync()
        {
            try
            {
                string name = UserTextBox.Text;
                string username = UserTextBox.Text;
                string password = PassTextBox.Text;
                string contact = ContactTextBox.Text;
                string role = RoleTextBox.Text;

                var newLibrarian = new
                {
                    Username = username,
                    Password = password,
                    Contact = contact,
                    Role = role
                };
                HttpResponseMessage response = await client.PostAsJsonAsync($"{BaseUrl}/Librarain", newLibrarian);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Librarian added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UserTextBox.Text = "";
                    PassTextBox.Text = "";
                    ContactTextBox.Text = "";
                    RoleTextBox.Text = "";
                    await ViewAllLibrariansAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to add librarian. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void AddLibrarianButton_Click(object sender, EventArgs e)
        {
            await AddLibrarianAsync();
        }
        private async void UpdateLibrarianButton_Click(object sender, EventArgs e)
        {
            await UpdateLibrarianAsync();
        }

        private async Task UpdateLibrarianAsync()
        {
            try
            {
                if (int.TryParse(UserIdTextBox.Text, out int selectedUserId))
                {
                    string username = UserTextBox.Text;
                    string password = PassTextBox.Text;
                    string contact = ContactTextBox.Text;
                    string role = RoleTextBox.Text;

                    var updatedLibrarian = new
                    {
                        Lid = selectedUserId,
                        Username = username,
                        Password = password,
                        Contact = contact,
                        Role = role
                    };
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Librarain/{selectedUserId}", updatedLibrarian);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Librarian updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UserTextBox.Text = "";
                        PassTextBox.Text = "";
                        ContactTextBox.Text = "";
                        RoleTextBox.Text = "";
                        UserIdTextBox.Text = "";
                        await ViewAllLibrariansAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update librarian. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Librarian ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void DeleteLibrarianButton_Click(object sender, EventArgs e)
        {
            await DeleteLibrarianAsync();
        }

        private async Task DeleteLibrarianAsync()
        {
            try
            {
                if (int.TryParse(UserIdTextBox.Text, out int selectedUserId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this librarian?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Librarain/{selectedUserId}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Librarian deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            UserTextBox.Text = "";
                            PassTextBox.Text = "";
                            ContactTextBox.Text = "";
                            RoleTextBox.Text = "";
                            UserIdTextBox.Text = "";
                            await ViewAllLibrariansAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete librarian. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Librarian ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SearchLibrarianButton_Click(object sender, EventArgs e)
        {
            await SearchLibrarianByIdAsync();
        }

        private async Task SearchLibrarianByIdAsync()
        {
            try
            {
                if (int.TryParse(SearchIdTextBox.Text, out int searchUserId))
                {
                    HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Librarain/{searchUserId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var searchResult = await response.Content.ReadFromJsonAsync<Mywebapi.Models.Librarian>();

                        if (searchResult != null)
                        {
                            librarianDataGridView.DataSource = new List<Mywebapi.Models.Librarian> { searchResult };
                        }
                        else
                        {
                            MessageBox.Show($"No matching librarian found for ID: {searchUserId}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to search for librarian by ID. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Librarian ID for search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
