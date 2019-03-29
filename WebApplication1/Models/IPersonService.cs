using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public interface IPersonService
    {
        //C
        Person CreateUser(string name, string number, string city);
        //R 
        Person FindPerson(int id, string name, string city);
        List<Person> GetPeople();
        //U
        bool UpdatePerson(Person person);
        //D
        bool DeletePerson(int id);
    }
}
