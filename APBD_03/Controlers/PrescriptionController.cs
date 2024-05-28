using APBD_03.Model;
using APBD_03.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_03.Controlers;


[ApiController]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    
    /// <summary>
    /// Endpoint used to create presription.
    /// </summary>
    /// <param name="Prescription">New prescription data</param>
    /// <returns>201 Created</returns>
    /// <returns>400 Not Created</returns>
    [HttpPost]
    [Route("api/prescription")]
    public IActionResult CreateAnimal(NewPrescriptionRequest newPrescription)
    {
        var affectedCount = _prescriptionService.createPerscription(newPrescription);
        if (affectedCount <= 0) return StatusCode(StatusCodes.Status400BadRequest);
        return StatusCode(StatusCodes.Status201Created);
    }

    /// <summary>
    /// Endpoint used to create presription.
    /// </summary>
    /// <param name="Prescription">New prescription data</param>
    /// <returns>201 Created</returns>
    /// <returns>400 Not Created</returns>
    [HttpGet("api/{id:int}")]
    public PatientInfo GetPatientInfo(int id)
    {
        return _prescriptionService.GetPatientInfo(id);
    }
    

}