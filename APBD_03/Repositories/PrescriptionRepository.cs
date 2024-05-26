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
        if (!patientExist(con, newPrescription.Patient)) return 0;
        return 0;
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
}