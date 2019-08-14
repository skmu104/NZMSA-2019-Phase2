using Mee_Mee.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;


namespace Mee_Mee.helper
{
    public class youtubeHelper
    {
        public static void testProgram()
        {
            //Console.WriteLine(getVid("cR8w0TimOCo"));
            //Console.ReadLine();
        }

        public static String getVidId(String URL)
        {
            int indexOfStart = URL.IndexOf('=') + 1;
            String vidId = URL.Substring(indexOfStart);
            return vidId;
        }

        public static Video getVid(String vidId,int cId)
        {
            String apiKey = "AIzaSyA4CkmM3_spkZgKPbIXL-WIfOHNUTtOTjk";
            String vidAPI = "https://www.googleapis.com/youtube/v3/videos?id=" + vidId + "&key=" + apiKey + "&part=snippet,contentDetails";

            String vidDetailsJSON = new WebClient().DownloadString(vidAPI);

            dynamic JObj = JsonConvert.DeserializeObject<dynamic>(vidDetailsJSON);

            String v_title = JObj["items"][0]["snippet"]["title"];
            String v_thumb = JObj["items"][0]["snippet"]["thumbnails"]["medium"]["url"];
            String v_len = JObj["items"][0]["contentDetails"]["duration"];
            String v_url = "https://www.youtube.com/watch?v=" + vidId;

            TimeSpan v_l = XmlConvert.ToTimeSpan(v_len);
            int v_length = (int)v_l.TotalSeconds;


            Video video = new Video();
            video.VUrl = v_url;
            video.VThumb = v_thumb;
            video.VLength = v_length;
            video.Show = true;
            video.VTitle = v_title;
            video.ClientId = cId;


            return video;


            
        }
    }
}
