using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilkanthApplication.Classes.DTO
{
    public class TripReportResult
    {
        public string FilePath { get; set; }
        public string CompanyName { get; set; }
        public decimal TotalActualCuM { get; set; }

        // WhatsApp fields
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public string BatchNo { get; set; }
        public string Site { get; set; }
        public string DriverName { get; set; }
        public string TruckNo { get; set; }
        public string SetCuM { get; set; }
        public string ActCuM { get; set; }
    }
}
