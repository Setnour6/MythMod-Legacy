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
            Item.glowMask = GetGlowMask;
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 1200;
            Item.rare = 0;
            base.Item.useStyle = 1;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            int type = 0;
            switch (Main.rand.Next(1, 9))
            {
                case 1:
                    type = base.Mod.Find<ModItem>("FlamI").Type;
                    break;
                case 2:
                    type = base.Mod.Find<ModItem>("StonI").Type;
                    break;
                case 3:
                    type = base.Mod.Find<ModItem>("Tran").Type;
                    break;
                case 4:
                    type = base.Mod.Find<ModItem>("ProjI").Type;
                    break;
                case 5:
                    type = base.Mod.Find<ModItem>("LazaI").Type;
                    break;
                case 6:
                    type = base.Mod.Find<ModItem>("ArrowI").Type;
                    break;
                case 7:
                    type = base.Mod.Find<ModItem>("FireBoI").Type;
                    break;
                case 8:
                    type = base.Mod.Find<ModItem>("WitcI").Type;
                    break;
            }
            player.QuickSpawnItem(type, 1);
            Item.stack--;
            return true;
        }
    }
}