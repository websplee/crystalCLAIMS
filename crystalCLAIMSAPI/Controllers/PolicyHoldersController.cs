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
    public class PolicyHoldersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public PolicyHoldersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<PolicyHoldersController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/PolicyHolders
        [HttpGet]
        public IActionResult Get()
        {
            var allPolicyHolders = _unitOfWork.PolicyHolders.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allPolicyHolders));
        }

        // GET: api/PolicyHolders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var policyHolder = _unitOfWork.PolicyHolders
                .GetSingle(id);

            // Return the policyHolders otherwise return NotFound
            if (policyHolder != null)
                return Ok(_mapper.Map<PolicyHolderViewModel>(policyHolder));
            else
                return NotFound();
        }

        // POST: api/PolicyHolders
        [HttpPost]
        public IActionResult Post([FromBody] PolicyHolderViewModel policyHolderViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the PolicyHolder
            var newPolicyHolder = _mapper.Map<PolicyHolderViewModel, PolicyHolder>(policyHolderViewModel);

            _unitOfWork.PolicyHolders.Add(newPolicyHolder);
            // Commit changes to the database to get PolicyHolderId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "PolicyHolders", id = newPolicyHolder.Id }, newPolicyHolder);

            return result;
        }

        // PUT: api/PolicyHolders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PolicyHolderViewModel policyHolderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the PolicyHolder to Edit
            var _policyHolder = _unitOfWork.PolicyHolders
                .GetSingle(id);

            if (_policyHolder == null)
            {
                return NotFound();
            }
            else
            {
                _policyHolder.Address1 = policyHolderViewModel.Address1;
                _policyHolder.Address2 = policyHolderViewModel.Address2;               
                _policyHolder.Email = policyHolderViewModel.Email;
                _policyHolder.InsuranceProviderId = policyHolderViewModel.InsuranceProviderId;
                _policyHolder.IsActive = policyHolderViewModel.IsActive;
                _policyHolder.PolicyHolderName = policyHolderViewModel.PolicyHolderName;
                _policyHolder.PolicyNumber = policyHolderViewModel.PolicyNumber;
                _policyHolder.Status = policyHolderViewModel.Status;
                _policyHolder.Telephone1 = policyHolderViewModel.Telephone1;
                _policyHolder.Telephone = policyHolderViewModel.Telephone;
                _policyHolder.Website = policyHolderViewModel.Website;
                // Put logic to handle inputer, maker, checker
            }

            policyHolderViewModel = _mapper.Map<PolicyHolder, PolicyHolderViewModel>(_policyHolder);

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

            // Get the PolicyHolder to Edit
            var _policyHolder = _unitOfWork.PolicyHolders
                .GetSingle(id);

            if (_policyHolder == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.PolicyHolders.Delete(_policyHolder);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
