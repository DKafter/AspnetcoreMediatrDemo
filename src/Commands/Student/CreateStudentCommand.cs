using dotnetmediatrdemo.Models;
using MediatR;

namespace dotnetmediatrdemo.Commands.Student;

public class CreateStudentCommand() : IRequest<StudentModel>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}