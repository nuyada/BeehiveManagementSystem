using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen: Bee
    {
        private Bee[] workers = [];
        private float eggs;
        private float unassignedWorkers =3;
        const float EGGS_PER_SHIFT = 0.45f;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        public string StatusReport { get; private set; }
        public Queen(): base("Queen")
        {
            AssingBee("Nectar Collector");
            AssingBee("Egg Care");
            AssingBee("Honey Manufacturer");
        }
        public void AssingBee(string job )
        {
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufactures());
                    break;
               
            }
            UpdateStatusReport();

        }
        public void CareForEggs(float eggsToConvert)
        {
           if (eggs>= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }
        private void UpdateStatusReport()
        {
            StatusReport = $"Value report:\n{HoheyVault.StatusReport}\n" + $"\nEgg count:{eggs:0.0}\nUnassugned worker: {unassignedWorkers:0.0}\n" + $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" + $"\n{WorkerStatus("Egg Care")}\nTotal Workers: {workers.Length}";
        }
        public void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach(Bee worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoheyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
        }
        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach(Bee worker in workers)
            {
                if (worker.Job == job) count++;
            }
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }
    }
}
