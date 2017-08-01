using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.ServiceModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LyricsData
    {
        [JsonProperty("lyricist")]
        public string Lyricist { get; set; }

        [JsonProperty("composer")]
        public string Composer { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("lyrics")]
        public List<LyricsLine> LyricsLines { get; set; }
    }
}