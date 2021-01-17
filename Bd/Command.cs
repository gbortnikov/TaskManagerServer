using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskManagerServer.Bd;

namespace ServerEntity.Bd
{
    static class Command
    {
        static public int AddNewUser(User user)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                try
                {
                    context.users.Add(user);
                    context.SaveChanges();
                    answer = 1;
                }
                catch
                {
                    answer = -1;
                }
            }
            return answer;
        }

        static public int CheckUser(User user)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                if (context.users.FirstOrDefault(u => u.Login == user.Login) != null)
                {
                    if (context.users.FirstOrDefault(u => u.Password == user.Password) != null)
                    {
                        Console.WriteLine("{0}{1}", user.Login, user.Email);
                        Console.WriteLine("AUTH OK");
                        answer = 1;
                    }
                    else
                    {
                        Console.WriteLine("AUTH Error: Password");
                        answer = -1;
                    }
                }
                else
                {
                    Console.WriteLine("AUTH Error: Login");
                    answer = -2;
                }
            }
            return answer;
        }

        static public int DelUser(User user)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                var us = context.users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
                try
                {
                    context.users.Remove(us);
                    answer = 1;
                }
                catch
                {
                    answer = -1;
                }
                context.SaveChanges();
            }
            return answer;
        }

        static public int AddNewInfo(UserInfo userInfo)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                try
                {
                    userInfo.Id = context.users.FirstOrDefault(u => u.Login == userInfo.login).Id;
                    context.userInfos.Add(userInfo);
                    context.SaveChanges();
                    answer = 1;

                    foreach (User user in context.users.Include(ut => ut.Info))
                        Console.WriteLine("  Login: {0}  Password: {1} name: {2} surname: {3}",
                                 user.Login, user.Password, user.Info.name, user.Info.surname);
                }
                catch
                {
                    answer = -1;
                }
            }
            return answer;
        }




    }
}
