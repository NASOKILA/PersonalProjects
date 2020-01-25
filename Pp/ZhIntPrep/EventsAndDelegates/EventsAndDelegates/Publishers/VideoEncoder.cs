using EventsAndDelegates.Interfaces;
using System;
using System.Threading;

namespace EventsAndDelegates.Publishers
{
    public class VideoEncoder : IVideoEncoder
    {
        //01.Define a delegate - it is a contract between a publisher and a subscriber. It holds a reference to a method in this case VideoEncodedEventHandler
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        //02.Define an event based on that delegate
        public event VideoEncodedEventHandler videoEncoded;
        
        //03.Raise that event. We need to create a methods that reises that event. The methods has to be protected virtual and void
        protected virtual void OnVideoEncoded()
        {
            //Check if there are subscribers
            if (videoEncoded != null)
            {
                Console.WriteLine("Encoding Event triggered !");
                //This stands for "this class" because from here we are invoking the event, EventArgs.Empty is for sending empty arguments
                videoEncoded(this, EventArgs.Empty); //If we have subscribers we call this method
            }
        }
        
        public void Encode(IVideo video)
        {
            Console.WriteLine($"Encoding Video '{video.Title}'!");

            Thread.Sleep(3000);

            OnVideoEncoded(); //This method will notify all the subscribers for this event
        }
    }
}
