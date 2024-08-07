using dotnetmediatrdemo.Commands.Student;
using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Queries.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotnetmediatrdemo.Controllers.Students;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var students = await _mediator.Send(new GetStudentListQuery());
        return Ok(students);
    }
    
    [HttpGet("studentId")]
    public async Task<IActionResult> GetStudentByIdAsync(int studentId)
    {
        var studentDetails = await _mediator.Send(new GetStudentByIdQuery() { Id = studentId });

        return Ok(studentDetails);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudentAsync(StudentModel studentDetails)
    {
        var studentDetail = await _mediator.Send(new CreateStudentCommand()
        {
            Name = studentDetails.Name,
            Age = studentDetails.Age,
            Email = studentDetails.Email,
            Address = studentDetails.Address
        });
        return Ok(studentDetail);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudentAsync(StudentModel studentDetails)
    {
        var isStudentDetailUpdated = await _mediator.Send(new UpdateStudentCommand()
        {
            Id = studentDetails.Id,
            Name = studentDetails.Name,
            Age = studentDetails.Age,
            Email = studentDetails.Email,
            Address = studentDetails.Address
        });
        return Ok(isStudentDetailUpdated);
    }

    [HttpDelete]
    public async Task<int> DeleteStudentAsync(int Id)
    {
        return await _mediator.Send(new DeleteStudentCommand() { Id = Id });
    }
}