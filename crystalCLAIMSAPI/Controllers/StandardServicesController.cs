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
    public class StandardServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public StandardServicesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<StandardServicesController> logger, IEmailer emailer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/StandardServices
        [HttpGet]
        public IActionResult Get()
        {
            var allStandardServices = _unitOfWork.StandardServiceProvided.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClaimViewModel>>(allStandardServices));
        }

        // GET: api/StandardServices/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var standardService = _unitOfWork.StandardServiceProvided
                .GetSingle(id);

            // Return the standardServices otherwise return NotFound
            if (standardService != null)
                return Ok(_mapper.Map<StandardServiceProvidedViewModel>(standardService));
            else
                return NotFound();
        }

        // POST: api/StandardServices
        [HttpPost]
        public IActionResult Post([FromBody] StandardServiceProvidedViewModel standardServiceProvidedViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Create the StandardService
            var newStandardService = _mapper.Map<StandardServiceProvidedViewModel, StandardServiceProvided>(standardServiceProvidedViewModel);

            _unitOfWork.StandardServiceProvided.Add(newStandardService);
            // Commit changes to the database to get StandardServiceId
            _unitOfWork.SaveChanges();

            CreatedAtRouteResult result = CreatedAtRoute("Get", new { controller = "StandardServices", id = newStandardService.Id }, newStandardService);

            return result;
        }

        // PUT: api/StandardServices/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StandardServiceProvidedViewModel standardServiceProvidedViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the StandardService to Edit
            var _standardService = _unitOfWork.StandardServiceProvided
                .GetSingle(id);

            if (_standardService == null)
            {
                return NotFound();
            }
            else
            {
                _standardService.Code = standardServiceProvidedViewModel.Code;
                _standardService.Comment = standardServiceProvidedViewModel.Comment;
                _standardService.Description = standardServiceProvidedViewModel.Description;
                _standardService.LongName = standardServiceProvidedViewModel.LongName;
                _standardService.ShortName = standardServiceProvidedViewModel.ShortName;

                // Put logic to handle inputer, maker, checker
            }

            standardServiceProvidedViewModel = _mapper.Map<StandardServiceProvided, StandardServiceProvidedViewModel>(_standardService);

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

            // Get the StandardService to Edit
            var _standardService = _unitOfWork.StandardServiceProvided
                .GetSingle(id);

            if (_standardService == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.StandardServiceProvided.Delete(_standardService);
                _unitOfWork.SaveChanges();
                // Put logic to handle inputer, maker, checker
            }

            return new NoContentResult();
        }
    }
}
