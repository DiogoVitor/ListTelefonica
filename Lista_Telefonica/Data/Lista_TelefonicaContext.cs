using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lista_Telefonica.Models;

namespace Lista_Telefonica.Data
{
    public class Lista_TelefonicaContext : DbContext
    {
        public Lista_TelefonicaContext (DbContextOptions<Lista_TelefonicaContext> options)
            : base(options)
        {
        }

        public DbSet<Lista_Telefonica.Models.ListaTelModels> ListaTelModels { get; set; } = default!;
    }
}
