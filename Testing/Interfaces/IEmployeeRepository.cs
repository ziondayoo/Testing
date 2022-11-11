using Testing.Models;

namespace Testing.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployee();
        public string AddEmployee(Employee employee);
        public string DeleteEmployee(int Id);
        public string UpdateEmployee(string PhoneNumber, int id);

    }
}
