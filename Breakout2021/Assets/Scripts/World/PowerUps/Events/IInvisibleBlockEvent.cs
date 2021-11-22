using UnityEngine.EventSystems;

namespace Owahu.Breakout.World.PowerUps.Events
{
    public interface IInvisibleBlockEvent : IEventSystemHandler
    {
        void OnTriggerInvisibility();

        void OnDisplayBlockAgain();
    }
}