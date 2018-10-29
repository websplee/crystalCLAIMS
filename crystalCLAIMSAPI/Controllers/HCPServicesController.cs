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
    public class HCPServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public HCPServicesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<HCPServicesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/HCPServices
        [HttpGet]
        public IActionResult Get()
        {
            var allHCPServices = _unitOfWork.HCPServices.GetAll();
            return Ok(_mapper.Map<IEnumerable<HCPDiagnosisViewModel>>(allHCPServices));
        }

        // GET: api/HCPServices/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hCPService = _unitOfWork.HCPServices
                .GetSingle(id);

            // Return the HCPService otherwise return NotFound
            if (hCPService != null)
                return Ok(_mapper.Map<HCPServiceViewModel>(hCPService));
            else
                return NotFound();
        }

        // GET: api/HCPServices/GetByHCPId/5
        [HttpGet("{id}")]
        public IActionResult GetByHCPId(int id)
        {
            var hCPServices = _unitOfWork.HCPServices
                .FindBy(cd => cd.HealthcareProviderId == id);

            // Return the HCPService otherwise return NotFound
            if (hCPServices != null)
                return Ok(_mapper.Map<IEnumerable<HCPServiceViewModel>>(hCPServices));
            else
                return NotFound();
        }

        // POST: api/HCPServices
        [HttpPost]
        public IActionResult Post([FromBody] HCPServiceViewModel hCPServiceViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the HCPService
            var newHCPService = _mapper.Map<HCPServiceViewModel, HCPService>(hCPServiceViewModel);

            _unitOfWork.HCPServices.Add(newHCPService);
            // Commit changes to the database to get HCPServiceId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "HCPServices", id = newHCPService.Id }, newHCPService);

            return result;
        }

        // PUT: api/HCPServices/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HCPServiceViewModel hCPServiceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the HCPService to Edit
            var _hCPService = _unitOfWork.HCPServices
                .GetSingle(id);

            if (_hCPService == null)
            {
                return NotFound();
            }
            else
            {
                _hCPService.Price = hCPServiceViewModel.Price;

                // Put logic to handle inputer, maker, checker
            }
            hCPServiceViewModel = _mapper.Map<HCPService, HCPServiceViewModel>(_hCPService);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the HCPService to Edit
            var hCPService = _unitOfWork.HCPServices
                .GetSingle(id);

            if (hCPService == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.HCPServices.Delete(hCPService);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
