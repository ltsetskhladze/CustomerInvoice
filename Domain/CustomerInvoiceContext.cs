using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerInvoiceContext : DbContext
    {
        public CustomerInvoiceContext()
        {
        }

        public CustomerInvoiceContext(DbContextOptions<CustomerInvoiceContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLog> InvoiceLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(x => x.Customer)
                    .WithMany(x => x.Invoices)
                    .HasForeignKey(x => x.CustomerId);
            });

            modelBuilder.Entity<InvoiceLog>(entity =>
            {
                entity.HasOne(x => x.Invoice)
                    .WithMany(x => x.InvoiceLogs)
                    .HasForeignKey(x => x.InvoiceId);
            });
            SeetData(modelBuilder);
        }

        private void SeetData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
              new Customer { Id = 1, Firstname = "Luka", Lastname = "Tsetskhladze" },
              new Customer { Id = 2, Firstname = "Nino", Lastname = "Azarashvili" },
              new Customer { Id = 3, Firstname = "Erik", Lastname = "Tonikiani" },
              new Customer { Id = 4, Firstname = "Vakhtang", Lastname = "Horperi" },
              new Customer { Id = 5, Firstname = "Tevdore", Lastname = "Ermalo" });
        }
    }
}