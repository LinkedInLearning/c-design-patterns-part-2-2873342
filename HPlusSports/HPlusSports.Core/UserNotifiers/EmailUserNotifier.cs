using System;

namespace HPlusSports.Core {
public class EmailUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine($"Notified User {id} By Email");
        }
    }
}