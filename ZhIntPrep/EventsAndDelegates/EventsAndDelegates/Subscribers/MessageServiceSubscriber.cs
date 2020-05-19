using EventsAndDelegates.Interfaces;
using System;

namespace EventsAndDelegates.Subscribers
{
    public class MessageServiceSubscriber : IEncoderSubscriber
    {
        //This class will be our subscriber1
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine($"Message Service : Sending a message !");
        }
    }
}
