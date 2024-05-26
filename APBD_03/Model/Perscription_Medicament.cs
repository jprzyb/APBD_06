using System.ComponentModel.DataAnnotations;

namespace APBD_03.Model;

public class Perscription_Medicament
{
    [Required] public int IdMedicament { get; set; }
    [Required] public int IdPerscription { get; set; }
    [Required] public int Dose { get; set; }
    [Required, MaxLength(100)] public string Details { get; set; }
}