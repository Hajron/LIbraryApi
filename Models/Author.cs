
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [Length(5, 100)]
    public string Name { get; set; } = "";
    public ICollection<Book> Books { get; set; }
}