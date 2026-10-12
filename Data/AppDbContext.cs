using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTG_Card_API.Models;

namespace MTG_Card_Vault_API.Data
{
    public class AppDbContext : DbContext
    {

         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Card> Cards { get; set; }
    }
}