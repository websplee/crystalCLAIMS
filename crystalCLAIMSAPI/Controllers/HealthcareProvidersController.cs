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
    public class HealthcareProvidersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public HealthcareProvidersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<HealthcareProvidersController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }


        // GET: api/HealthcareProviders
        [HttpGet]
        public IActionResult Get()
        {
            var allHealthcareProviders = _unitOfWork.HealthcareProviders.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allHealthcareProviders));
        }

        // GET: api/HealthcareProviders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var healthcareProvider = _unitOfWork.HealthcareProviders
                .GetSingle(id);

            // Return the healthcareProviders otherwise return NotFound
            if (healthcareProvider != null)
                return Ok(_mapper.Map<HealthcareProviderViewModel>(healthcareProvider));
            else
                return NotFound();
        }

        // POST: api/HealthcareProviders
        [HttpPost]
        public IActionResult Post([FromBody] HealthcareProviderViewModel healthcareProviderViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the HealthcareProvider
            var newHealthcareProvider = _mapper.Map<HealthcareProviderViewModel, HealthcareProvider>(healthcareProviderViewModel);

            _unitOfWork.HealthcareProviders.Add(newHealthcareProvider);
            // Commit changes to the database to get HealthcareProviderId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "HealthcareProviders", id = newHealthcareProvider.Id }, newHealthcareProvider);

            return result;
        }

        // PUT: api/HealthcareProviders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HealthcareProviderViewModel healthcareProviderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the HealthcareProvider to Edit
            var _healthcareProvider = _unitOfWork.HealthcareProviders
                .GetSingle(id);

            if (_healthcareProvider == null)
            {
                return NotFound();
            }
            else
            {
                _healthcareProvider.AddressLine1 = healthcareProviderViewModel.AddressLine1;
                _healthcareProvider.AddressLine2 = healthcareProviderViewModel.AddressLine2;
                _healthcareProvider.DistrictId = healthcareProviderViewModel.DistrictId;
                _healthcareProvider.EmailAddress = healthcareProviderViewModel.EmailAddress;
                _healthcareProvider.Fax = healthcareProviderViewModel.Fax;
                _healthcareProvider.JoiningDate = healthcareProviderViewModel.JoiningDate;
                _healthcareProvider.ProviderCode = healthcareProviderViewModel.ProviderCode;
                _healthcareProvider.ProviderName = healthcareProviderViewModel.ProviderName;
                _healthcareProvider.Status = healthcareProviderViewModel.Status;
                _healthcareProvider.Telephone1 = healthcareProviderViewModel.Telephone1;
                _healthcareProvider.Telephone2 = healthcareProviderViewModel.Telephone2;
                _healthcareProvider.Telephone3 = healthcareProviderViewModel.Telephone3;
                _healthcareProvider.Website = healthcareProviderViewModel.Website;

                // Put logic to handle inputer, maker, checker
            }

            healthcareProviderViewModel = _mapper.Map<HealthcareProvider, HealthcareProviderViewModel>(_healthcareProvider);

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

            // Get the HealthcareProvider to Edit
            var _healthcareProvider = _unitOfWork.HealthcareProviders
                .GetSingle(id);

            if (_healthcareProvider == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.HealthcareProviders.Delete(_healthcareProvider);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }
            return new NoContentResult();
        }
    }
}
    
