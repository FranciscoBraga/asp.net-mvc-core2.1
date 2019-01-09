using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
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
            if (_context.Departament.Any() || _context.SalesRecord.Any() || _context.Seller.Any())
            {
                return;
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            Seller s1 = new Seller(1, "Alberto Texeira", "at@gmail.com", new DateTime(1950, 4, 21), 2100, d1);
            Seller s2 = new Seller(2, "Grato Texeira Filho", "atf@gmail.com", new DateTime(1978, 6, 10), 1600, d2);
            Seller s3 = new Seller(3, "Luiz Texeira Neto", "atn@gmail.com", new DateTime(2000, 8, 1), 1100, d3);
            Seller s4 = new Seller(4, "Ana Mello ", "am@gmail.com", new DateTime(2000, 8, 1), 1100, d4);
            Seller s5 = new Seller(5, "Alberto Texeira", "at@gmail.com", new DateTime(1950, 4, 21), 2100, d1);
            Seller s6 = new Seller(6, "Grato Texeira Filho", "atf@gmail.com", new DateTime(1978, 6, 10), 1600, d2);
            Seller s7 = new Seller(7, "Luiz Texeira Neto", "atn@gmail.com", new DateTime(2000, 8, 1), 1100, d3);
            Seller s8 = new Seller(8, "Ana Mello ", "am@gmail.com", new DateTime(2000, 8, 1), 1100, d4);


            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 2, 12), 5000.00, SalesStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 4, 10), 3200.00, SalesStatus.Peding, s1);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 5, 11), 1000.00, SalesStatus.Canceled, s1);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018, 6, 9), 3200.00, SalesStatus.Peding, s2);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2018, 6, 12), 5000.00, SalesStatus.Billed, s3);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2018, 5, 10), 3200.00, SalesStatus.Peding, s3);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2018, 2, 11), 1000.00, SalesStatus.Canceled, s3);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2018, 2, 9), 3200.00, SalesStatus.Peding, s3);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2018, 1, 12), 5000.00, SalesStatus.Billed, s6);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2018, 10, 10), 3200.00, SalesStatus.Peding, s7);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2018, 11, 11), 1000.00, SalesStatus.Canceled, s8);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2018, 12, 9), 3200.00, SalesStatus.Peding, s8);

            SalesRecord sr13 = new SalesRecord(13, new DateTime(2018, 10, 12), 5000.00, SalesStatus.Billed, s4);
            SalesRecord sr14 = new SalesRecord(14, new DateTime(2018, 10, 10), 3200.00, SalesStatus.Peding, s4);
            SalesRecord sr15 = new SalesRecord(15, new DateTime(2018, 10, 11), 1000.00, SalesStatus.Canceled, s5);
            SalesRecord sr16 = new SalesRecord(16, new DateTime(2018, 10, 9), 3200.00, SalesStatus.Peding, s5);


            _context.Departament.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);

            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16);
        }

    }
}
