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
    public class ClaimsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public ClaimsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClaimsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/Claims
        [HttpGet]
        public IActionResult Get()
        {
            var allClaims = _unitOfWork.Claims.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allClaims));
            // return new string[] { "value1", "value2" };
        }

        // GET: api/Claims/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var claim = _unitOfWork.Claims
                .GetSingle(id);

            // Return the claim otherwise return NotFound
            if (claim != null)
                return Ok(_mapper.Map<ClaimViewModel>(claim));
            else
                return NotFound();
        }

        // POST: api/Claims
        [HttpPost]
        public IActionResult Post([FromBody] ClaimViewModel claim)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the bear minimal claim
            var newClaim = _mapper.Map<ClaimViewModel, Claim>(claim);
            newClaim.ClaimInitiationDate = DateTime.Now;

            _unitOfWork.Claims.Add(newClaim);
            // Commit changes to the database to get ClaimId
            _unitOfWork.SaveChanges();            

            // Iterate through ClaimViewModel to get ClaimDiagnosis, ClaimDrugs, ClaimDoctors, ClaimServices
            // ClaimDiagnosis
            foreach (var claimDiagnosis in claim.ClaimDiagnosis)
            {
                var newClaimDiagnosis = _mapper.Map<ClaimDiagnosisViewModel, ClaimDiagnosis>(claimDiagnosis);
                // Assign the newly created Claim Id to the Diagnosis
                newClaimDiagnosis.ClaimId = newClaim.Id;
                _unitOfWork.ClaimDiagnoses.Add(newClaimDiagnosis);
            }
            // Commit changes to the database
            _unitOfWork.SaveChanges();

            // ClaimDoctors
            foreach (var claimDoctor in claim.ClaimDoctors)
            {
                var newClaimDoctor = _mapper.Map<ClaimDoctorViewModel, ClaimDoctors>(claimDoctor);
                // Assign the newly created Claim Id to the Diagnosis
                newClaimDoctor.ClaimId = newClaim.Id;
                _unitOfWork.ClaimDoctors.Add(newClaimDoctor);
            }
            // Commit changes to the database
            _unitOfWork.SaveChanges();

            // ClaimDrugs
            foreach (var claimDrug in claim.ClaimDrugs)
            {
                var newClaimDrug = _mapper.Map<ClaimDrugViewModel, ClaimDrugs>(claimDrug);
                // Assign the newly created Claim Id to the Diagnosis
                newClaimDrug.ClaimId = newClaim.Id;
                _unitOfWork.ClaimDrugs.Add(newClaimDrug);
            }
            // Commit changes to the database
            _unitOfWork.SaveChanges();

            // ClaimServices
            foreach (var claimService in claim.ClaimServices)
            {
                var newClaimService = _mapper.Map<ClaimServiceViewModel, ClaimServices>(claimService);
                // Assign the newly created Claim Id to the Diagnosis
                newClaimService.ClaimId = newClaim.Id;
                _unitOfWork.ClaimServicesProvided.Add(newClaimService);
            }
            // Commit changes to the database
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "Claims", id = newClaim.Id }, newClaim);

            return result;
        }

        // PUT: api/Claims/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  ClaimViewModel claim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the Claim to Edit
            var _claim = _unitOfWork.Claims
                .GetSingle(id);

            if (_claim == null)
                return NotFound();
            else
            {
                // Think through the logic of allowing editing of claims
                // Consider using the logic for adding for the individual services****
                _claim = _mapper.Map<ClaimViewModel, Claim>(claim);
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
