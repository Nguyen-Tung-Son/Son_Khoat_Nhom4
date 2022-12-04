using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nhom4.Models;

namespace nhom4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<nhom4.Models.Danhsachkhachhang> Danhsachkhachhang { get; set; } = default!;

        public DbSet<nhom4.Models.DanhsachNCC> DanhsachNCC { get; set; } = default!;

        public DbSet<nhom4.Models.Danhsachnhanvien> Danhsachnhanvien { get; set; } = default!;
    }
}
