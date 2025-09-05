using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;
public class Book
{ 
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title length can't be more than 100.")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Author is required.")]
    public string Author { get; set; } = "";

    [Range(1910, 2025, ErrorMessage = "Year must be between 1910 and 2024.")]
    public int Year { get; set; }
}
