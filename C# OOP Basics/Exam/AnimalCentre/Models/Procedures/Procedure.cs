using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private Dictionary<string, List<IAnimal>> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new Dictionary<string, List<IAnimal>>();
        }

        protected Dictionary<string, List<IAnimal>> ProcedureHistory
        {
            get { return procedureHistory; }
            private set { procedureHistory = value; }
        }


        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            string result;
            result = $"{this.GetType().Name}" + Environment.NewLine;


            foreach (var animal in ProcedureHistory.Where(x => x.Key == this.GetType().Name))
            {
                foreach (var item in animal.Value)
                {
                    result += $"    Animal type: {item.GetType().Name} - {item.Name} - Happiness: {item.Happiness} - Energy: {item.Energy}";
                }
            }

            return result.TrimEnd();
        }
    }
}
