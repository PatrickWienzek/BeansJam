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
}
