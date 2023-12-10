using Mywebapi.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net; // Add this for List<T>

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string BaseUrl = "https://localhost:7195/api";

    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for login:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Reader");
            Console.WriteLine("3. Category");
            Console.WriteLine("4. Librarian");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ManageBooksAsync();
                    break;

                case "2":
                    await ManageReadersAsync();
                    break;

                case "3":
                    await ManageCategoriesAsync();
                    break;

                case "4":
                    await ManageLibrariansAsync();
                    break;

                case "0":
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ManageBooksAsync()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Books:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("0. Go back");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddBookAsync();
                    break;

                case "2":
                    await ViewAllBooksAsync();
                    break;

                case "3":
                    await UpdateBookAsync();
                    break;

                case "4":
                    await DeleteBookAsync();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ManageReadersAsync()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Readers:");
            Console.WriteLine("1. Add Reader");
            Console.WriteLine("2. View All Readers");
            Console.WriteLine("3. Update Reader");
            Console.WriteLine("4. Delete Reader");
            Console.WriteLine("0. Go back");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddReaderAsync();
                    break;

                case "2":
                    await ViewAllReadersAsync();
                    break;

                case "3":
                    await UpdateReaderAsync();
                    break;

                case "4":
                    await DeleteReaderAsync();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ManageCategoriesAsync()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Categories:");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. View All Categories");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Categroy");
            Console.WriteLine("0. Go back");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddCategoryAsync();
                    break;

                case "2":
                    await ViewAllCategoriesAsync();
                    break;

                case "3":
                    await UpdateCategoryAsync();
                    break;

                case "4":
                    await DeleteCategoryAsync();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task ManageLibrariansAsync()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Librarians:");
            Console.WriteLine("1. Add Librarian");
            Console.WriteLine("2. View All Librarians");
            Console.WriteLine("3. Update Librarian");
            Console.WriteLine("4. Delete Librarian");
            Console.WriteLine("0. Go back");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddLibrarianAsync();
                    break;

                case "2":
                    await ViewAllLibrariansAsync();
                    break;

                case "3":
                    await UpdateLibrarianAsync();
                    break;

                case "4":
                    await DeleteLibrarianAsync();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static async Task AddBookAsync()
    {
        try
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID");
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
                Console.WriteLine("Book added successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add book. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static async Task<List<Book>> GetBooksAsync()
    {
        HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Book");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Book>>();
        }
        else
        {
            Console.WriteLine($"Failed to retrieve books. Status code: {response.StatusCode}");
            return null;
        }
    }
    static async Task ViewAllBooksAsync()
    {
        var books = await GetBooksAsync();
        Console.WriteLine("Books retrieved from the API:");
        foreach (var book in books)
        {
            Console.WriteLine($"Book_Id: {book.IBook},Title: {book.Title}, Author: {book.Author} ,CategoryId: {book.CategoryId}");
        }
    }
    static async Task UpdateBookAsync()
    {
        try
        {
            Console.Write("Enter the ID of the book you want to update: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid book ID");
                return;
            }

            Console.Write("Enter new book title: ");
            string newTitle = Console.ReadLine();

            Console.Write("Enter new book author: ");
            string newAuthor = Console.ReadLine();

            Console.Write("Enter new category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newCategoryId))
            {
                Console.WriteLine("Invalid category ID");
                return;
            }
            var updatedBook = new
            {
                IBook = bookId,
                Title = newTitle,
                Author = newAuthor,
                CategoryId = newCategoryId,
                Category = new
                {
                    CategoryId = newCategoryId,
                    CategoryName = "DummyCategory" // You may want to fetch the actual category details from the API
                }
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Book/{bookId}", updatedBook);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to update book. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static async Task DeleteBookAsync()
    {
        try
        {
            Console.Write("Enter the ID of the book you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.WriteLine("Invalid book ID");
                return;
            }

            HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Book/{bookId}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to delete book. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task AddReaderAsync()
    {
        Console.Write("Enter reader name: ");
        string name = Console.ReadLine();

        Console.Write("Enter reader contact: ");
        string contact = Console.ReadLine();

        var newReader = new
        {
            RName = name,
            RContact = contact
        };

        await PostDataAsync("Reader", newReader);
    }
    static async Task<List<Reader>> GetReadersAsync()
    {
        HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Reader");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Reader>>();
        }
        else
        {
            Console.WriteLine($"Failed to retrieve readers. Status code: {response.StatusCode}");
            return null;
        }
    }
    static async Task ViewAllReadersAsync()
    {
        var readers = await GetReadersAsync();
        Console.WriteLine("Readers retrieved from the API:");
        foreach (var reader in readers)
        {
            Console.WriteLine($"Reader_Id: {reader.Rid},Name: {reader.RName}, Contact: {reader.RContact}");
        }
    }
    static async Task UpdateReaderAsync()
    {
        try
        {
            Console.Write("Enter the ID of the reader you want to update: ");
            if (!int.TryParse(Console.ReadLine(), out int readerId))
            {
                Console.WriteLine("Invalid reader ID");
                return;
            }

            Console.Write("Enter the new name for the reader: ");
            string newName = Console.ReadLine();

            Console.Write("Enter the new contact for the reader: ");
            string newContact = Console.ReadLine();

            var updatedReader = new
            {
                Rid=readerId,
                RName = newName,
                RContact = newContact
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Reader/{readerId}", updatedReader);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Reader updated successfully!");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Failed to update reader. Bad request. Please check the provided data.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to update reader. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task DeleteReaderAsync()
    {
        try
        {
            Console.Write("Enter the ID of the reader you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int readerId))
            {
                Console.WriteLine("Invalid reader ID");
                return;
            }

            HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Reader/{readerId}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Reader deleted successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to delete reader. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }


    static async Task AddCategoryAsync()
    {
        Console.Write("Enter category name: ");
        string categoryName = Console.ReadLine();

        var newCategory = new
        {
            CategoryName = categoryName
        };

        await PostDataAsync("Category", newCategory);
    }

    static async Task<List<Category>> GetCategoriesAsync()
    {
        HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Category");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Category>>();
        }
        else
        {
            Console.WriteLine($"Failed to retrieve categories. Status code: {response.StatusCode}");
            return null;
        }
    }

    static async Task ViewAllCategoriesAsync()
    {
        var categories = await GetCategoriesAsync();
        Console.WriteLine("Categories retrieved from the API:");
        foreach (var category in categories)
        {
            Console.WriteLine($"CategoryId: {category.CategoryId}, CategoryName: {category.CategoryName}");
        }
    }
    static async Task UpdateCategoryAsync()
    {
        try
        {
            Console.Write("Enter the ID of the category you want to update: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID");
                return;
            }

            Console.Write("Enter the new name for the category: ");
            string newCategoryName = Console.ReadLine();

            var updatedCategory = new
            {
                CategoryId=categoryId,
                CategoryName = newCategoryName
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Category/{categoryId}", updatedCategory);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Category updated successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to update category. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static async Task DeleteCategoryAsync()
    {
        try
        {
            Console.Write("Enter the ID of the category you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID");
                return;
            }

            HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Category/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Category deleted successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to delete category. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }


    static async Task PostDataAsync(string endpoint, object data)
    {
        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"{BaseUrl}/{endpoint}", data);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{endpoint} added successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to add {endpoint}. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static async Task AddLibrarianAsync()
    {
        try
        {
            Console.Write("Enter librarian name: ");
            string name = Console.ReadLine();
            Console.Write("Enter librarian password: ");
            string password = Console.ReadLine();
            Console.Write("Enter librarian contact: ");
            string contact = Console.ReadLine();
            Console.Write("Enter librarian Role: ");
            string role = Console.ReadLine();

            var newLibrarian = new
            {
                Username = name,
                Password = password,
                Contact = contact,
                Role = role
            };
            await PostDataAsync("Librarain", newLibrarian);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static async Task<List<Librarian>> GetLibrariansAsync()
    {
        HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Librarain");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Librarian>>();
        }
        else
        {
            Console.WriteLine($"Failed to retrieve librarians. Status code: {response.StatusCode}");
            return null;
        }
    }
    static async Task ViewAllLibrariansAsync()
    {
        var librarians = await GetLibrariansAsync();
        Console.WriteLine("Librarians retrieved from the API:");
        foreach (var librarian in librarians)
        {
            Console.WriteLine($"ID: {librarian.Lid},UserName: {librarian.Username}, Password: {librarian.Password}, Contact: {librarian.Contact}, Role: {librarian.Role}");
        }
    }
    static async Task UpdateLibrarianAsync()
    {
        try
        {
            Console.Write("Enter the ID of the librarian you want to update: ");
            if (!int.TryParse(Console.ReadLine(), out int librarianId))
            {
                Console.WriteLine("Invalid librarian ID");
                return;
            }

            // Fetch the existing librarian data for the given ID
            var existingLibrarian = await GetLibrarianByIdAsync(librarianId);

            if (existingLibrarian == null)
            {
                Console.WriteLine($"Librarian with ID {librarianId} not found.");
                return;
            }
            // Prompt the user for updated information
            Console.Write("Enter new librarian name (or press Enter to keep existing): ");
            string newName = Console.ReadLine();
            Console.Write("Enter new librarian password (or press Enter to keep existing): ");
            string newPassword = Console.ReadLine();
            Console.Write("Enter new librarian contact (or press Enter to keep existing): ");
            string newContact = Console.ReadLine();
            Console.Write("Enter new librarian role (or press Enter to keep existing): ");
            string newRole = Console.ReadLine();

            // Update only the non-empty fields
            var updatedLibrarian = new
            {
                Lid = librarianId,
                Username = string.IsNullOrEmpty(newName) ? existingLibrarian.Username : newName,
                Password = string.IsNullOrEmpty(newPassword) ? existingLibrarian.Password : newPassword,
                Contact = string.IsNullOrEmpty(newContact) ? existingLibrarian.Contact : newContact,
                Role = string.IsNullOrEmpty(newRole) ? existingLibrarian.Role : newRole
            };

            HttpResponseMessage response = await client.PutAsJsonAsync($"{BaseUrl}/Librarain/{librarianId}", updatedLibrarian);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Librarian updated successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to update librarian. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task DeleteLibrarianAsync()
    {
        try
        {
            Console.Write("Enter the ID of the librarian you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int librarianId))
            {
                Console.WriteLine("Invalid librarian ID");
                return;
            }

            HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Librarain/{librarianId}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Librarian deleted successfully!");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to delete librarian. Status code: {response.StatusCode}, Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static async Task<Librarian> GetLibrarianByIdAsync(int librarianId)
    {
        HttpResponseMessage response = await client.GetAsync($"{BaseUrl}/Librarain/{librarianId}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Librarian>();
        }
        else
        {
            return null;
        }
    }











}
