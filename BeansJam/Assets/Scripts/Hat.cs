﻿﻿using System;
using System.Collections.Generic;

public abstract class Hat {

    public static List<Hat> AllHats = new List<Hat>() {
        new HorseHeadHat(),
        new EtienneHat(),
        new CatHat(),
        new CaptainHat(),
        new FedoraHat(),
        new DinoHat(),
        new AstronautHat(),
        new CarlHat(),
        new OtterHat(),
        new TentacleHat()
    };
    
    public abstract void Apply(Player player);
    public abstract void Remove(Player player);

    protected Hat() {

    }

    public class HorseHeadHat : Hat {
        public override void Apply(Player player) {
            player.rotationSpeed += 5;
            player.speed += 5;
            player.gameObject.transform.GetChild(2).transform.GetChild(6).gameObject.SetActive(true);

        }

        public override void Remove(Player player) {
            player.rotationSpeed -= 5;
            player.speed -= 5;
            player.gameObject.transform.GetChild(2).transform.GetChild(6).gameObject.SetActive(false);
        }
    }

    public class EtienneHat : Hat {
        public override void Apply(Player player) {
            player.InvertControl = true;
            player.gameObject.transform.GetChild(2).transform.GetChild(4).gameObject.SetActive(true);
        }

        public override void Remove(Player player) {
            player.InvertControl = false;
            player.gameObject.transform.GetChild(2).transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    public class CatHat : Hat
    {
        public override void Apply(Player player)
        {
            player.jumpForce += 10;
            player.gameObject.transform.GetChild(2).transform.GetChild(7).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.jumpForce -= 10;
            player.gameObject.transform.GetChild(2).transform.GetChild(7).gameObject.SetActive(false);
        }
    }

    public class CaptainHat : Hat
    {
        public override void Apply(Player player)
        {
            player.invincible = true;
            player.gameObject.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.invincible = false;
            player.gameObject.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public class FedoraHat : Hat
    {
        public override void Apply(Player player)
        {
            player.StealthMode = true;
            player.gameObject.transform.GetChild(2).transform.GetChild(3).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.StealthMode = false;
            player.gameObject.transform.GetChild(2).transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public class DinoHat : Hat
    {
        public UnityEngine.Vector3 originalScale;
        public override void Apply(Player player)
        {
            originalScale = player.transform.localScale;
            player.transform.localScale = new UnityEngine.Vector3(2,2,2);
            player.gameObject.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.transform.localScale = originalScale;
            player.gameObject.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public class AstronautHat : Hat {
        public override void Apply(Player player) {

            player.AdditionalMaxFuel = 50.0f;
            player.gameObject.transform.GetChild(2).transform.GetChild(5).gameObject.SetActive(true);
        }

        public override void Remove(Player player) {
            player.AdditionalMaxFuel = 0.0f;
            player.gameObject.transform.GetChild(2).transform.GetChild(5).gameObject.SetActive(false);
        }
    }

    public class CarlHat : Hat
    {
        public override void Apply(Player player)
        {
            player.gameObject.transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.gameObject.transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public class OtterHat : Hat
    {
        public override void Apply(Player player)
        {
            player.gameObject.transform.GetChild(2).transform.GetChild(8).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.gameObject.transform.GetChild(2).transform.GetChild(8).gameObject.SetActive(false);
        }
    }

    public class TentacleHat : Hat
    {
        public override void Apply(Player player)
        {
            player.gameObject.transform.GetChild(2).transform.GetChild(9).gameObject.SetActive(true);
        }

        public override void Remove(Player player)
        {
            player.gameObject.transform.GetChild(2).transform.GetChild(9).gameObject.SetActive(false);
        }
    }
}
