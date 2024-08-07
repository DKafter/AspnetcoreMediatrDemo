using dotnetmediatrdemo.Models;
using MediatR;

namespace dotnetmediatrdemo.Commands.Student;

public class DeleteStudentCommand: IRequest<int>
{
    public int Id { get; set; }
}