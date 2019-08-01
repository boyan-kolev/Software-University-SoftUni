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

    public Person GetOldestMember()
    {
        return people.Find(p => p.Age == people.Max(a => a.Age));
    }
}
