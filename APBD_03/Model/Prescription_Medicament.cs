using System.ComponentModel.DataAnnotations;

namespace APBD_03.Model;

public class Prescription_Medicament
{
    [Required] public int IdMedicament { get; set; }
    [Required] public int IdPrescription { get; set; }
    [Required] public int Dose { get; set; }
    [Required, MaxLength(100)] public string Details { get; set; }
}