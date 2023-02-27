using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class MagicIX : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("九阶附魔符咒");
            Tooltip.SetDefault("随机获得一个极罕见的符咒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.value = 3000000;
            item.rare = 3;
            base.item.useStyle = 1;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            /*MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            int type = 0;
            switch (Main.rand.Next(1, 4))
            {
                case 1:
                    type = base.mod.ItemType("LighIII");
                    break;
                case 2:
                    type = base.mod.ItemType("ShadIII");
                    break;
                case 3:
                    type = base.mod.ItemType("FlowerIII");
                    break;
            }
            player.QuickSpawnItem(type, 1);*/
            item.stack--;
            return true;
        }
    }
}