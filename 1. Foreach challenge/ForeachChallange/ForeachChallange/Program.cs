using ForeachChallange.Models;
using System;
using System.Collections.Generic;

namespace ForeachChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            // Challange 1 //

            //var StringList = new List<string>
            //{
            //    "Anna",
            //    "Bella",
            //    "Carl",
            //    "David"
            //};

            //foreach (var item in StringList)
            //{
            //    Console.WriteLine(item);
            //}


            // Bonus challange //

            var PersonList = new List<Person>
            {
                new Person
                {
                    Firstname = "John",
                    Lastname = "Smith"
                },
                new Person
                {
                    Firstname = "Jane",
                    Lastname = "Adams"
                }
            };

            foreach (var person in PersonList)
            {
                Console.WriteLine($"{person.Firstname} {person.Lastname}");
            }
        }
    }
}
