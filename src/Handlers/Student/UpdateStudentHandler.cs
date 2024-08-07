using dotnetmediatrdemo.Commands.Student;
using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Repositories.Interfaces;
using MediatR;

namespace dotnetmediatrdemo.Handlers.Student;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);
        if (student == null)
        {
            return default;
        }
        
        student.Name = request.Name;
        student.Age = request.Age;
        student.Email = request.Email;
        student.Address = request.Address;
        var result = await _studentRepository.UpdateAsync(student);
        return result;
    }
}

