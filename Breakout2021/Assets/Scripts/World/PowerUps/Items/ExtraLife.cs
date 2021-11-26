namespace Owahu.Breakout.World.PowerUps.Items
{
    public class ExtraLife : PowerUp
    {
        protected override void PowerUpPayload ()
        {
            base.PowerUpPayload ();
      
            GameManager.GameManager.Instance.AddLife();  
        }
    }
}