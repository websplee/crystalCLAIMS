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
    public class ClaimDoctorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public ClaimDoctorsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClaimDoctorsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/ClaimDoctor
        [HttpGet]
        public IActionResult Get()
        {
            var allClaimDoctors = _unitOfWork.ClaimDoctors.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimDoctorViewModel>>(allClaimDoctors));
        }

        // GET: api/ClaimDoctor/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var claimDoctor = _unitOfWork.ClaimDoctors
                .GetSingle(id);

            // Return the claim otherwise return NotFound
            if (claimDoctor != null)
                return Ok(_mapper.Map<ClaimDoctorViewModel>(claimDoctor));
            else
                return NotFound();
        }

        // GET: api/ClaimDoctors/GetByClaimId/5
        [HttpGet("{id}")]
        public IActionResult GetByClaimId(int id)
        {
            var claimDoctors = _unitOfWork.ClaimDoctors
                .FindBy(cd => cd.ClaimId == id);

            // Return the claim otherwise return NotFound
            if (claimDoctors != null)
                return Ok(_mapper.Map<IEnumerable<ClaimDoctorViewModel>>(claimDoctors));
            else
                return NotFound();
        }
        // POST: api/ClaimDoctor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ClaimDoctor/5
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
