using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cakekue_J94824.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Cakekue_J94824.Data;

namespace Cakekue_J94824.Data
{
    public class Cakekue_J94824Context : IdentityDbContext<ApplicationUser>
    {
        public Cakekue_J94824Context (DbContextOptions<Cakekue_J94824Context> options)
            : base(options)
        {
        }

        public DbSet<Cakekue_J94824.Models.Product> Product { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
