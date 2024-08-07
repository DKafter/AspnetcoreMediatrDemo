using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Queries.Student;
using dotnetmediatrdemo.Repositories.Interfaces;
using MediatR;

namespace dotnetmediatrdemo.Handlers.Student;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentModel>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<StudentModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetByIdAsync(request.Id);
    }
}