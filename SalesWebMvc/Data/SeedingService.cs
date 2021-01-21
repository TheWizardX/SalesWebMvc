using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if(_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "mariagreen@gmail.com", new DateTime(1998, 5, 11), 4000.0, d1);
            Seller s3 = new Seller(3, "Gold Dust", "gdust@gmail.com", new DateTime(1993, 2, 25), 900.0, d3);
            Seller s4 = new Seller(4, "John Field", "jfield@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Seller s5 = new Seller(5, "Patt Flea", "patt_flea_95@gmail.com", new DateTime(1995, 8, 01), 2500.0, d1);
            Seller s6 = new Seller(6, "Mick Snagger", "micky_s@gmail.com", new DateTime(1989, 4, 21), 6000.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 10, 25), 22000, SaleStatus.Cancelled, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 11, 25), 54999, SaleStatus.Pending, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 12, 25), 11111, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2019, 11, 25), 1000, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 01, 25), 11000, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 10), 12000, SaleStatus.Billed, s6);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 01), 11000, SaleStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2,r3, r4, r5, r6, r7, r8);

            _context.SaveChanges();
        }
    }
}
