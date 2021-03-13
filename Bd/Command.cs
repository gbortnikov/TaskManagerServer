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
                    context.Users.Add(user);
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
                if (context.Users.FirstOrDefault(u => u.Login == user.Login) != null)
                {
                    if (context.Users.FirstOrDefault(u => u.Password == user.Password) != null)
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
                var us = context.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
                try
                {
                    context.Users.Remove(us);
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
                    userInfo.Id = context.Users.FirstOrDefault(u => u.Login == userInfo.Login).Id;
                    context.UserInfos.Add(userInfo);
                    context.SaveChanges();
                    answer = 1;

                    foreach (User user in context.Users.Include(ut => ut.Info))
                    {
                        Console.WriteLine("  Login: {0}  Password: {1} name: {2} surname: {3}",
                                 user.Login, user.Password, user.Info.Name, user.Info.Surname);
                    }
                }
                catch
                {
                    answer = -1;
                }
            }
            return answer;
        }

        static public int AddNewProject(Project proj)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                try
                {
                    context.Projects.Add(proj);
                    context.SaveChanges();
                    answer = 1;

                    foreach (var pr in context.Projects)
                    {
                        Console.WriteLine("  Name: {0} Discription{1}",
                                 pr.Name, pr.Description);
                    }
                }
                catch
                {
                    answer = -1;
                }
            }
            return answer;
        }
        static public int GetListProject(List<string> prList)
        {
            int answer = 1;
            using (var context = new BdContext())
            {
                foreach (var pr in context.Projects)
                {
                    prList.Add(pr.Name);
                }
            }
            return answer;
        }
        static public int GetListUser(List<string> usList)
        {

            int answer = 1;
            using (var context = new BdContext())
            {
                foreach (var user in context.Users)
                {
                    usList.Add(user.Login);
                }
            }
            return answer;
        }

        static public int NewUserProject(string namePr, string login)
        {
            int answer = 1;
            using (var context = new BdContext())
            {
                Project pr = context.Projects.FirstOrDefault(x => x.Name == namePr);
                User us = context.Users.FirstOrDefault(x => x.Login == login);
                pr.Users.Add(us);
                context.Entry(pr).State = EntityState.Modified;
                context.SaveChanges();

                //foreach (var p in context.Projects.Include(x => x.Users)){
                //    Console.WriteLine("Project:{0}", p.Name);
                //    foreach (var u in p.Users.ToList())
                //    {
                //        Console.WriteLine("user:{0}", u.Login);
                //    }
                //    Console.WriteLine("-------");
                //}
            }
            return answer;
        }

        static public int AddNewTask(Taskk task, string projectName, string login)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                try
                {
                    task.User = context.Users.FirstOrDefault(u => u.Login == login);
                task.Project = context.Projects.FirstOrDefault(p => p.Name == projectName);
                context.Taskks.Add(task);
                context.SaveChanges();
                answer = 1;

                //foreach (var ts in context.Taskks.Include(ut => ut.User))
                //{
                //    Console.WriteLine("  Login: {0}  Password: {1} namePJ: {2} Discr: {3}",
                //              ts.UserId, ts.User.Password, ts.Name, ts.Description);
                //}
                }
                catch { answer = -1; }
            }
            return answer;
        }

        static public int GetListMyProject(List<string> myList, string login)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                try
                {
                    foreach (var pr in context.Projects.Include(x => x.Users))
                    {
                        foreach (var u in pr.Users)
                        {
                            if (u.Login == login)
                                myList.Add(pr.Name);
                        }
                    }
                    answer = 1;
                }
                catch { answer = -1; }
            }
            return answer;
        }

        static public int GetListMyTask(List<Taskk> myList, string login)
        {
            int answer = 0;
            using (var context = new BdContext())
            {
                //try
                //{
                    foreach (var pr in context.Taskks.Include(x => x.User))
                    {
                    if (pr.User.Login == login)
                    {
                        pr.User = null;
                        myList.Add(pr);
                    }
                    }
                    answer = 1;
                //}
                //catch { answer = -1; }
            }
            return answer;
        }
    }
}
