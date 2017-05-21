using System.Collections.Generic;

public abstract class Hat {

    public static List<Hat> AllHats = new List<Hat>() {
        new HorseHeadHat()
    };

    
    public abstract void Apply(Player player);
    public abstract void Remove(Player player);


    protected Hat() {

    }

    public class HorseHeadHat : Hat {
        public override void Apply(Player player) {
            player.rotationSpeed += 5;
        }

        public override void Remove(Player player) {
            player.rotationSpeed -= 5;
        }
    }

    public class EtienneHat : Hat {
        public override void Apply(Player player) {
            player.InvertControl = true;
        }

        public override void Remove(Player player) {
            player.InvertControl = false;
        }
    }

    public class CatHat : Hat
    {
        public override void Apply(Player player)
        {
            player.jumpForce += 10;
        }

        public override void Remove(Player player)
        {
            player.jumpForce -= 10;
        }
    }

    public class CaptainHat : Hat
    {
        public override void Apply(Player player)
        {
            player.invincible = true; 
        }

        public override void Remove(Player player)
        {
            player.invincible = false;
        }
    }

    public class FedoraHat : Hat
    {
        public override void Apply(Player player)
        {
            player.stealth = true;
        }

        public override void Remove(Player player)
        {
            player.stealth = false;
        }
    }

    public class DinoHat : Hat
    {
        public UnityEngine.Vector3 originalScale;
        public override void Apply(Player player)
        {
            originalScale = player.transform.localScale;
            player.transform.localScale = new UnityEngine.Vector3(2,2,2);
        }

        public override void Remove(Player player)
        {
            player.transform.localScale = originalScale;
        }
    }
}
