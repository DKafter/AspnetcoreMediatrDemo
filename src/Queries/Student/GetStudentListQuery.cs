using dotnetmediatrdemo.Models;
using MediatR;

namespace dotnetmediatrdemo.Queries.Student;
public class GetStudentListQuery : IRequest<IList<StudentModel>>
{
    
}