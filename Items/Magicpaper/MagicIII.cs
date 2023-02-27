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
            Item.glowMask = GetGlowMask;
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 9400;
            Item.rare = 2;
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
            switch (Main.rand.Next(1, 17))
            {
                case 1:
                    type = base.Mod.Find<ModItem>("FlamIII").Type;
                    break;
                case 2:
                    type = base.Mod.Find<ModItem>("PoisII").Type;
                    break;
                case 3:
                    type = base.Mod.Find<ModItem>("MeteII").Type;
                    break;
                case 4:
                    type = base.Mod.Find<ModItem>("FrozII").Type;
                    break;
                case 5:
                    type = base.Mod.Find<ModItem>("ProjIII").Type;
                    break;
                case 6:
                    type = base.Mod.Find<ModItem>("ArrowIII").Type;
                    break;
                case 7:
                    type = base.Mod.Find<ModItem>("LazaIII").Type;
                    break;
                case 8:
                    type = base.Mod.Find<ModItem>("PoisIII").Type;
                    break;
                case 9:
                    type = base.Mod.Find<ModItem>("LighI").Type;
                    break;
                case 10:
                    type = base.Mod.Find<ModItem>("ShadI").Type;
                    break;
                case 11:
                    type = base.Mod.Find<ModItem>("PoisII").Type;
                    break;
                case 12:
                    type = base.Mod.Find<ModItem>("WitcII").Type;
                    break;
                case 13:
                    type = base.Mod.Find<ModItem>("FireBoII").Type;
                    break;
                case 14:
                    type = base.Mod.Find<ModItem>("BStarII").Type;
                    break;
                case 15:
                    type = base.Mod.Find<ModItem>("FreLoopII").Type;
                    break;
                case 16:
                    type = base.Mod.Find<ModItem>("FlowerI").Type;
                    break;
            }
            player.QuickSpawnItem(type, 1);
            Item.stack--;
            return true;
        }
    }
}