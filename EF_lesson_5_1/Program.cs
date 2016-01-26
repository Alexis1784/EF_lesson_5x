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
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@price", 26000);
                var phones = db.Database.SqlQuery<Phone>("SELECT * FROM GetPhonesByPrice (@price)", param);
                foreach (var phone in phones)
                    Console.WriteLine(phone.Name);
                // миграцию при добавлении класса DiscountPhone не производили, контекст данных не меняли:
                // скидка - 15%
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@discount", 15);
                var phones2 = db.Database.SqlQuery<DiscountPhone>("SELECT * FROM GetPriceWithDiscount (@discount)", param2);
                foreach (var p in phones2)
                    Console.WriteLine("{0} - {1}", p.Name, p.Price);
            }
            Console.ReadLine();
        }
    }
}
