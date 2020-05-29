using Jerry.Prateice.EF.DataBase;
using System;

namespace Jerry.Prateice.EF.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var _context = new LocalDbContext();
            //var model = new DataBase.Entities.T_Student
            //{
            //    Address = "这是我家的地址",
            //    ClassId = 1,
            //    Name = "刘德华",
            //    Sex = 1
            //};
            //db.T_Student.Add(model);
            //Console.ReadKey();
            //db.SaveChanges();
            //将RowVersion标志原来的值变更为新的值


            Console.ReadKey();
        }
    }
}
