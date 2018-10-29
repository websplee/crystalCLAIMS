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
    public class MedicalPersonnelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public MedicalPersonnelController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<MedicalPersonnelController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/MedicalPersonnel
        [HttpGet]
        public IActionResult Get()
        {
            var allMedicalPersonnel = _unitOfWork.MedicalPersonnel.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allMedicalPersonnel));
        }

        // GET: api/MedicalPersonnel/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var medicalPersonnel = _unitOfWork.MedicalPersonnel
                .GetSingle(id);

            // Return the medicalPersonnels otherwise return NotFound
            if (medicalPersonnel != null)
                return Ok(_mapper.Map<MedicalPersonnelViewModel>(medicalPersonnel));
            else
                return NotFound();
        }

        // POST: api/MedicalPersonnel
        [HttpPost]
        public IActionResult Post([FromBody] MedicalPersonnelViewModel medicalPersonnelViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the MedicalPersonnel
            var newMedicalPersonnel = _mapper.Map<MedicalPersonnelViewModel, MedicalPersonnel>(medicalPersonnelViewModel);

            _unitOfWork.MedicalPersonnel.Add(newMedicalPersonnel);
            // Commit changes to the database to get MedicalPersonnelId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "MedicalPersonnel", id = newMedicalPersonnel.Id }, newMedicalPersonnel);

            return result;
        }

        // PUT: api/MedicalPersonnel/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MedicalPersonnelViewModel medicalPersonnelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the MedicalPersonnel to Edit
            var _medicalPersonnel = _unitOfWork.MedicalPersonnel
                .GetSingle(id);

            if (_medicalPersonnel == null)
            {
                return NotFound();
            }
            else
            {
                _medicalPersonnel.Firstname = medicalPersonnelViewModel.Firstname;
                _medicalPersonnel.Lastname = medicalPersonnelViewModel.Lastname;
                _medicalPersonnel.PracticingId = medicalPersonnelViewModel.PracticingId;
                _medicalPersonnel.Qualifications = medicalPersonnelViewModel.Qualifications;
                _medicalPersonnel.Title = medicalPersonnelViewModel.Title;

                // Put logic to handle inputer, maker, checker
            }

            medicalPersonnelViewModel = _mapper.Map<MedicalPersonnel, MedicalPersonnelViewModel>(_medicalPersonnel);

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

            // Get the MedicalPersonnel to Edit
            var _medicalPersonnel = _unitOfWork.MedicalPersonnel
                .GetSingle(id);

            if (_medicalPersonnel == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.MedicalPersonnel.Delete(_medicalPersonnel);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
