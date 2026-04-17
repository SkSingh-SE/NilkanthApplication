using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilkanthApplication.Classes.DTO
{
    public class ConsumptionReportResult
    {
        public string FilePath { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string TotalCuM { get; set; }
    }
}
