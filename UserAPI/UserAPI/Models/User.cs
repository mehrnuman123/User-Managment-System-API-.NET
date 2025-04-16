using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(50, ErrorMessage = "Name can't exceed 50 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
}
