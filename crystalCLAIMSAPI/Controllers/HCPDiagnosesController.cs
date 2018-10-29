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
    public class HCPDiagnosesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public HCPDiagnosesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<HCPDiagnosesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/HCPDiagnoses
        [HttpGet]
        public IActionResult Get()
        {
            var allHCPDiagnoses = _unitOfWork.HCPDiagnoses.GetAll();
            return Ok(_mapper.Map<IEnumerable<HCPDiagnosisViewModel>>(allHCPDiagnoses));
        }

        // GET: api/HCPDiagnoses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hCPDiagnosis = _unitOfWork.HCPDiagnoses
                .GetSingle(id);

            // Return the HCPDiagnosis otherwise return NotFound
            if (hCPDiagnosis != null)
                return Ok(_mapper.Map<HCPDiagnosisViewModel>(hCPDiagnosis));
            else
                return NotFound();
        }

        // GET: api/HCPDiagnoses/GetByHCPId/5
        [HttpGet("{id}")]
        public IActionResult GetByHCPId(int id)
        {
            var hCPDiagnoses = _unitOfWork.HCPDiagnoses
                .FindBy(cd => cd.HealthcareProviderId == id);

            // Return the HCPDiagnosis otherwise return NotFound
            if (hCPDiagnoses != null)
                return Ok(_mapper.Map<IEnumerable<HCPDiagnosisViewModel>>(hCPDiagnoses));
            else
                return NotFound();
        }

        // POST: api/HCPDiagnoses
        [HttpPost]
        public IActionResult Post([FromBody] HCPDiagnosisViewModel hCPDiagnosisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the HCPDiagnosis
            var newHCPDiagnosis = _mapper.Map<HCPDiagnosisViewModel, HCPDiagnosis>(hCPDiagnosisViewModel);

            _unitOfWork.HCPDiagnoses.Add(newHCPDiagnosis);
            // Commit changes to the database to get HCPDiagnosisId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "HCPDiagnoses", id = newHCPDiagnosis.Id }, newHCPDiagnosis);

            return result;
        }

        // PUT: api/HCPDiagnoses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HCPDiagnosisViewModel hCPDiagnosisViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the HCPDiagnosis to Edit
            var _hCPDiagnosis = _unitOfWork.HCPDiagnoses
                .GetSingle(id);

            if (_hCPDiagnosis == null)
            {
                return NotFound();
            }
            else
            {
                _hCPDiagnosis.Price = hCPDiagnosisViewModel.Price;

                // Put logic to handle inputer, maker, checker
            }
            hCPDiagnosisViewModel = _mapper.Map<HCPDiagnosis, HCPDiagnosisViewModel>(_hCPDiagnosis);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the HCPDiagnosis to Edit
            var hCPDiagnosis = _unitOfWork.HCPDiagnoses
                .GetSingle(id);

            if (hCPDiagnosis == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.HCPDiagnoses.Delete(hCPDiagnosis);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
