using System;

namespace EventsAndDelegates.Interfaces
{
    public interface IEncoderSubscriber
    {
        void OnVideoEncoded(object source, EventArgs args);
    }
}
