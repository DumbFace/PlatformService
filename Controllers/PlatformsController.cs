using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOS;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformsReadDTOs>> GetPlatforms()
        {
            Console.WriteLine("--> Getting PLatforms...");

            var platforms = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformsReadDTOs>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformsReadDTOs> GetPlatformById(int id)
        {
            var platform = _repository.GetPlatformById(id);
            if (platform != null)
            {
                return (_mapper.Map<PlatformsReadDTOs>(platform));
            }
            return NotFound();
        } 
        
        [HttpPost]
        public ActionResult<PlatformsReadDTOs> CreatePlatform(PlatformsCreateDTOs platformsCreateDTOs)
        {
            var platformModel = _mapper.Map<Platform>(platformsCreateDTOs);

            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();

            var platformReadDTO = _mapper.Map<PlatformsReadDTOs>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDTO.Id}, platformReadDTO);
        }
    }
}