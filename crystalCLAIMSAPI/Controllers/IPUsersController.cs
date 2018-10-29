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
    public class IPUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public IPUsersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<IPUsersController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/IPUsers
        [HttpGet]
        public IActionResult Get()
        {
            var allIPUsers = _unitOfWork.IPUsers.GetAll();
            return Ok(_mapper.Map<IEnumerable<IPUserViewModel>>(allIPUsers));
        }

        // GET: api/IPUsers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var iPUser = _unitOfWork.IPUsers
                .GetSingle(id);

            // Return the IPUser otherwise return NotFound
            if (iPUser != null)
                return Ok(_mapper.Map<IPUserViewModel>(iPUser));
            else
                return NotFound();
        }

        // GET: api/IPUsers/GetByIPId/5
        [HttpGet("{id}")]
        public IActionResult GetByIPId(int id)
        {
            var iPUsers = _unitOfWork.IPUsers
                .FindBy(cd => cd.InsuranceProviderId == id);

            // Return the IPUser otherwise return NotFound
            if (iPUsers != null)
                return Ok(_mapper.Map<IEnumerable<IPUserViewModel>>(iPUsers));
            else
                return NotFound();
        }

        // POST: api/IPUsers
        [HttpPost]
        public IActionResult Post([FromBody] IPUserViewModel iPUserViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the IPUser
            var newIPUser = _mapper.Map<IPUserViewModel, IPUser>(iPUserViewModel);

            _unitOfWork.IPUsers.Add(newIPUser);
            // Commit changes to the database to get IPUserId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "IPUsers", id = newIPUser.Id }, newIPUser);

            return result;
        }

        // PUT: api/IPUsers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] IPUserViewModel iPUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the IPUser to Edit
            var _iPUser = _unitOfWork.IPUsers
                .GetSingle(id);

            if (_iPUser == null)
            {
                return NotFound();
            }
            else
            {
                _iPUser.Firstname = iPUserViewModel.Firstname;
                _iPUser.Lastname = iPUserViewModel.Lastname;
                _iPUser.IsActive = iPUserViewModel.IsActive;
                _iPUser.IsAdmin = iPUserViewModel.IsAdmin;
                // Put logic to handle inputer, maker, checker
            }
            iPUserViewModel = _mapper.Map<IPUser, IPUserViewModel>(_iPUser);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the IPUser to Edit
            var iPUser = _unitOfWork.IPUsers
                .GetSingle(id);

            if (iPUser == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.IPUsers.Delete(iPUser);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
