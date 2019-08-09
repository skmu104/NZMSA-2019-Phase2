using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using System.Net;
using Newtonsoft.Json;
using System.Xml;

namespace WebApplication1.helper
{
    public class VideoHelp
    {

        public static void Test()
        {
            Console.Write(vidDetails("TOcGSwJBPMQ"));
           // String id = getVidId("https://www.youtube.com/watch?v=TOcGSwJBPMQ");
            //Console.Write()
            Console.ReadLine();
        }
   

        public static String getVidId(String url)
        {
            //finds index of of start of video id
            int start = url.IndexOf("=") + 1;

            //gets everything in the url from start to end
            String id = url.Substring(start);
            return id;

        }

        public static Video vidDetails(String id)
        {
            //method of extracting video information identical to that done in workshop

            String api = "AIzaSyA4CkmM3_spkZgKPbIXL-WIfOHNUTtOTjk";
            String apiLink = "https://www.googleapis.com/youtube/v3/videos?id=" + id +  "&key=" + api + "&part=snippet,contentDetails";

            String vInfo = new WebClient().DownloadString(apiLink);


            String videoUrl = "https://www.youtube.com/watch?v=" + id;

            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(vInfo);
            String title = jsonObj["items"][0]["snippet"]["title"];
            String thumbnailURL = jsonObj["items"][0]["snippet"]["thumbnails"]["medium"]["url"];
            String durationString = jsonObj["items"][0]["contentDetails"]["duration"];


            TimeSpan videoDuration = XmlConvert.ToTimeSpan(durationString);
            int duration = (int)videoDuration.TotalSeconds;


            Video vid = new Video
            {

            }
            
                
                
                

            return null;

        } 
            
    }
}
