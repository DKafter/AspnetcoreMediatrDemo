using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Queries.Student;
using dotnetmediatrdemo.Repositories.Interfaces;
using MediatR;

namespace dotnetmediatrdemo.Handlers.Student;

public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, IList<StudentModel>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IList<StudentModel>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetAllAsync();
    }
}