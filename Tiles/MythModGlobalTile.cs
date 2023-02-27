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
                    Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("SnowFeather"), 1);
                }
            }
            if (type == 5 && player.ZoneCorrupt)
            {
                if (Main.rand.Next(2400) == 1)
                {
                    Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("CorruptFeather"), 1);
                }
            }
            if (type == 5 && player.ZoneCrimson)
            {
                if (Main.rand.Next(2400) == 1)
                {
                    Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("CrimsonFeather"), 1);
                }
            }
        }
        public override void RandomUpdate(int i, int j, int type)
        {
            if ((type == 192 && Main.rand.Next(3) == 1) || type == 384 && Main.rand.Next(6) == 1)
            {
                if(Main.rand.Next(10000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("TwilightFeather"), 1);
                    }
                }
                if (Main.rand.Next(20000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("GoldFeather"), 1);
                    }
                }
                if (Main.rand.Next(8000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("SnowFeather"), 1);
                    }
                }
                if (Main.rand.Next(8000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("DarkFeather"), 1);
                    }
                }
                if (Main.rand.Next(6000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("RedBirdFeather"), 1);
                    }
                }
                if (Main.rand.Next(6000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("BirdFeather"), 1);
                    }
                }
                if (Main.rand.Next(6000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("BlueBirdFeather"), 1);
                    }
                }
                if (Main.rand.Next(120000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("GoldBirdFeather"), 1);
                    }
                }
                if (Main.rand.Next(60000) == 1)
                {
                    if (!Main.tile[i, j - 1].active())
                    {
                        Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("RainbowFeather"), 1);
                    }
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("GhostFeather"), 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("LightingFeather"), 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("LeaveFeather"), 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("VoidFeather"), 1);
                        }
                    }
                    if(Main.eclipse)
                    {
                        if (Main.rand.Next(40000) == 1)
                        {
                            if (!Main.tile[i, j - 1].active())
                            {
                                Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("DarkGoldFeather"), 1);
                            }
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("PoisonFeather"), 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("RedSnowFeather"), 1);
                        }
                    }
                    if (Main.rand.Next(40000) == 1)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Item.NewItem(i * 16, j * 16 - 16, 64, 48, mod.ItemType("StarlightFeather"), 1);
                        }
                    }
                }
            }
            base.RandomUpdate(i, j, type);
        }
        public override void FloorVisuals(int type, Player player)
        {
        }
        public override bool Drop(int i, int j, int type)
        {
            Player player = Main.LocalPlayer;
            return base.Drop(i, j, type);
        }
    }
}