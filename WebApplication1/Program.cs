using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Service;

string strProject = "SCLAP45"; // Wprowadź nazwę instancji serwera SQL
string strDatabase = "apbd06"; // Wprowadź nazwę bazy danych
string strUserID = "apbd"; // Wprowadź nazwę użytkownika SQL Server
string strPassword = "apbd"; // Wprowadź hasło użytkownika SQL Server
string _connectionString = "data source=" + strProject +
                    ";Persist Security Info=false;database=" + strDatabase +
                    ";user id=" + strUserID + ";password=" +
                    strPassword +
                    ";Connection Timeout = 0;trustServerCertificate=true;";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(_connectionString)));


builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

// app configuration
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // app.UseHsts();
}

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseAuthorization();
app.MapControllers();
app.Run();