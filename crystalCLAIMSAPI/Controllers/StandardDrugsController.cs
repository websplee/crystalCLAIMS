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
    public class StandardDrugsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public StandardDrugsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<StandardDrugsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/StandardDrugs
        [HttpGet]
        public IActionResult Get()
        {
            var allStandardDrugs = _unitOfWork.StandardDrugs.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allStandardDrugs));
        }

        // GET: api/StandardDrugs/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var standardDrug = _unitOfWork.StandardDrugs
                .GetSingle(id);

            // Return the standardDrugs otherwise return NotFound
            if (standardDrug != null)
                return Ok(_mapper.Map<StandardDrugViewModel>(standardDrug));
            else
                return NotFound();
        }

        // POST: api/StandardDrugs
        [HttpPost]
        public IActionResult Post([FromBody] StandardDrugViewModel standardDrugViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the StandardDrug
            var newStandardDrug = _mapper.Map<StandardDrugViewModel, StandardDrug>(standardDrugViewModel);

            _unitOfWork.StandardDrugs.Add(newStandardDrug);
            // Commit changes to the database to get StandardDrugId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "StandardDrugs", id = newStandardDrug.Id }, newStandardDrug);

            return result;
        }

        // PUT: api/StandardDrugs/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StandardDrugViewModel standardDrugViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the StandardDrug to Edit
            var _standardDrug = _unitOfWork.StandardDrugs
                .GetSingle(id);

            if (_standardDrug == null)
            {
                return NotFound();
            }
            else
            {
                _standardDrug.Code = standardDrugViewModel.Code;
                _standardDrug.Comment = standardDrugViewModel.Comment;
                _standardDrug.Description = standardDrugViewModel.Description;
                _standardDrug.LongName = standardDrugViewModel.LongName;
                _standardDrug.ShortName = standardDrugViewModel.ShortName;

                // Put logic to handle inputer, maker, checker
            }

            standardDrugViewModel = _mapper.Map<StandardDrug, StandardDrugViewModel>(_standardDrug);

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

            // Get the StandardDrug to Edit
            var _standardDrug = _unitOfWork.StandardDrugs
                .GetSingle(id);

            if (_standardDrug == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.StandardDrugs.Delete(_standardDrug);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
