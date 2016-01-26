using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "Samsung");
                var phones = db.Database.SqlQuery<Phone>("GetPhonesByCompany @name", param);
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1}", p.Name, p.Price);
            }
            Console.ReadLine();
        }
    }
}
