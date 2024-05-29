using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal class Bee
    {
        public string Job { get; private set; }
        public Bee(string job)
        {
            Job = job;
        }
        public virtual float CostPerShift {get; }
        public void WorkTheNextShift()
        {
            if (HoheyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }
        protected virtual void DoJob()
        {

        }
    }
}
