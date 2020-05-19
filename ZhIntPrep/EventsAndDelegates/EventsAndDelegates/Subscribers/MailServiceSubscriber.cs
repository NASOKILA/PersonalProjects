using EventsAndDelegates.Interfaces;
using System;

namespace EventsAndDelegates.Subscribers
{
    public class MailServiceSubscriber : IEncoderSubscriber
    {
        //This class will be our subscriber1
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Mail service : Sending an email !");
        }
    }
}
