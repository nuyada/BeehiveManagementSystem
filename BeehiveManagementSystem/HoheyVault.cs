using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoheyVault
    {
        const float NECTAR_CONVERSION_RATIO = .19f;
        const float LOW_LEVEL_WARNING = 10f;
        private static float nectar = 100f;
        private static float honey = 25f;
        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }
        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;

            }
            else return false;
        }
        public static void CollectNectar(float amount)
        {
            if (amount > 0f) nectar += amount;
        }
        public static string StatusReport
        {
            get
            {
                string status = $"{honey:0.0} units of noney\n" + $"{nectar:0.0} units of nectar";
                string warning = "";
                if (honey < LOW_LEVEL_WARNING) warning += "\nLow honey - Add a honey manufacture";
                if (nectar < LOW_LEVEL_WARNING) warning+= "\nLow nectar - Add a nectar manufacture";
                return status + warning;
            }
        
        }

    }
}
