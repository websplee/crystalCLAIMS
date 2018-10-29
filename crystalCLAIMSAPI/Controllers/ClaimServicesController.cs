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
    public class ClaimServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public ClaimServicesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClaimServicesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/ClaimServices
        [HttpGet]
        public IActionResult Get()
        {
            var allClaimServices = _unitOfWork.ClaimServicesProvided.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimDiagnosisViewModel>>(allClaimServices));
        }

        // GET: api/ClaimServices/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var claimService = _unitOfWork.ClaimServicesProvided
                .GetSingle(id);

            // Return the claim otherwise return NotFound
            if (claimService != null)
                return Ok(_mapper.Map<ClaimServiceViewModel>(claimService));
            else
                return NotFound();
        }

        // GET: api/ClaimServices/GetByClaimId/5
        [HttpGet("{id}")]
        public IActionResult GetByClaimId(int id)
        {
            var claimServices = _unitOfWork.ClaimServicesProvided
                .FindBy(cd => cd.ClaimId == id);

            // Return the claim otherwise return NotFound
            if (claimServices != null)
                return Ok(_mapper.Map<IEnumerable<ClaimServiceViewModel>>(claimServices));
            else
                return NotFound();
        }

        // POST: api/ClaimServices
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ClaimServices/5
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
