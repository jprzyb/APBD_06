using APBD_03.Model;

namespace APBD_03.Repositories;

public interface IPrescriptionRepository
{
    int CreatePrescription(NewPrescriptionRequest newPrescription);
    PatientInfo GetPatientInfo(int id);
}