using System.ComponentModel.DataAnnotations;

namespace Core.Business.Models;

public class UserModel
{
    [Key]
    public int Id { get; set;  }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
}
