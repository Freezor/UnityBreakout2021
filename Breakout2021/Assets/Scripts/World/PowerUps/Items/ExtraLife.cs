namespace Owahu.Breakout.World.PowerUps.Items
{
    public class ExtraLife : PowerUp
    {
        private void Update()
        {
            if (powerUpState != PowerUpState.IsCollected) return;
            GameManager.GameManager.Instance.AddLife();
            PowerUpHasExpired();
        }
    }
}