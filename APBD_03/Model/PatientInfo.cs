using System.ComponentModel.DataAnnotations;

namespace APBD_03.Model;

public class PatientInfo
{
    [Required] public Patient Patient { get; set; }
    [Required] public List<Prescription> Prescriptions { get; set; }
}