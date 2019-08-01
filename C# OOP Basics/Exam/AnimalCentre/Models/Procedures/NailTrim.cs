using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime > procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= 7;
            if (this.ProcedureHistory.ContainsKey(this.GetType().Name) == false)
            {
                this.ProcedureHistory.Add(this.GetType().Name, new List<IAnimal>());
            }

            this.ProcedureHistory[this.GetType().Name].Add(animal);
        }
    }
}
