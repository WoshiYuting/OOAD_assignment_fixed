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
    public partial class Category : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:7195/api";
        public Category()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            frm.Show();
            this.Close();
        }
        private async void ViewButton_Click(object sender, EventArgs e)
        {
            // Call the ViewAllCategoriesAsync method when the "View" button is clicked
            await ViewAllCategoriesAsync();
        }
        private async Task ViewAllCategoriesAsync()
        {
            try
            {
                var categories = await GetCategoriesAsync();

                if (categories != null)
                {
                    // Set up columns for the DataGridView (assuming Category has properties named CatId and CatName)
                    categoryDataGridView.Columns.Clear();
                    categoryDataGridView.AutoGenerateColumns = false;

                    categoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "CategoryId",
                        HeaderText = "Category ID",
                        Width = 70
                    });

                    categoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "CategoryName",
                        HeaderText = "Category Name",
                        Width = 150
                    });

                    // Set the data source for the DataGridView
                    categoryDataGridView.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<List<Mywebapi.Models.Category>> GetCategoriesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Category");

                if (response.IsSuccessStatusCode)
                {
                    var categories = await response.Content.ReadFromJsonAsync<List<Mywebapi.Models.Category>>();
                    return categories;
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve categories. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task AddCategoryAsync()
        {
            try
            {
                // Retrieve data from text fields
                string categoryName = categoryNameTextBox.Text;

                // Create a new Category object
                var newCategory = new Mywebapi.Models.Category
                {
                    CategoryName = categoryName
                };

                // Call the API to add a new category
                HttpResponseMessage response = await client.PostAsJsonAsync($"{BaseUrl}/Category", newCategory);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the DataGridView to show the updated list
                    categoryIdTextBox.Text = "";
                    categoryNameTextBox.Text = "";
                    await ViewAllCategoriesAsync();
                }
                else
                {
                    MessageBox.Show($"Failed to add category. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void AddCategoryButton_Click(object sender, EventArgs e)
        {
            // Call the AddCategoryAsync method when the "Add Category" button is clicked
            await AddCategoryAsync();
        }

        // You can implement similar methods for update, delete, and search functionality

        private async void SearchCategoryButton_Click(object sender, EventArgs e)
        {
            // Call the SearchCategoriesAsync method when the "Search" button is clicked
            await SearchCategoriesAsync();
        }

        private async Task SearchCategoriesAsync()
        {
            try
            {
                // Retrieve search term from the search TextBox
                if (int.TryParse(searchCategoryIdTextBox.Text, out int searchCategoryId))
                {
                    // Call the API to search for categories based on the search ID
                    HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Category/{searchCategoryId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var searchResult = await response.Content.ReadFromJsonAsync<Mywebapi.Models.Category>();

                        if (searchResult != null)
                        {
                            // Display search result in the DataGridView
                            categoryDataGridView.DataSource = new List<Mywebapi.Models.Category> { searchResult };
                        }
                        else
                        {
                            MessageBox.Show($"No matching category found for ID: {searchCategoryId}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to search for category by ID. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid category ID for search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void UpdateCategoryButton_Click(object sender, EventArgs e)
        {
            // Call the UpdateCategoryAsync method when the "Update Category" button is clicked
            await UpdateCategoryAsync();
        }
        private async Task UpdateCategoryAsync()
        {
            try
            {
                // Retrieve user-inputted category ID
                if (int.TryParse(categoryIdTextBox.Text, out int selectedCategoryId))
                {
                    // Retrieve updated data from text fields
                    string updatedCategoryName = categoryNameTextBox.Text;

                    // Create a new Category object with updated data
                    var updatedCategory = new Mywebapi.Models.Category
                    {
                        CategoryId = selectedCategoryId,
                        CategoryName = updatedCategoryName
                    };

                    // Call the API to update the selected category
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Category/{selectedCategoryId}", updatedCategory);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear text fields
                        categoryIdTextBox.Text = "";
                        categoryNameTextBox.Text = "";

                        // Refresh the DataGridView to show the updated list
                        await ViewAllCategoriesAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update category. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid category ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            // Call the DeleteCategoryAsync method when the "Delete Category" button is clicked
            await DeleteCategoryAsync();
        }

        private async Task DeleteCategoryAsync()
        {
            try
            {
                // Retrieve user-inputted category ID
                if (int.TryParse(categoryIdTextBox.Text, out int selectedCategoryId))
                {
                    // Confirm the deletion with the user
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Call the API to delete the selected category
                        HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Category/{selectedCategoryId}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear text field
                            categoryIdTextBox.Text = "";

                            // Refresh the DataGridView to show the updated list
                            await ViewAllCategoriesAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete category. Status code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid category ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
