using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class MagicIV : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("四阶附魔符咒");
            Tooltip.SetDefault("随机获得一个不常见的符咒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.value = 27000;
            item.rare = 3;
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
            switch (Main.rand.Next(1, 9))
            {
                case 1:
                    type = base.mod.ItemType("MeteIII");
                    break;
                case 2:
                    type = base.mod.ItemType("PoisIII");
                    break;
                case 3:
                    type = base.mod.ItemType("FrozIII");
                    break;
                case 4:
                    type = base.mod.ItemType("LighII");
                    break;
                case 5:
                    type = base.mod.ItemType("ShadII");
                    break;
                case 6:
                    type = base.mod.ItemType("PoisIII");
                    break;
                case 7:
                    type = base.mod.ItemType("BStarIII");
                    break;
                case 8:
                    type = base.mod.ItemType("FlowerII");
                    break;
            }
            player.QuickSpawnItem(type, 1);
            item.stack--;
            return true;
        }
    }
}