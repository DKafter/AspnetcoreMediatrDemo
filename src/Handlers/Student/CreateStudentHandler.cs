using dotnetmediatrdemo.Commands.Student;
using dotnetmediatrdemo.Data;
using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Repositories.Interfaces;
using MediatR;

namespace dotnetmediatrdemo.Handlers.Student;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentModel>
{
    private readonly IStudentRepository _studentRepository;

    public CreateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<StudentModel> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new StudentModel()
        {
            Name = request.Name,
            Age = request.Age,
            Email = request.Email,
            Address = request.Address
        };
        
        var result = await _studentRepository.AddAsync(student);
        return result;
    }
}