using ServerEntity.Bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws;

namespace ServerEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            WebSocket web = new WebSocket();
            web.WSInit(8888);

            //using (var context = new BdContext())
            //{
            //    var user = new User()
            //    {
            //        Email = "@@",
            //        Login = "qwerty",
            //        Password = "123"
            //    };
            //    context.users.Add(user);
            //    context.SaveChanges();
            //}
            Console.ReadKey();

        }
    }
}
