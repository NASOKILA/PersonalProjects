namespace EventsAndDelegates.Models
{
    //We will pass this class as a parameter to the EventHandler class which is like an automatic delegate provided by .Net
    public class VideoDecoderArgs
    {
        public string VideoTitle { get; set; }

        public string SubscriberName { get; set; }
    }
}
