using AutoMapper;
using FormulaOne.DataService.Repos.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOS.Requests;
using FormulaOne.Entities.DTOS.Responces;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    public class Drivers : BaseController
    {
        public Drivers(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverі()
        {
            var drivers = await unitOfWork.Drivers.GetALL();

            var result = mapper.Map<IEnumerable<DriverResponse>>(drivers);
            return Ok(result);
        }

        [HttpGet("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await unitOfWork.Drivers.GetSingle(driverId);
            if (driver == null)
            {
                return NotFound();
            }

            var result = mapper.Map<DriverResponse>(driver);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = mapper.Map<Driver>(driver);

            await unitOfWork.Drivers.Create(result);
            await unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetDriver),new {driverId=result.Id},result);

        }

        [HttpPut("")]
        public async Task<IActionResult> UpDateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = mapper.Map<Driver>(driver);

            await unitOfWork.Drivers.UpDate(result);
            await unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);

        }

        [HttpDelete("{driverId:Guid}")]
        public async Task<IActionResult> RemoveDriver(Guid driverId)
        {
            var driver= await unitOfWork.Drivers.GetSingle(driverId);
            if(driver == null)
            {
                return NotFound();  
            }
            await unitOfWork.Drivers.Remove(driverId); 
            await unitOfWork.CompleteAsync();
            return NoContent();

        }


    }


}
