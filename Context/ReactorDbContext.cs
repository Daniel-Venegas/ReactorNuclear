using Microsoft.EntityFrameworkCore;
using ReactorNuclear.Model;

namespace ReactorNuclear.Context
{
    public class ReactorDbContext : DbContext
    {
        public ReactorDbContext(DbContextOptions<ReactorDbContext> options) : base(options) 
        {

        }
        public DbSet<Estado_Reactor> EstadoReactors { get; set; }
        

    }
}
