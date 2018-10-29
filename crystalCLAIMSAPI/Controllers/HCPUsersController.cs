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
    public class HCPUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public HCPUsersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<HCPUsersController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/HCPUsers
        [HttpGet]
        public IActionResult Get()
        {
            var allHCPUsers = _unitOfWork.HCPUsers.GetAll();
            return Ok(_mapper.Map<IEnumerable<HCPUserViewModel>>(allHCPUsers));
        }

        // GET: api/HCPUsers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hCPUser = _unitOfWork.HCPUsers
                .GetSingle(id);

            // Return the HCPUser otherwise return NotFound
            if (hCPUser != null)
                return Ok(_mapper.Map<HCPUserViewModel>(hCPUser));
            else
                return NotFound();
        }

        // GET: api/HCPUsers/GetByHCPId/5
        [HttpGet("{id}")]
        public IActionResult GetByHCPId(int id)
        {
            var hCPUsers = _unitOfWork.HCPUsers
                .FindBy(cd => cd.HealthcareProviderId == id);

            // Return the HCPUser otherwise return NotFound
            if (hCPUsers != null)
                return Ok(_mapper.Map<IEnumerable<HCPUserViewModel>>(hCPUsers));
            else
                return NotFound();
        }

        // POST: api/HCPUsers
        [HttpPost]
        public IActionResult Post([FromBody] HCPUserViewModel hCPUserViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the HCPUser
            var newHCPUser = _mapper.Map<HCPUserViewModel, HCPUser>(hCPUserViewModel);

            _unitOfWork.HCPUsers.Add(newHCPUser);
            // Commit changes to the database to get HCPUserId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "HCPUsers", id = newHCPUser.Id }, newHCPUser);

            return result;
        }

        // PUT: api/HCPUsers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HCPUserViewModel hCPUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the HCPUser to Edit
            var _hCPUser = _unitOfWork.HCPUsers
                .GetSingle(id);

            if (_hCPUser == null)
            {
                return NotFound();
            }
            else
            {
                _hCPUser.Firstname = hCPUserViewModel.Firstname;
                _hCPUser.Lastname = hCPUserViewModel.Lastname;
                _hCPUser.IsActive = hCPUserViewModel.IsActive;
                _hCPUser.IsAdmin = hCPUserViewModel.IsAdmin;
                // Put logic to handle inputer, maker, checker
            }
            hCPUserViewModel = _mapper.Map<HCPUser, HCPUserViewModel>(_hCPUser);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the HCPUser to Edit
            var hCPUser = _unitOfWork.HCPUsers
                .GetSingle(id);

            if (hCPUser == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.HCPUsers.Delete(hCPUser);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}