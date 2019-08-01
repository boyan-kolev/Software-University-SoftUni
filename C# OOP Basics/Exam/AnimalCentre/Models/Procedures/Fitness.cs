using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= 3;
            animal.Energy += 10;
            if (this.ProcedureHistory.ContainsKey(this.GetType().Name) == false)
            {
                this.ProcedureHistory.Add(this.GetType().Name, new List<IAnimal>());
            }

            this.ProcedureHistory[this.GetType().Name].Add(animal);
        }
    }
}
