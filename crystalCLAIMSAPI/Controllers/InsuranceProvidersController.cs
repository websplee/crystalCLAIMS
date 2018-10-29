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
    public class InsuranceProvidersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public InsuranceProvidersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<InsuranceProvidersController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/InsuranceProviders
        [HttpGet]
        public IActionResult Get()
        {
            var allInsuranceProviders = _unitOfWork.InsuranceProviders.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allInsuranceProviders));
        }

        // GET: api/InsuranceProviders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var insuranceProvider = _unitOfWork.InsuranceProviders
                .GetSingle(id);

            // Return the insuranceProviders otherwise return NotFound
            if (insuranceProvider != null)
                return Ok(_mapper.Map<InsuranceProviderViewModel>(insuranceProvider));
            else
                return NotFound();
        }

        // POST: api/InsuranceProviders
        [HttpPost]
        public IActionResult Post([FromBody] InsuranceProviderViewModel insuranceProviderViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the InsuranceProvider
            var newInsuranceProvider = _mapper.Map<InsuranceProviderViewModel, InsuranceProvider>(insuranceProviderViewModel);

            _unitOfWork.InsuranceProviders.Add(newInsuranceProvider);
            // Commit changes to the database to get InsuranceProviderId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "InsuranceProviders", id = newInsuranceProvider.Id }, newInsuranceProvider);

            return result;
        }

        // PUT: api/InsuranceProviders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InsuranceProviderViewModel insuranceProviderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the InsuranceProvider to Edit
            var _insuranceProvider = _unitOfWork.InsuranceProviders
                .GetSingle(id);

            if (_insuranceProvider == null)
            {
                return NotFound();
            }
            else
            {
                _insuranceProvider.AddressLine1 = insuranceProviderViewModel.AddressLine1;
                _insuranceProvider.AddressLine2 = insuranceProviderViewModel.AddressLine2;
                _insuranceProvider.DistrictId = insuranceProviderViewModel.DistrictId;
                _insuranceProvider.EmailAddress = insuranceProviderViewModel.EmailAddress;
                _insuranceProvider.Fax = insuranceProviderViewModel.Fax;
                _insuranceProvider.ProviderCode = insuranceProviderViewModel.ProviderCode;
                _insuranceProvider.ProviderName = insuranceProviderViewModel.ProviderName;
                //_insuranceProvider.Status = insuranceProviderViewModel.Status;
                _insuranceProvider.Telephone1 = insuranceProviderViewModel.Telephone1;
                _insuranceProvider.Telephone2 = insuranceProviderViewModel.Telephone2;
                _insuranceProvider.Telephone3 = insuranceProviderViewModel.Telephone3;
                _insuranceProvider.Website = insuranceProviderViewModel.Website;

                // Put logic to handle inputer, maker, checker
            }

            insuranceProviderViewModel = _mapper.Map<InsuranceProvider, InsuranceProviderViewModel>(_insuranceProvider);

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

            // Get the InsuranceProvider to Edit
            var _insuranceProvider = _unitOfWork.InsuranceProviders
                .GetSingle(id);

            if (_insuranceProvider == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.InsuranceProviders.Delete(_insuranceProvider);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }
            return new NoContentResult();
        }
    }
}
