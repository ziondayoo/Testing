using Dapper;
using System.Data.SqlClient;
using Testing.Interfaces;
using Testing.Models;

namespace Testing.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string Conn;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            Conn = _configuration.GetSection("ConnectionStrings:Testing").Value;
        }
        public string AddEmployee(Employee employee)
        {
            string message = string.Empty;
            var Connection = new SqlConnection(Conn);
            int i = Connection.Execute("Insert into Employee(Id,FirstName,LastName,PhoneNumber) Values(@Id,@FirstName,@LastName,@PhoneNumber)", employee);
            if(i > 0)
            {
                message = "An Employee has been added";
            }
            else
            {
                message = "Error";
            }
            return message;
        }

        public string DeleteEmployee(int Id)
        {
            string message = string.Empty ;
            var Connection = new SqlConnection(Conn);
            int i = Connection.Execute($"Delete from Employee where Id = {Id}");
            if (i > 0)
            {
                message = "An Employee has been deleted";
            }
            else
            {
                message = "Error";
            }
            return message;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employee = new List<Employee>();
            var Connection = new SqlConnection(Conn);
            employee = Connection.Query<Employee>("Select * from Employee").ToList();
            return employee;
        }

        public string UpdateEmployee(string PhoneNumber, int id)
        {
            string message = string.Empty;
            var Connection = new SqlConnection(Conn);
            int i = Connection.Execute($"Update Employee Set PhoneNumber = {PhoneNumber} Where Id = {id}");
            if (i > 0)
            {
                message = "An Employee phone Number has been Updated";
            }
            else
            {
                message = "Error";
            }
            return message;
        }
    }
}
