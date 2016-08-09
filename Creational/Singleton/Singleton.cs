namespace Singleton
{
    using System;
    using System.Collections.Generic;

    //Defines an Instance operation that lets clients access its unique instance. Instance is a class operation.

    public class Database
    {
        // Lock synchronization object
        private static object syncLock = new object();
        private static Database instance;

        //Constructor should be private or protected
        private Database()
        {
            //Logic
            //The constructor must be called once
            Console.WriteLine("Constructor called...");
        }

        public static Database Instance
        {
            get
            {
                //Uses lazy initialization.
                //Support multithreaded applications through
                //Double checked locking - avoids locking each time the method is invoked
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Database();
                        }
                    }
                }

                return instance;
            }
        }

        public void Query(string query)
        {
            Console.WriteLine(query);
        }
    }

    public class Program
    {
        static void Main()
        {
            var db1 = Database.Instance;
            var db2 = Database.Instance;
            var user = new UserController(db1);

            user.GetUsers();

            Console.WriteLine("Same instance: {0}", db1 == db2);
        }
    }

    public class UserController
    {
        private Database db;

        public UserController(Database db)
        {
            this.db = db;
        }

        public IEnumerable<string> GetUsers()
        {
            this.db.Query("SELECT...");

            return new List<string>();
        }
    }
}