using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilkanthApplication.Classes.DTO
{
    public class DeliveryChallanResult
    {
        public string FilePath { get; set; }

        public string ClientName { get; set; }
        public string Date { get; set; }
        public string ChallanNo { get; set; }
        public string BatchNo { get; set; }
        public string DriverName { get; set; }
        public string TruckNo { get; set; }
        public string CycleStart { get; set; }
        public string CycleEnd { get; set; }
        public string CompanyName { get; set; }
    }
}
