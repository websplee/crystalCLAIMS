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
    public class StandardDiagnosesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public StandardDiagnosesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<StandardDiagnosesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/StandardDiagnoses
        [HttpGet]
        public IActionResult Get()
        {
            var allStandardDiagnoses = _unitOfWork.StandardDiagnoses.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allStandardDiagnoses));
        }

        // GET: api/StandardDiagnoses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var standardDiagnosis = _unitOfWork.StandardDiagnoses
                .GetSingle(id);

            // Return the standardDiagnosiss otherwise return NotFound
            if (standardDiagnosis != null)
                return Ok(_mapper.Map<StandardDiagnosisViewModel>(standardDiagnosis));
            else
                return NotFound();
        }

        // POST: api/StandardDiagnoses
        [HttpPost]
        public IActionResult Post([FromBody] StandardDiagnosisViewModel standardDiagnosisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the StandardDiagnosis
            var newStandardDiagnosis = _mapper.Map<StandardDiagnosisViewModel, StandardDiagnosis>(standardDiagnosisViewModel);

            _unitOfWork.StandardDiagnoses.Add(newStandardDiagnosis);
            // Commit changes to the database to get StandardDiagnosisId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "StandardDiagnoses", id = newStandardDiagnosis.Id }, newStandardDiagnosis);

            return result;
        }

        // PUT: api/StandardDiagnoses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StandardDiagnosisViewModel standardDiagnosisViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the StandardDiagnosis to Edit
            var _standardDiagnosis = _unitOfWork.StandardDiagnoses
                .GetSingle(id);

            if (_standardDiagnosis == null)
            {
                return NotFound();
            }
            else
            {
                _standardDiagnosis.Code = standardDiagnosisViewModel.Code;
                _standardDiagnosis.Comment = standardDiagnosisViewModel.Comment;
                _standardDiagnosis.Description = standardDiagnosisViewModel.Description;
                _standardDiagnosis.LongName = standardDiagnosisViewModel.LongName;
                _standardDiagnosis.ShortName = standardDiagnosisViewModel.ShortName;

                // Put logic to handle inputer, maker, checker
            }

            standardDiagnosisViewModel = _mapper.Map<StandardDiagnosis, StandardDiagnosisViewModel>(_standardDiagnosis);

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

            // Get the StandardDiagnosis to Edit
            var _standardDiagnosis = _unitOfWork.StandardDiagnoses
                .GetSingle(id);

            if (_standardDiagnosis == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.StandardDiagnoses.Delete(_standardDiagnosis);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
