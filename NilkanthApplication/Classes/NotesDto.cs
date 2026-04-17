using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NilkanthApplication.Classes
{
    public class NotesDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("note_date")]
        public string NoteDate { get; set; }

        [JsonProperty("note_remarks")]
        public string NoteRemarks { get; set; }

    }

}
