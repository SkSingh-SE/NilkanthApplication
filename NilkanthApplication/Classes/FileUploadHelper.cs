using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class FileUploadHelper
{
    public static async Task<string> UploadFileAsync(string filePath, string uploadUrl)
    {
        using (var client = new HttpClient())
        using (var form = new MultipartFormDataContent())
        using (var fileStream = File.OpenRead(filePath))
        {
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
            form.Add(fileContent, "file", Path.GetFileName(filePath));

            
            var response = await client.PostAsync(uploadUrl, form);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);
            return obj["publicUrl"]?.ToString(); // Adjust key as per your API
        }
    }
    public static async Task<string> UploadFile(string filePath, string uploadUrl)
    {
        try
        {
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            //  Validate file
            if (!File.Exists(filePath))
                throw new Exception("File not found.");

            using (var client = new HttpClient())
            using (var form = new MultipartFormDataContent())
            using (var fileStream = File.OpenRead(filePath))
            {
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                form.Add(fileContent, "document", Path.GetFileName(filePath));
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                //  Call API
                var response = await client.PostAsync(uploadUrl, form);

                //  Handle API error response safely
                if (!response.IsSuccessStatusCode)
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        $"Upload failed.\nStatus: {response.StatusCode}\nDetails: {errorBody}",
                        "Upload Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return null;
                }

                //  Parse JSON safely
                var json = await response.Content.ReadAsStringAsync();

                try
                {
                    var result = JsonConvert.DeserializeObject<UploadResponse>(json);
                    return result.Url;
                }
                catch
                {
                    MessageBox.Show(
                        "Upload succeeded but server returned unexpected response.",
                        "Parse Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return null;
                }
            }
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                "Server not reachable.\n" + ex.Message,
                "Network Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (TaskCanceledException)
        {
            MessageBox.Show(
                "Upload timed out. Check internet connection.",
                "Timeout",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Unexpected error:\n" + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        return null;
    }
    public class UploadResponse
    {
        public bool Success { get; set; }
        public string Url { get; set; }
        public string Filename { get; set; }
        public long Size { get; set; }
        public string MimeType { get; set; }
        public string ExpiresAt { get; set; }
    }
}
