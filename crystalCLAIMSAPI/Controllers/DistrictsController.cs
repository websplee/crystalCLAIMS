using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Helpers;
using crystalCLAIMSAPI.UnitOfWork;
using crystalCLAIMSAPI.ViewModels;

namespace crystalCLAIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public DistrictsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<DistrictsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/Districts
        [HttpGet]
        public IActionResult Get()
        {
            var allDistricts = _unitOfWork.Districts.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allDistricts));
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var district = _unitOfWork.Districts
                .GetSingle(id);

            // Return the districts otherwise return NotFound
            if (district != null)
                return Ok(_mapper.Map<DistrictViewModel>(district));
            else
                return NotFound();
        }

        // POST: api/Districts
        [HttpPost]
        public IActionResult Post([FromBody] DistrictViewModel districtViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the District
            var newDistrict = _mapper.Map<DistrictViewModel, District>(districtViewModel);            

            _unitOfWork.Districts.Add(newDistrict);
            // Commit changes to the database to get DistrictId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "Districts", id = newDistrict.Id }, newDistrict);

            return result;
        }

        // PUT: api/Districts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DistrictViewModel districtViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the District to Edit
            var _district = _unitOfWork.Districts
                .GetSingle(id);

            if (_district == null)
            {
                return NotFound();
            }
            else
            {
                _district.DistrictName = districtViewModel.DistrictName;

                // Put logic to handle inputer, maker, checker
            }

            districtViewModel = _mapper.Map<District, DistrictViewModel>(_district);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the District to Edit
            var _district = _unitOfWork.Districts
                .GetSingle(id);

            if (_district == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Districts.Delete(_district);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
