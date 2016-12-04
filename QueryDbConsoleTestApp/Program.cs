using CareCheck.DataAccess;
using System;
using System.Data.Entity;
using System.Linq;

namespace QueryDbConsoleTestApp
{
    public class Program
    {
        public static CareCheckDbContext _context = new CareCheckDbContext();

        static void Main(string[] args)
        {

            //    _context.Database.Log = Console.WriteLine;

            var relativesPatient = _context.Relatives.Where(r => r.Id == 2).Include(p => p.Patients).ToList();

            Console.WriteLine(relativesPatient[0].Patients);

            Console.ReadKey();
        }
    }
}
