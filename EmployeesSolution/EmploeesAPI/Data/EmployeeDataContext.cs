using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Data;

public class EmployeesDataContext : DbContext
{
    public EmployeesDataContext(DbContextOptions options) : base(options)
    {
    }



    public DbSet<EmployeeEntity> Employees { get; set; }
}
