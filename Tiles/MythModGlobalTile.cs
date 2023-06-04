using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
    public class MythModGlobalTile : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            return base.CanExplode(i, j, type);
        }
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Player player = Main.LocalPlayer;
            if (type == 5 && player.ZoneSnow)
            {
                if (Main.rand.Next(2400) == 1)
                {
                    Item.NewItem(i * 16, j * 16, 64, 48, Mod.Find<ModItem>("SnowFeather").Type, 1);
                }
            }
            if (type == 5 && player.ZoneCorrupt)
            {
                if (Main.rand.Next(2400) == 1)
                {
                    Item.NewItem(i * 16, j * 16, 64, 48, Mod.Find<ModItem>("CorruptFeather").Type, 1);
                }
            }
            if (type == 5 && player.ZoneCrimson)
            {
                if (Main.rand.Next(2400) == 1)
                {
                    Item.NewItem(i * 16, j * 16, 64, 48, Mod.Find<ModItem>("CrimsonFeather").Type, 1);
                }
            }
        }
        public override void RandomUpdate(int i, int j, int type)
        {
            if ((type == 192 && Main.rand.Next(3) == 1) || type == 384 && Main.rand.Next(6) == 1)
            {
                if(Main.rand.Next(10000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("TwilightFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(20000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("GoldFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(8000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("SnowFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(8000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("DarkFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(6000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("RedBirdFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(6000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("BirdFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(6000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("BlueBirdFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(120000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("GoldBirdFeather").Type, 1);
                    }
                }
                if (Main.rand.Next(60000) == 1)
                {
                    if (!Main.tile[i, j - 1].HasTile)
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("RainbowFeather").Type, 1);
                    }
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("GhostFeather").Type, 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("LightingFeather").Type, 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("LeaveFeather").Type, 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("VoidFeather").Type, 1);
                        }
                    }
                    if(Main.eclipse)
                    {
                        if (Main.rand.Next(40000) == 1)
                        {
                            if (!Main.tile[i, j - 1].HasTile)
                            {
                                Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("DarkGoldFeather").Type, 1);
                            }
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("PoisonFeather").Type, 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("RedSnowFeather").Type, 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].HasTile)
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, Mod.Find<ModItem>("StarlightFeather").Type, 1);
                        }
                    }
                }
            }
            base.RandomUpdate(i, j, type);
        }
        public override void FloorVisuals(int type, Player player)
        {
        }
        public override void Drop(int i, int j, int type)/* tModPorter Suggestion: Use CanDrop to decide if items can drop, use this method to drop additional items. See documentation. */
        {
            Player player = Main.LocalPlayer;
            return base.Drop(i, j, type);
        }
    }
}