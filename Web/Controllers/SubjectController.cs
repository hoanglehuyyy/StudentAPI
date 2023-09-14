using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.StudentDtos;
using Application.Dtos.SubjectDtos;
using Application.Services;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/subject")]
    [Controller]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<List<SimpleSubjectDto>>> Index()
        {
            try
            {
                List<SimpleSubjectDto> students = await _subjectService.GetAllSubject();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // GET subject by subject code
        [HttpGet("{code}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectByCode(string code)
        {
            try
            {
                SubjectDto subjectDto = await _subjectService.GetSubjectByCode(code);
                return Ok(subjectDto);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Create new subject
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> CreateSubject([FromBody] SubjectCreateDto subjectCreateDto)
        {
            try
            {
                SubjectDto subjectDto = await _subjectService.CreateNewSubject(subjectCreateDto);
                return Ok(subjectDto);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Update subject
        [HttpPut]
        public async Task<ActionResult> UpdateSubject([FromBody] SubjectUpdateDto subjectUpdateDto)
        {
            try
            {
                await _subjectService.UpdateSubject(subjectUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }

        // Delete subject
        [HttpDelete]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            try
            {
                // Check if subject exists or not
                bool isExist = await _subjectService.CheckSubjectExist(id);
                if (!isExist)
                    return NotFound("Subject does not exist");
                await _subjectService.DeleteSubject(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Data);
            }
        }
    }
}

