using dotnetmediatrdemo.Commands.Student;
using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Repositories.Interfaces;
using MediatR;

namespace dotnetmediatrdemo.Handlers.Student;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetAllAsync();
        if (student == null)
        {
            return default;
        }
        
        var result = await _studentRepository.DeleteAsync(request.Id);
        return result.Id;
    }
}