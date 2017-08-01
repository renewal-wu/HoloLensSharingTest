using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unicorn.ServiceModel;
using Newtonsoft.Json;

namespace KKBOX.ServiceModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LyricsLine
    {
        private TimeSpan startTime;
        [JsonProperty("start_time")]
        [JsonConverter(typeof(TimeSpanJsonConverter))]
        public TimeSpan StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        private TimeSpan endTime;
        [JsonProperty("end_time")]
        [JsonConverter(typeof(TimeSpanJsonConverter))]
        public TimeSpan EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        /// <summary>
        /// 0  預設，也就一般的歌詞模式  
        /// 1  男聲，在對唱歌裡男聲的部份  
        /// 2  女聲，在對唱歌裡女聲的部份  
        /// 3  合唱，對唱裡的男女合唱段落 
        /// </summary>
        private LyricsMode type;
        [JsonProperty("type")]
        [JsonConverter(typeof(IntToEnumJsonConverter))]
        public LyricsMode Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        private string lyrics;
        [JsonProperty("content")]
        public string Lyrics
        {
            get
            {
                return lyrics;
            }
            set
            {
                lyrics = value;
            }
        }

        private bool isSessionStart;
        [JsonProperty("is_session_start")]
        public bool IsSessionStart
        {
            get
            {
                return isSessionStart;
            }
            set
            {
                isSessionStart = value;
            }
        }
    }
}