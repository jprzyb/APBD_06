using APBD_03.Model;
using Microsoft.Data.SqlClient;

namespace APBD_03.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private IConfiguration _configuration;
    private string _connectionString;

    public PrescriptionRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        string strProject = "HOST"; // Wprowadź nazwę instancji serwera SQL
        string strDatabase = "DB_NAME"; // Wprowadź nazwę bazy danych
        string strUserID = "usr"; // Wprowadź nazwę użytkownika SQL Server
        string strPassword = "pass"; // Wprowadź hasło użytkownika SQL Server
        _connectionString = "data source=" + strProject +
                            ";Persist Security Info=false;database=" + strDatabase +
                            ";user id=" + strUserID + ";password=" +
                            strPassword +
                            ";Connection Timeout = 0;trustServerCertificate=true;";
    }
    public int CreatePrescription(NewPrescriptionRequest newPrescription)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        if (!patientExist(con, newPrescription.Patient)) createNewPatient(con, newPrescription.Patient);
        if (newPrescription.Medicaments.Count > 10) return 0;
        if (newPrescription.DueDate >= newPrescription.Date) return 0;
        foreach (var med in newPrescription.Medicaments) if (!medicamentExist(con, med)) return 0;

        string query =
            "INSERT INTO Prescription (IdPrescription, Date, DueDate, IdPatient, IdDoctor) VALUES (@IdPrescription, @Date, @DueDate, @IdPatient, @IdDoctor)";
        var cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@IdPrescription", new Random().Next(0, 10000));
        cmd.Parameters.AddWithValue("@Date", newPrescription.Date);
        cmd.Parameters.AddWithValue("@DueDate", newPrescription.DueDate);
        cmd.Parameters.AddWithValue("@IdPatient", newPrescription.Patient.IdPatient);
        cmd.Parameters.AddWithValue("@IdDoctor", newPrescription.Doctor.IdDoctor);
        return cmd.ExecuteNonQuery();
    }

    private bool medicamentExist(SqlConnection con, Medicament med)
    {
        String query = "SELECT COUNT(*) FROM Medicament WHERE IdMedicament = @IdMedicament";
        var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@IdMedicament", med.IdMedicament);
        return cmd.ExecuteNonQuery() > 0;
    }

    private void createNewPatient(SqlConnection con, Patient patient)
    {
        String query = "INSERT INTO Patient (IdPatient, FirstName, LastName, Birthdate) VALUES (@IdPatient, @FirstName, @LastName, @Birthdate)";
        var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@IdPatient", patient.IdPatient);
        cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
        cmd.Parameters.AddWithValue("@LastName", patient.LastName);
        cmd.Parameters.AddWithValue("@Birthdate", patient.Birthdate);
        cmd.ExecuteNonQuery();
    }

    private bool patientExist(SqlConnection con, Patient patient)
    {
        String query = "SELECT COUNT(*) FROM Patient WHERE IdPatient = @IdPatient";
        var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@IdPatient", patient.IdPatient);
        return cmd.ExecuteNonQuery() > 0;
    }
    
    private bool patientExist(SqlConnection con, int id)
    {
        String query = "SELECT COUNT(*) FROM Patient WHERE IdPatient = @IdPatient";
        var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@IdPatient", id);
        return cmd.ExecuteNonQuery() > 0;
    }

    private void getPatientById(SqlConnection con, int id)
    {
        
    }
    
    public PatientInfo GetPatientInfo(int id)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        if (!patientExist(con, id)) return null;
        
    }
}