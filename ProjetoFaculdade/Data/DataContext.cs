using Microsoft.EntityFrameworkCore;
using ProjetoFaculdade.Models;
using System.Security.Principal;

namespace ProjetoFaculdade.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }
    }
}

