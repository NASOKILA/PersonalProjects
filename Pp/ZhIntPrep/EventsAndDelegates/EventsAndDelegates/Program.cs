using System;
using EventsAndDelegates.Publishers;
using EventsAndDelegates.Subscribers;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {

            //01.Create the publisher
            var videoEncoder = new VideoEncoder();
            
            //02.Create the suscribers
            var mailService = new MailServiceSubscriber(); //Subscriber1
            var messageService = new MessageServiceSubscriber(); //Subscriber2
            var pageService = new PageServiceSubscriber(); //Subscriber2

            //03.Add the subscribers to the event, the methods need to have the same arguments, we do not call the actual method we just reference it.
            videoEncoder.videoEncoded += mailService.OnVideoEncoded; 
            videoEncoder.videoEncoded += messageService.OnVideoEncoded;
            videoEncoder.videoEncoded += pageService.OnVideoEncoded;
            

            //04.Call the event
            videoEncoder.Encode(new Video() { Title = "Video1" });

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine();


            //Second publisher for decoding

            //01. Create the publisher
            var videoDecoder = new VideoDecoder();

            //02. Create the subscriber
            var subscriber = new DecodingSubscriber();

            //03. Add the subscribers to the event
            videoDecoder.videoDecoded += subscriber.OnVideoDecoded;

            //04. Trigger the event
            videoDecoder.Decode(new Video() {  Title="Video2" });

            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
