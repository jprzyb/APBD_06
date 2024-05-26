using APBD_03.Model;

namespace APBD_03.Services;

public interface IPrescriptionService
{
    int createPerscription(NewPrescriptionRequest newPrescription);
    PatientInfo GetPatientInfo(int id);
}