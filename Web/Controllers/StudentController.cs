using Application.Dtos.StudentDtos;
using Application.Services;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/student")]
	[Controller]
	public class StudentController : Controller
	{
		private readonly IStudentService _studentService;
        private readonly IClassService _classService;
		public StudentController(IStudentService studentService, IClassService classService)
		{
			_studentService = studentService;
            _classService = classService;
		}

        // GET: /<controller>/
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<StudentViewDto>>> Index()
        {
            try
            {
                List<StudentViewDto> students = await _studentService.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET all students containing query name
        [HttpGet("search/{name}")]
        public async Task<ActionResult<List<StudentViewDto>>> GetStudentByName(string name)
        {
            try
            {
                List<StudentViewDto> students = await _studentService.GetStudentsByName(name);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET students in a class
        [HttpGet("class/{classId:int}")]
        public async Task<ActionResult<List<SimpleStudentDto>>> GetStudentInClass(int classId)
        {
            try
            {
                List<SimpleStudentDto> students = await _studentService.GetStudentsInClass(classId);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET all students containing query name in a class
        [HttpGet("class/{classId:int}/search/{name}")]
        public async Task<ActionResult<List<SimpleStudentDto>>> GetStudentsInClassByName(string name, int classId)
        {
            try
            {
                List<SimpleStudentDto> students = await _studentService.GetStudentsInClassByName(classId, name);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET students by id
        [HttpGet("{id:int}", Name = "GetStudent")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            try
            {
                StudentDto student = await _studentService.GetStudentById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Create new student
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] StudentCreateDto studentCreateDto)
        {
            try
            {
                // Check if class exists or not
                if (studentCreateDto.ClassId != null)
                {
                    bool isExist = await _classService.CheckClassExist((int)studentCreateDto.ClassId);
                    if (!isExist)
                        return BadRequest($"Not found class with id: {studentCreateDto.ClassId}");
                }
                StudentDto studentDto = await _studentService.CreateNewStudent(studentCreateDto);
                return Ok(studentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Update student
        [HttpPut]
        public async Task<ActionResult> UpdateStudent([FromBody] StudentUpdateDto studentUpdateDto)
        {
            try
            {
                // Check if class exists or not
                if (studentUpdateDto.ClassId != null)
                {
                    bool isExist = await _classService.CheckClassExist((int)studentUpdateDto.ClassId);
                    if (!isExist)
                        return BadRequest($"Not found class with id: {studentUpdateDto.ClassId}");
                }
                await _studentService.UpdateStudent(studentUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Delete student
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                // Check if student exists or not
                bool isExist = await _studentService.CheckStudentExist(id);
                if (!isExist)
                    return NotFound("Student does not exist");

                await _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }
    }
}

