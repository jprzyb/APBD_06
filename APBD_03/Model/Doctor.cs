using System.ComponentModel.DataAnnotations;

namespace APBD_03.Model;

public class Doctor
{
    [Required] public int IdDoctor { get; set; }

    [Required, MaxLength(100)] public string FirstName { get; set; }

    [Required, MaxLength(100)] public string LastName { get; set; }

    [Required, MaxLength(100), EmailAddress] public string Email { get; set; }
}