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
    public class HCPDoctorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public HCPDoctorsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<HCPDoctorsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/HCPDoctors
        [HttpGet]
        public IActionResult Get()
        {
            var allHCPDoctors = _unitOfWork.HCPDoctors.GetAll();
            return Ok(_mapper.Map<IEnumerable<HCPDoctorViewModel>>(allHCPDoctors));
        }

        // GET: api/HCPDoctors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hCPDoctor = _unitOfWork.HCPDoctors
                .GetSingle(id);

            // Return the HCPDoctor otherwise return NotFound
            if (hCPDoctor != null)
                return Ok(_mapper.Map<HCPDoctorViewModel>(hCPDoctor));
            else
                return NotFound();
        }

        // GET: api/HCPDoctors/GetByHCPId/5
        [HttpGet("{id}")]
        public IActionResult GetByHCPId(int id)
        {
            var hCPDoctors = _unitOfWork.HCPDoctors
                .FindBy(cd => cd.HealthcareProviderId == id);

            // Return the HCPDoctor otherwise return NotFound
            if (hCPDoctors != null)
                return Ok(_mapper.Map<IEnumerable<HCPDoctorViewModel>>(hCPDoctors));
            else
                return NotFound();
        }

        // POST: api/HCPDoctors
        [HttpPost]
        public IActionResult Post([FromBody] HCPDoctorViewModel hCPDoctorView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the HCPDoctor
            var newHCPDoctor = _mapper.Map<HCPDoctorViewModel, HCPDoctor>(hCPDoctorView);

            _unitOfWork.HCPDoctors.Add(newHCPDoctor);
            // Commit changes to the database to get HCPDoctorId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "HCPDoctors", id = newHCPDoctor.Id }, newHCPDoctor);

            return result;
        }

        // PUT: api/HCPDoctors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HCPDoctorViewModel hCPDoctorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the HCPDoctor to Edit
            var _hCPDoctor = _unitOfWork.HCPDoctors
                .GetSingle(id);

            if (_hCPDoctor == null)
            {
                return NotFound();
            }
            else
            {
                _hCPDoctor.HCPEmployeeId = hCPDoctorViewModel.HCPEmployeeId;

                // Put logic to handle inputer, maker, checker
            }
            hCPDoctorViewModel = _mapper.Map<HCPDoctor, HCPDoctorViewModel>(_hCPDoctor);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the HCPDoctor to Edit
            var hCPDoctor = _unitOfWork.HCPDoctors
                .GetSingle(id);

            if (hCPDoctor == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.HCPDoctors.Delete(hCPDoctor);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
