using LibraryApp.Mongo.Interfaces;
using LibraryApp.Mongo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace LibraryApp.Mongo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NoteContext _context = null;

        public EmployeeRepository(NoteContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(Employee item)
        {
            try
            {
                await _context.Employees.InsertOneAsync(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Employees.Find(e => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var filter = Builders<Employee>.Filter.Eq("Id", id);

            try
            {
                return await _context.Employees.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
