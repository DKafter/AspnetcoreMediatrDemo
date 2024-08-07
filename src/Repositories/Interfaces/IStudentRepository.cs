using dotnetmediatrdemo.Models;

namespace dotnetmediatrdemo.Repositories.Interfaces;

public interface IStudentRepository
{
    public Task<IList<StudentModel>> GetAllAsync();
    public Task<StudentModel> GetByIdAsync(int id);
    public Task<StudentModel> AddAsync(StudentModel student);
    public Task<int> UpdateAsync(StudentModel student);
    public Task<StudentModel> DeleteAsync(int id);
}