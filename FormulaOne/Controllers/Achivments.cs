using AutoMapper;
using FormulaOne.DataService.Repos.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOS.Requests;
using FormulaOne.Entities.DTOS.Responces;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    public class Achivments : BaseController
    {
        public Achivments(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("drivers/{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievments(Guid driverId)
        {
            var driverAchievements =await unitOfWork.Achivements.GetDriverAchivmentsAasync(driverId);
            if (driverAchievements == null)
            {
                return NotFound("Achievements not found");
            }
            var result = mapper.Map<IEnumerable<DriverAchivmentResponse>>(driverAchievements);
            return Ok(result);  
        }

        [HttpPost]
        public async Task<IActionResult> AddAchievment([FromBody] CreateDriveAchivmentRequest driverAchievment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = mapper.Map<Achivment>(driverAchievment);

            await unitOfWork.Achivements.Create(result);
            await unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievments),new { driverId = result.DriverId},result );
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriveAchivmentRequest driverAchievment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = mapper.Map<Achivment>(driverAchievment);

            await unitOfWork.Achivements.UpDate(result);
            await unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
