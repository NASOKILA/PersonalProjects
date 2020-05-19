using System;
using EventsAndDelegates.Interfaces;

namespace EventsAndDelegates.Subscribers
{
    public class PageServiceSubscriber : IEncoderSubscriber
    {
        //This class will be our subscriber3
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Page service : Sending page mails !");
        }
    }
}
