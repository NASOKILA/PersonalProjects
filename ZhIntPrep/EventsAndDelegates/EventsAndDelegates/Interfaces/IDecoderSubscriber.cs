using EventsAndDelegates.Models;

namespace EventsAndDelegates.Interfaces
{
    public interface IDecoderSubscriber
    {
        void OnVideoDecoded(object source, VideoDecoderArgs args);
    }
}
