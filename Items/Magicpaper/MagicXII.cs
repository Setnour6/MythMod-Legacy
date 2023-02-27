using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class MagicXII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("十二阶附魔符咒");
            Tooltip.SetDefault("随机获得一个传说中的符咒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 3000000;
            Item.rare = 3;
            base.Item.useStyle = 1;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
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
            Item.stack--;
            return true;
        }
    }
}