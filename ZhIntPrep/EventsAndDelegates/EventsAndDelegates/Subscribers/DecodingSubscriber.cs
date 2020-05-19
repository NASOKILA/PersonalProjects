using EventsAndDelegates.Interfaces;
using EventsAndDelegates.Models;
using System;

namespace EventsAndDelegates.Subscribers
{
    public class DecodingSubscriber : IDecoderSubscriber
    {
        public void OnVideoDecoded(object source, VideoDecoderArgs args)
        {
            Console.WriteLine($"Decoder subscriber '{args.SubscriberName}': decoding video '{args.VideoTitle}' !");
        }
    }
}
