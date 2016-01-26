using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                var comps = db.Database.SqlQuery<Company>("SELECT * FROM Companies");
                foreach (var company in comps)
                    Console.WriteLine(company.Name);

                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%Samsung%");
                var phones = db.Database.SqlQuery<Phone>("SELECT * FROM Phones WHERE Name LIKE @name", param);
                foreach (var phone in phones)
                    Console.WriteLine(phone.Name);

                // вставка
                Console.WriteLine();
                Console.WriteLine("вставка:");
                int numberOfRowInserted = db.Database.ExecuteSqlCommand("INSERT INTO Companies (Name) VALUES ('HTC')");
                comps = db.Database.SqlQuery<Company>("SELECT * FROM Companies");
                foreach (var company in comps)
                    Console.WriteLine(company.Name);
                // обновление
                Console.WriteLine();
                Console.WriteLine("обновление:");
                int numberOfRowUpdated = db.Database.ExecuteSqlCommand("UPDATE Companies SET Name='Nokia' WHERE Id=3");
                comps = db.Database.SqlQuery<Company>("SELECT * FROM Companies");
                foreach (var company in comps)
                    Console.WriteLine(company.Name);
                // удаление
                Console.WriteLine();
                Console.WriteLine("удаление:");
                int numberOfRowDeleted = db.Database.ExecuteSqlCommand("DELETE FROM Companies WHERE Id=3");
                comps = db.Database.SqlQuery<Company>("SELECT * FROM Companies");
                foreach (var company in comps)
                    Console.WriteLine(company.Name);
            }
            Console.ReadLine();
        }
    }
}
