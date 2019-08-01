using BirthdayCelebrations.Contracts;
using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private int age;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public int Food
        {
            get { return food; }
            private set { food = value; }
        }
        public string Birthdate
        {
            get { return birthdate; }
            private set { birthdate = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public string Id { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
