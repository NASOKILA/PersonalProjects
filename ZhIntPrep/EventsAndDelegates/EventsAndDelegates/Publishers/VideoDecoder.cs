using EventsAndDelegates.Interfaces;
using EventsAndDelegates.Models;
using System;
using System.Threading;

namespace EventsAndDelegates.Publishers
{
    public class VideoDecoder : IVideoDecoder
    {

        //02: Create Event for a delegate - use the .net coreprovided class for delegates called EventHandler
        public event EventHandler<VideoDecoderArgs> videoDecoded;

        //03. Call that event
        protected virtual void OnVideoDecoded(VideoDecoderArgs videoDecoderArgs)
        {
            //Check if there are subscribers
            if (videoDecoded != null)
            {
                Console.WriteLine("Decoding Event triggered !");
                
                videoDecoded(this, videoDecoderArgs); 
            }
        }

        public void Decode(IVideo video)
        {
            Console.WriteLine($"Decoding Video '{video.Title}'!");

            Thread.Sleep(3000);

            VideoDecoderArgs videoDecoderArgs = new VideoDecoderArgs() { VideoTitle = video.Title, SubscriberName = "subsriberName" };
            OnVideoDecoded(videoDecoderArgs); //This method will notify all the subscribers for this event
        }

    }
}
