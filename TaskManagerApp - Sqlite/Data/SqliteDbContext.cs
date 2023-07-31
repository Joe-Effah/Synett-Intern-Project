using Microsoft.EntityFrameworkCore;

namespace TaskApp.Data;

public sealed class SqliteDbContext:DbContext
{
 public SqliteDbContext(DbContextOptions dbContext ):base(dbContext)
 {

 }   
    public DbSet<TaskModel> taskModels {get;set;} =null!;

}