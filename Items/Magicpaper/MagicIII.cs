using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class MagicIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶附魔符咒");
            Tooltip.SetDefault("随机获得一个常见三阶符咒，或者不常见的二阶符咒，或者少见的一阶符咒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.value = 9400;
            item.rare = 2;
            base.item.useStyle = 1;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            int type = 0;
            switch (Main.rand.Next(1, 17))
            {
                case 1:
                    type = base.mod.ItemType("FlamIII");
                    break;
                case 2:
                    type = base.mod.ItemType("PoisII");
                    break;
                case 3:
                    type = base.mod.ItemType("MeteII");
                    break;
                case 4:
                    type = base.mod.ItemType("FrozII");
                    break;
                case 5:
                    type = base.mod.ItemType("ProjIII");
                    break;
                case 6:
                    type = base.mod.ItemType("ArrowIII");
                    break;
                case 7:
                    type = base.mod.ItemType("LazaIII");
                    break;
                case 8:
                    type = base.mod.ItemType("PoisIII");
                    break;
                case 9:
                    type = base.mod.ItemType("LighI");
                    break;
                case 10:
                    type = base.mod.ItemType("ShadI");
                    break;
                case 11:
                    type = base.mod.ItemType("PoisII");
                    break;
                case 12:
                    type = base.mod.ItemType("WitcII");
                    break;
                case 13:
                    type = base.mod.ItemType("FireBoII");
                    break;
                case 14:
                    type = base.mod.ItemType("BStarII");
                    break;
                case 15:
                    type = base.mod.ItemType("FreLoopII");
                    break;
                case 16:
                    type = base.mod.ItemType("FlowerI");
                    break;
            }
            player.QuickSpawnItem(type, 1);
            item.stack--;
            return true;
        }
    }
}