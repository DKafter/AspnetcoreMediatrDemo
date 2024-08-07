using dotnetmediatrdemo.Data;
using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnetmediatrdemo.Repositories.Student;

public class StudentRepository : IStudentRepository
{
    private readonly DataContext _context;
    public StudentRepository(DataContext context) => _context = context;
    public async Task<IList<StudentModel>> GetAllAsync()
    {
        var students = await _context.Students.ToListAsync();
        return students;
    }

    public async Task<StudentModel> GetByIdAsync(int id)
    {
        var student = await _context.Students.SingleOrDefaultAsync(t => t.Id == id);
        return student;
    }

    public async Task<StudentModel> AddAsync(StudentModel student)
    {
        var result = await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> UpdateAsync(StudentModel student)
    {
        _context.Students.Update(student);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public async Task<StudentModel> DeleteAsync(int id)
    {
        var student = await _context.Students.SingleOrDefaultAsync(t => t.Id == id);
        var result = _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
}