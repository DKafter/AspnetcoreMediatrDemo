using dotnetmediatrdemo.Models;
using MediatR;

namespace dotnetmediatrdemo.Queries.Student;

public class GetStudentByIdQuery : IRequest<StudentModel>
{
    public int Id { get; set; }
}