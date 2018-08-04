using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProjectWithMongoDB.Model
{
    class Person
    {
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
            DateCreated = DateTime.Now;
        }

        public ObjectId Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}
