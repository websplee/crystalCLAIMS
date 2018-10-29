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
    public class ClaimDiagnosesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public ClaimDiagnosesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClaimDiagnosesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/ClaimDiagnoses
        [HttpGet]
        public IActionResult Get()
        {
            var allClaimDiagnoses = _unitOfWork.ClaimDiagnoses.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimDiagnosisViewModel>>(allClaimDiagnoses));
        }

        // GET: api/ClaimDiagnoses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var claimDiagnosis = _unitOfWork.ClaimDiagnoses
                .GetSingle(id);

            // Return the claim otherwise return NotFound
            if (claimDiagnosis != null)
                return Ok(_mapper.Map<ClaimDiagnosisViewModel>(claimDiagnosis));
            else
                return NotFound();
        }

        // GET: api/ClaimDiagnoses/GetByClaimId/5
        [HttpGet("{id}")]
        [Route("GetByClaimId")]
        public IActionResult GetByClaimId([FromQuery] int id)
        {
            var claimDiagnoses = _unitOfWork.ClaimDiagnoses
                .FindBy(cd => cd.ClaimId == id);

            // Return the claim otherwise return NotFound
            if (claimDiagnoses != null)
                return Ok(_mapper.Map<IEnumerable<ClaimDiagnosisViewModel>>(claimDiagnoses));
            else
                return NotFound();
        }
        /* POST: api/ClaimDiagnoses
        [HttpPost]
        public IActionResult Post([FromBody] ClaimDiagnosisViewModel claimDiagnosis)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the ClaimDiagnosis
            var newClaimDiagnosis = _mapper.Map<ClaimDiagnosisViewModel, ClaimDiagnosis>(claimDiagnosis);

        } */

        // PUT: api/ClaimDiagnoses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
