namespace Owahu.Breakout.World.PowerUps.Items
{
    public class ExtraLife : PowerUp
    {
        protected override void PowerUpPayload ()
        {
            base.PowerUpPayload ();
      
            // Payload is to give some health bonus
            GameManager.GameManager.Instance.AddLife();  
        }
    }
}