using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class NewUserService : IPersonService
    {

        private List<Person> people = new List<Person>();

        private int idCount = 1;

        public NewUserService()
        {
            CreateUser(name: "Qassem", number: "0725015455", city: "Nässjö");
            CreateUser(name: "Alle", number: "0725014355", city: "Nässjö");
            CreateUser(name: "Ali", number: "0787014355", city: "Nässjö");
            CreateUser(name: "Anna", number: "0723454355", city: "Nässjö");


        }
        //public List<Person> AllUsers()
        //{
        //    return people;
        //}

        public Person CreateUser(string name, string number, string city)
        {

            Person person = new Person() { Id = idCount, Name = name,  Number = number, City = city };
            idCount++;
            people.Add(person);
            return person;
        }

        public bool DeletePerson(int id)
        {
            bool WasRemoved = false;

            foreach (Person item in people)

            {
                if (item.Id==id)
                {
                    people.Remove(item);
                    WasRemoved = true;
                    break;
                }
            }

            return WasRemoved;
        }

        public Person FindPerson(int id, string name, string city)
        {
            foreach (Person item in people)
            {
                if (item.Id == id || item.Name == name || item.City == city)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public bool UpdatePerson(Person person)
        {
            bool wasUpdated = false;

            foreach (Person orginal in people)

            {
                if (orginal.Id == person.Id)
                {
                    orginal.Name = person.Name;
                    orginal.Number = person.Number;
                    orginal.City = person.City;

                    wasUpdated = true;
                    break;
                }
            }

            return wasUpdated;
        }
    }
}
