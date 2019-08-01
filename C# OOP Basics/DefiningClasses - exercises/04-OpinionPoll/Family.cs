using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Family
{
    List<Person> people = new List<Person>();

    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public List<Person> GetMoreThan30YearsOld()
    {
        return people.FindAll(p => p.Age > 30);
    }
}
