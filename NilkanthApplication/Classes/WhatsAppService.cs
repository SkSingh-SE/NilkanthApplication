using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public class WhatsAppService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        private readonly string fromWhatsAppNumber = "+919825873105";
        // Static template for Trip Report
        private static readonly Dictionary<string, WhatsAppTemplate> _templates =
new Dictionary<string, WhatsAppTemplate>(StringComparer.OrdinalIgnoreCase)
{
    // 1️ TRIP REPORT (9 params)
    {
        "trip",
        new WhatsAppTemplate
        {
            Name = "trip",
            BodyText =
@"Dear {{1}}
Here is your Trip Report Details

Date: {{2}}
Batch No.: {{3}}
Site: {{4}}
Driver Name: {{5}}
TM No: {{6}}
Set Cu.M : {{7}}
Act Cu.M : {{8}}

Please Find Attached PDF for More Details

Thank You
{{9}}
Report Generated through Nilkanth ERP System",
            ParameterCount = 9
        }
    },

    // 2️ CONSUMPTION REPORT (5 params)
    {
        "consumption_report",
        new WhatsAppTemplate
        {
            Name = "consumption_report",
            BodyText =
@"Dear {{1}}
Here is your Consumption Report Details

From Date: {{2}}
To Date: {{3}}
Total Cu.M : {{4}}

Please Find Attached PDF for More Details

Thank You
{{5}}
Report Generated through Nilkanth ERP System",
            ParameterCount = 5
        }
    },

    // 3️ PRODUCTION REPORT (5 params)
    {
        "production_report",
        new WhatsAppTemplate
        {
            Name = "production_report",
            BodyText =
@"Dear {{1}}
Here is your Production Report Details

From Date: {{2}}
To Date: {{3}}
Total Cu.M : {{4}}

Please Find Attached PDF for More Details

Thank You
{{5}}
Report Generated through Nilkanth ERP System",
            ParameterCount = 5
        }
    },
    // 4️ DELIVERY CHALLAN (9 params)
{
    "challan",
    new WhatsAppTemplate
    {
        Name = "challan",
        BodyText =
@"Dear {{1}}
Here is your Delivery Challan Details

Date: {{2}}
Challan No.: {{3}}
Batch No.: {{4}}
Driver Name: {{5}}
TM No: {{6}}
Cycle Start Time : {{7}}
Cycle End Time: {{8}}

Please Find Attached PDF for More Details

Thank You
{{9}}
Delivery Challan Generated through Nilkanth ERP System",
        ParameterCount = 9
    }
}
};


        public WhatsAppService(string apiKey, string baseUrl = "https://api.aoc-portal.com")
        {
            _apiKey = apiKey;
            _baseUrl = baseUrl.TrimEnd('/');
        }

        public static WhatsAppTemplate GetTemplate(string templateName)
        {
            if (_templates.TryGetValue(templateName, out var template))
                return template;
            throw new ArgumentException($"Template '{templateName}' not found.");
        }

        // Send WhatsApp message using template
        // SendTemplateWithDocument
        public async Task<bool> SendTemplateWithDocument(
            string mobileNo,
            string templateName,
            string pdfUrl,
            Dictionary<int, string> values,
    string campaignName = "erp-report", string fileName = "Report.pdf")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mobileNo))
                    throw new ArgumentException("Mobile number is required.", nameof(mobileNo));
                if (string.IsNullOrWhiteSpace(templateName))
                    throw new ArgumentException("Template name is required.", nameof(templateName));
                if (string.IsNullOrWhiteSpace(pdfUrl))
                    throw new ArgumentException("PDF URL is required.", nameof(pdfUrl));

                var template = GetTemplate(templateName);

                // Validate and build params array
                var paramList = new List<string>();
                for (int i = 1; i <= template.ParameterCount; i++)
                {
                    if (!values.ContainsKey(i))
                        throw new ArgumentException($"Missing value for parameter {i} in template '{templateName}'.");
                    paramList.Add(values[i] ?? string.Empty);
                }

                // Build request body
                var requestBody = new
                {
                    from = fromWhatsAppNumber,
                    campaignName = campaignName,
                    to = $"+91{mobileNo}",
                    templateName = templateName,
                    type = "template",
                    components = new
                    {
                        body = new
                        {
                            @params = paramList
                        },
                        header = new
                        {
                            type = "document",
                            document = new
                            {
                                link = pdfUrl,
                                filename = fileName
                            }
                        }
                    }
                };

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("apikey", _apiKey);

                    var json = JsonConvert.SerializeObject(
                        requestBody,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // ⭐ IMPORTANT → MagicSMS endpoint
                    var response = await client.PostAsync($"{_baseUrl}/v1/whatsapp", content);

                    var responseText = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            "WhatsApp API Error:\n\n" + responseText,
                            "WhatsApp Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "WhatsApp send failed:\n\n" + ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

     
    }
    public class WhatsAppTemplate
    {
        public string Name { get; set; }
        public string BodyText { get; set; }
        public int ParameterCount { get; set; }
    }
}
