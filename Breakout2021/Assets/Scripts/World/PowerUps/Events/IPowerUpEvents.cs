using Owahu.Breakout.Player;
using Owahu.Breakout.World.PowerUps.Items;
using UnityEngine.EventSystems;

namespace Owahu.Breakout.World.PowerUps.Events
{
    public interface IPowerUpEvents : IEventSystemHandler
    {
        void OnPowerUpCollected (PowerUp powerUp, RacketMovement player);

        void OnPowerUpExpired (PowerUp powerUp, RacketMovement player);
    }
}