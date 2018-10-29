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
    public class ClaimDrugsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public ClaimDrugsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClaimDrugsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/ClaimDrugs
        [HttpGet]
        public IActionResult Get()
        {
            var allClaimDrugs = _unitOfWork.ClaimDrugs.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimDrugViewModel>>(allClaimDrugs));
        }

        // GET: api/ClaimDrugs/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var claimDrug = _unitOfWork.ClaimDrugs
                .GetSingle(id);

            // Return the claim otherwise return NotFound
            if (claimDrug != null)
                return Ok(_mapper.Map<ClaimDrugViewModel>(claimDrug));
            else
                return NotFound();
        }

        // GET: api/ClaimDrugs/GetByClaimId/5
        [HttpGet("{id}")]
        public IActionResult GetByClaimId(int id)
        {
            var claimDrugs = _unitOfWork.ClaimDrugs
                .FindBy(cd => cd.ClaimId == id);

            // Return the claim otherwise return NotFound
            if (claimDrugs != null)
                return Ok(_mapper.Map<IEnumerable<ClaimDrugViewModel>>(claimDrugs));
            else
                return NotFound();
        }

        // POST: api/ClaimDrugs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ClaimDrugs/5
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
