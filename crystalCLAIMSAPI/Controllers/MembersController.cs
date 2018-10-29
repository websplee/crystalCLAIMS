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
    public class MembersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public MembersController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<MembersController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/Members
        [HttpGet]
        public IActionResult Get()
        {
            var allMembers = _unitOfWork.Members.GetAll();
            return Ok(_mapper.Map<IEnumerable<MemberViewModel>>(allMembers));
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var member = _unitOfWork.Members
                .GetSingle(id);

            // Return the Member otherwise return NotFound
            if (member != null)
                return Ok(_mapper.Map<MemberViewModel>(member));
            else
                return NotFound();
        }

        // GET: api/Members/GetByIPId/5
        [HttpGet("{id}")]
        public IActionResult GetByIPId(int id)
        {
            var members = _unitOfWork.Members
                .FindBy(cd => cd.PolicyHolder.InsuranceProviderId == id);

            // Return the Member otherwise return NotFound
            if (members != null)
                return Ok(_mapper.Map<IEnumerable<MemberViewModel>>(members));
            else
                return NotFound();
        }

        // GET: api/Members/GetByPolicyHolderId/5
        [HttpGet("{id}", Name = "GetByPolicyHolderId")]
        public IActionResult GetByPolicyHolderId(int id)
        {
            var members = _unitOfWork.Members
                .FindBy(cd => cd.PolicyHolderId == id);

            // Return the Member otherwise return NotFound
            if (members != null)
                return Ok(_mapper.Map<IEnumerable<MemberViewModel>>(members));
            else
                return NotFound();
        }
        // POST: api/Members
        [HttpPost]
        public IActionResult Post([FromBody] MemberViewModel memberViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the Member
            var newMember = _mapper.Map<MemberViewModel, Member>(memberViewModel);

            _unitOfWork.Members.Add(newMember);
            // Commit changes to the database to get MemberId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "Members", id = newMember.Id }, newMember);

            return result;
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MemberViewModel memberViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the Member to Edit
            var _member = _unitOfWork.Members
                .GetSingle(id);

            if (_member == null)
            {
                return NotFound();
            }
            else
            {
                _member.AnnualLimit = memberViewModel.AnnualLimit;
                _member.DateOfBirth = memberViewModel.DateOfBirth;
                _member.EmployeeNo = memberViewModel.EmployeeNo;               
                _member.Firstname = memberViewModel.Firstname;
                _member.Gender = memberViewModel.Gender;
                _member.Lastname = memberViewModel.Lastname;
                _member.IsActive = memberViewModel.IsActive;
                _member.MemberSince = memberViewModel.MemberSince;
                _member.NationalId = memberViewModel.NationalId;
                // _member.PolicyHolderId = memberViewModel.PolicyHolderId; - This must only be done from the backend under rare circumstances
                _member.RelationshipType = memberViewModel.RelationshipType;
                _member.UtilizedTillDate = memberViewModel.UtilizedTillDate;
                // Put logic to handle inputer, maker, checker
            }
            memberViewModel = _mapper.Map<Member, MemberViewModel>(_member);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the Member to Edit
            var member = _unitOfWork.Members
                .GetSingle(id);

            if (member == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Members.Delete(member);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }
            return new NoContentResult();
        }
    }
}
