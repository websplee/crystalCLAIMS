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
    public class HCPDrugsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public HCPDrugsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<HCPDrugsController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/HCPDrugs
        [HttpGet]
        public IActionResult Get()
        {
            var allHCPDrugs = _unitOfWork.HCPDrugs.GetAll();
            return Ok(_mapper.Map<IEnumerable<HCPDrugViewModel>>(allHCPDrugs));
        }

        // GET: api/HCPDrugs/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hCPDrug = _unitOfWork.HCPDrugs
                .GetSingle(id);

            // Return the HCPDrug otherwise return NotFound
            if (hCPDrug != null)
                return Ok(_mapper.Map<HCPDrugViewModel>(hCPDrug));
            else
                return NotFound();
        }

        // GET: api/HCPDrugs/GetByHCPId/5
        [HttpGet("{id}")]
        public IActionResult GetByHCPId(int id)
        {
            var hCPDrugs = _unitOfWork.HCPDrugs
                .FindBy(cd => cd.HealthcareProviderId == id);

            // Return the HCP otherwise return NotFound
            if (hCPDrugs != null)
                return Ok(_mapper.Map<IEnumerable<HCPDrugViewModel>>(hCPDrugs));
            else
                return NotFound();
        }

        // POST: api/HCPDrugs
        [HttpPost]
        public IActionResult Post([FromBody] HCPDrugViewModel hCPDrugViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the HCPDrug
            var newHCPDrug = _mapper.Map<HCPDrugViewModel, HCPDrug>(hCPDrugViewModel);

            _unitOfWork.HCPDrugs.Add(newHCPDrug);
            // Commit changes to the database to get DistrictId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "HCPDrugs", id = newHCPDrug.Id }, newHCPDrug);

            return result;
        }

        // PUT: api/HCPDrugs/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HCPDrugViewModel hCPDrugViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the HCPDrug to Edit
            var _hCPDrug = _unitOfWork.HCPDrugs
                .GetSingle(id);

            if (_hCPDrug == null)
            {
                return NotFound();
            }
            else
            {
                _hCPDrug.Price = hCPDrugViewModel.Price;

                // Put logic to handle inputer, maker, checker
            }
            hCPDrugViewModel = _mapper.Map<HCPDrug, HCPDrugViewModel>(_hCPDrug);

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Get the HCPDrug to Edit
            var hCPDrug = _unitOfWork.HCPDrugs
                .GetSingle(id);

            if (hCPDrug == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.HCPDrugs.Delete(hCPDrug);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
