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
    public class ProvincesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public ProvincesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ProvincesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/Provinces
        [HttpGet]
        public IActionResult Get()
        {
            var allProvinces = _unitOfWork.Provinces.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allProvinces));
        }

        // GET: api/Provinces/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var province = _unitOfWork.Provinces
                .GetSingle(id);

            // Return the provinces otherwise return NotFound
            if (province != null)
                return Ok(_mapper.Map<ProvinceViewModel>(province));
            else
                return NotFound();
        }

        // POST: api/Provinces
        [HttpPost]
        public IActionResult Post([FromBody] ProvinceViewModel provinceViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the Province
            var newProvince = _mapper.Map<ProvinceViewModel, Province>(provinceViewModel);

            _unitOfWork.Provinces.Add(newProvince);
            // Commit changes to the database to get ProvinceId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "Provinces", id = newProvince.Id }, newProvince);

            return result;
        }
        
        // PUT: api/Provinces/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProvinceViewModel provinceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the Province to Edit
            var _province = _unitOfWork.Provinces
                .GetSingle(id);

            if (_province == null)
            {
                return NotFound();
            }
            else
            {
                _province.ProvinceName = provinceViewModel.ProvinceName;

                // Put logic to handle inputer, maker, checker
            }

            provinceViewModel = _mapper.Map<Province, ProvinceViewModel>(_province);

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

            // Get the Province to Edit
            var _province = _unitOfWork.Provinces
                .GetSingle(id);

            if (_province == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Provinces.Delete(_province);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
