using System;
using System.Collections.Generic;
using System.Text;

namespace MuTest.Domain
{
    public class Person
    {
        internal Person() { }

        public static Person Default => new Person();

        public int Id { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime? Birthday { get; internal set; }
        public string Email { get; internal set; }
        public string Address { get; internal set; }
        public int Age { get; internal set; }
    }
}
