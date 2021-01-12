using Newtonsoft.Json;
using ServerEntity.Bd;
using System;
using System.Collections.Generic;
using System.Data;
using TaskManagerServer.Bd;

namespace Ws
{
    class Answer
    {
        public string command;
        public int status;
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
            DataTable table = new DataTable();
            //try
            //{
            var jsonCommand = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Console.WriteLine(jsonCommand["command"]);

            if (jsonCommand["command"] == "REG")    // { "command": "REG",   "Email": "@.ru",   "Login": "user4",   "Password": 123  }
            {
                var reg = JsonConvert.DeserializeObject<User>(json);
                //Console.WriteLine("Coomand REG \t Email:{0}\tLogin:{1}\tPassword:{2}", reg.Email, reg.Login, reg.Password);
                Answer ans = new Answer();
                ans.command = "REG";
                ans.status = Command.AddNewUser(reg);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");

            }

            else if (jsonCommand["command"] == "AUTH")
            {
                var auth = JsonConvert.DeserializeObject<User>(json);
                //Console.WriteLine("Coomand AUTH \t \tLogin:{0}\tPassword:{1}", auth.Login, auth.Password);
                Answer ans = new Answer();
                ans.command = "AUTH";
                ans.status = Command.CheckUser(auth);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "DELUSER")
            {
                var delUser = JsonConvert.DeserializeObject<User>(json);
                //Console.WriteLine("Coomand DELUSER \t \tLogin:{0}\tPassword:{1}", delUser.Login, delUser.Password);
                Answer ans = new Answer();
                ans.command = "DELUSER";
                ans.status = Command.DelUser(delUser);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
            else if (jsonCommand["command"] == "INFO")
            {
                var addInfo = JsonConvert.DeserializeObject<UserInfo>(json);
                Answer ans = new Answer();
                ans.command = "INFO";
                ans.status = Command.AddNewInfo(addInfo);
                AnswerBD = JsonConvert.SerializeObject(ans);
                Console.WriteLine($"Answer: {AnswerBD}");
            }
        }


    }
}
