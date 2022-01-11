using Person.Domain.Common;
using System;

namespace Person.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
