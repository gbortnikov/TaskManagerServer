using Newtonsoft.Json;
using ServerEntity.Bd;
using System;
using System.Collections.Generic;
using TaskManagerServer.Bd;

namespace Ws
{
    class Answer
    {
        public string command;
        public int status;
    }
    class AnswerList<T> : Answer
    {
        public List<T> dataList;
    }
    class ProcessingResponsesWS
    {

        private string answerBD;
        public string AnswerBD { get { return answerBD; } set { answerBD = value; } }

        /// <summary>
        /// обработка принятого сообщения
        /// </summary>
        /// <param name="json"></param>
        public ProcessingResponsesWS(string json)
        {
            var jsonCommand = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Console.WriteLine(jsonCommand["command"]);
  

            if (jsonCommand["command"] == "REG")    // { "command": "REG",   "Email": "@.ru",   "Login": "user4",   "Password": 123  }
            {
                var reg = JsonConvert.DeserializeObject<User>(json);
                Answer ans = new Answer();
                ans.command = "REG";
                ans.status = Command.AddNewUser(reg);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");

            }

            else if (jsonCommand["command"] == "AUTH")
            {
                var auth = JsonConvert.DeserializeObject<User>(json);
                Answer ans = new Answer();
                ans.command = "AUTH";
                ans.status = Command.CheckUser(auth);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "DELUSER")               // Удалить User
            {
                var delUser = JsonConvert.DeserializeObject<User>(json);
                Answer ans = new Answer();
                ans.command = "DELUSER";
                ans.status = Command.DelUser(delUser);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "INFO")                  //Добавить информацию о User
            {
                var addInfo = JsonConvert.DeserializeObject<UserInfo>(json);
                Answer ans = new Answer();
                ans.command = "INFO";
                ans.status = Command.AddNewInfo(addInfo);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "NEWPROJECT")            //Добавить новый Проект
            {
                var addProj = JsonConvert.DeserializeObject<Project>(json);
                Answer ans = new Answer();
                ans.command = "NEWPROJECT";
                ans.status = Command.AddNewProject(addProj);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "GETLISTPROJECT")        //Получить список Projects
            {
                AnswerList<string> ans = new AnswerList<string>();
                ans.command = "GETLISTPROJECT";
                List<string> prList = new List<string>();
                ans.status = Command.GetListProject(prList);
                ans.dataList = prList;
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "GETLISTUSER")           //Получить список Users
            {
                AnswerList<string> ans = new AnswerList<string>();
                ans.command = "GETLISTUSER";
                List<string> usList = new List<string>();
                ans.status = Command.GetListUser(usList);
                ans.dataList = usList;
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "NEWUSERINPROJECT")      //Добавление пользователя к проекту
            {
                Answer ans = new Answer();
                ans.command = "NEWUSERINPROJECT";
                List<string> usList = new List<string>();
                ans.status = Command.NewUserProject(jsonCommand["selectedProject"], jsonCommand["selectedUser"]);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }


            else if (jsonCommand["command"] == "NEWTASK")
            {
                var addTask = JsonConvert.DeserializeObject<Taskk>(json);
                Answer ans = new Answer();
                ans.command = "NEWTASK";
                ans.status = Command.AddNewTask(addTask, jsonCommand["projectName"], jsonCommand["login"]);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "GETMYLISTPROJECT")           //Получить список моих проектов
            {
                AnswerList<string> ans = new AnswerList<string>();
                ans.command = "GETMYLISTPROJECT";
                List<string> myList = new List<string>();
                ans.status = Command.GetListMyProject(myList, jsonCommand["login"]);
                ans.dataList = myList;
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "GETMYLISTTASK")           //Получить список моих проектов
            {
                AnswerList<Taskk> ans = new AnswerList<Taskk>();
                ans.command = "GETMYLISTTASK";
                List<Taskk> myList = new List<Taskk>();
                ans.status = Command.GetListMyTask(myList, jsonCommand["login"]);
                ans.dataList = myList;
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }




        }


    }
}
