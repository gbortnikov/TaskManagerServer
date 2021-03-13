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

            //using (var db = new BdContext())
            //{
            //    db.Database.Connection.Open();
            //}
            Console.ReadKey();

        }
    }
}
