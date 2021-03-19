using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSort
{
    class Program
    {
        static void Main(string [] args)
        {
            List<User> listOfUsers = new List<User>()
            {
                new User() {Name = "John Doe", Age = 42},
                new User() {Name = "Jane Doe", Age = 39},
                new User() {Name = "Joe Doe", Age = 13},
            };
            listOfUsers.Sort(CompareUsers);
            foreach (User user in listOfUsers)
                Console.WriteLine(user.Name + ": " + user.Age + " years old");
            Console.ReadLine();
        }
        public static int CompareUsers(User user1, User user2)
        {
            return user1.Age.CompareTo(user2.Age);
        }
    }
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
