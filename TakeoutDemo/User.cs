using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeoutDemo
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public static bool Check(Dictionary<string, User> dict, string name, string password)
        {
            return dict != null && dict.ContainsKey(name) && dict[name].Password == password;
        }
    }
}
