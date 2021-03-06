﻿using System;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace SephCassiopeia
{
    class CassioUtils
    {
        public static int GetSlider(String name)
        {
            return Cassiopeia.Config.Item(name).GetValue<Slider>().Value;
        }

        public static bool Active(String MenuItemName)
        {
            return Cassiopeia.Config.Item(MenuItemName).GetValue<bool>();
        }

        public static bool ActiveKeyBind(String itemname)
        {
            return Cassiopeia.Config.Item(itemname).GetValue<KeyBind>().Active;
        }

        public static HitChance GetHitChance(String search)
        {
            var hitchance = Cassiopeia.Config.Item(search).GetValue<StringList>();
            switch (hitchance.SList[hitchance.SelectedIndex])
            {
                case "Low":
                    return HitChance.Low;
                case "Medium":
                    return HitChance.Medium;
                case "High":
                    return HitChance.High;
                case "VeryHigh":
                    return HitChance.VeryHigh;
                case "Immobile":
                    return HitChance.Immobile;
            }
            return HitChance.Medium;
        }

        private static Obj_AI_Hero Player = Cassiopeia.Player;

        public static bool isHealthy()
        {
            return Player.HealthPercent > 25;
        }

        public static bool PointUnderEnemyTurret(Vector3 Point)
        {
            var EnemyTurrets =
                ObjectManager.Get<Obj_AI_Turret>().Where(t => t.IsEnemy && Vector3.Distance(t.Position, Point) < 900f);
            return EnemyTurrets.Any();
        }

        public static bool PointUnderAllyTurret(Vector3 Point)
        {
            var AllyTurrets =
                ObjectManager.Get<Obj_AI_Turret>().Where(t => t.IsAlly && Vector3.Distance(t.Position, Point) < 900f);
            return AllyTurrets.Any();
        }

        public static bool CanSecondE()
        {
            return Player.HasBuff("LuxE");
        }

        public static bool AutoSecondE()
        {
            return Active("Combo.UseE2");
        }
    }
}
