using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class MagicII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("二阶附魔符咒");
            Tooltip.SetDefault("随机获得一个常见二阶符咒，或者少见的一阶符咒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 3000;
            Item.rare = 1;
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
            switch (Main.rand.Next(1, 14))
            {
                case 1:
                    type = base.Mod.Find<ModItem>("FlamII").Type;
                    break;
                case 2:
                    type = base.Mod.Find<ModItem>("MeteI").Type;
                    break;
                case 3:
                    type = base.Mod.Find<ModItem>("ProjII").Type;
                    break;
                case 4:
                    type = base.Mod.Find<ModItem>("FrozI").Type;
                    break;
                case 5:
                    type = base.Mod.Find<ModItem>("ProjII").Type;
                    break;
                case 6:
                    type = base.Mod.Find<ModItem>("ArrowII").Type;
                    break;
                case 7:
                    type = base.Mod.Find<ModItem>("LazarII").Type;
                    break;
                case 8:
                    type = base.Mod.Find<ModItem>("StonII").Type;
                    break;
                case 9:
                    type = base.Mod.Find<ModItem>("PoisI").Type;
                    break;
                case 10:
                    type = base.Mod.Find<ModItem>("WitcII").Type;
                    break;
                case 11:
                    type = base.Mod.Find<ModItem>("FireBoII").Type;
                    break;
                case 12:
                    type = base.Mod.Find<ModItem>("BStarI").Type;
                    break;
                case 13:
                    type = base.Mod.Find<ModItem>("FreLoopI").Type;
                    break;
            }
            player.QuickSpawnItem(type, 1);
            Item.stack--;
            return true;
        }
    }
}