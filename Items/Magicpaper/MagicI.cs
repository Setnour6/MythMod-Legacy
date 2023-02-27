using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{ 
    public class MagicI : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("一阶附魔符咒");
            Tooltip.SetDefault("随机获得一个常见一阶符咒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.value = 1200;
            item.rare = 0;
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
                    type = base.mod.ItemType("FlamI");
                    break;
                case 2:
                    type = base.mod.ItemType("StonI");
                    break;
                case 3:
                    type = base.mod.ItemType("Tran");
                    break;
                case 4:
                    type = base.mod.ItemType("ProjI");
                    break;
                case 5:
                    type = base.mod.ItemType("LazaI");
                    break;
                case 6:
                    type = base.mod.ItemType("ArrowI");
                    break;
                case 7:
                    type = base.mod.ItemType("FireBoI");
                    break;
                case 8:
                    type = base.mod.ItemType("WitcI");
                    break;
            }
            player.QuickSpawnItem(type, 1);
            item.stack--;
            return true;
        }
    }
}