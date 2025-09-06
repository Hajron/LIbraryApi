
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class Loan
{
    public int Id { get; set; }

    [Required]
    [ForeignKey("Book")]
    public int BookId { get; set; }

    public Book book { get; set; }

    public DateTime LoanDate { get; set; } = DateTime.Now;
    public DateTime? ReturnDate { get; set; }
}