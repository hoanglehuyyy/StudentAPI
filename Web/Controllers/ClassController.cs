using Application.Dtos.ClassDtos;
using Application.Services;
using Application.Services.Interfaces;
using Logging.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/class")]
    [Controller]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly ILogging _logger;

        public ClassController(IClassService classService, ILogging logger)
        {
            _classService = classService;
            _logger = logger;
        }

        // GET: /<controller>/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClassViewDto>>> Index()
        {
            try
            {
                List<ClassViewDto> classes = await _classService.GetAllClasses();
                _logger.Log("Get all classes", "");
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET all classes containing query name
        [HttpGet("search/{name}", Name = "GetClasses")]
        public async Task<ActionResult<List<ClassViewDto>>> GetClassesByName(string name)
        {
            try
            {
                List<ClassViewDto> classes = await _classService.GetClassesByName(name);
                _logger.Log($"Get all classes contains: {name}", "");
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET class by class id
        [HttpGet("{id:int}", Name = "GetClass")]
        public async Task<ActionResult<ClassDto>> GetClassById(int id)
        {
            try
            {
                ClassDto @class = await _classService.GetClassById(id);
                _logger.Log($"Get class with Id {id}", "");
                return Ok(@class);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Create new class
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<ClassDto>> CreateClass([FromBody] ClassCreateDto classCreateDto)
        {
            try
            {
                // Check if class name conflict or not
                bool isConflict = await _classService.CheckClassNameConflict(classCreateDto.ClassName);
                if (isConflict == true)
                {
                    _logger.Log($"Class {classCreateDto.ClassName} already exists !", "error");
                    return BadRequest($"Class {classCreateDto.ClassName} already exists !");
                }
                else
                {
                    _logger.Log($"Create new class", "");
                    ClassDto classDto = await _classService.CreateNewClass(classCreateDto);
                    return classDto;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Update class
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<ClassDto>> UpdateClass([FromBody] ClassUpdateDto classUpdateDto)
        {
            try
            {
                // Check if class exists or not
                bool isExist = await _classService.CheckClassExist(classUpdateDto.Id);

                // Return NotFound() if class does not exist
                if (!isExist)
                {
                    _logger.Log($"Not found class with Id {classUpdateDto.Id}", "error");
                    return NotFound("Class does not exist");
                }

                // Check if class name conflicts or not
                bool isConflict = await _classService.CheckClassNameConflict(classUpdateDto.ClassName, classUpdateDto.Id);

                // Return BadRequest() if class name is conflicting
                if (isConflict)
                {
                    _logger.Log($"Class {classUpdateDto.ClassName} already exists", "error");
                    return BadRequest($"Class {classUpdateDto.ClassName} already exists");
                }

                _logger.Log($"Update class with Id {classUpdateDto.Id}", "");
                await _classService.UpdateClass(classUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Data);
            }
        }

        // Delete class
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClassDto>> DeleteClass(int id)
        {
            try
            {
                // Check if class exists or not
                bool isExist = await _classService.CheckClassExist(id);

                // Return NotFound() if class does not exist
                if (!isExist)
                {
                    _logger.Log($"Not found class with Id {id}", "error");
                    return NotFound("Class does not exist");
                }

                _logger.Log($"Delete class with Id {id}", "");
                await _classService.DeleteClass(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }
    }
}

