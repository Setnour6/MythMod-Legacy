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
            Item.glowMask = GetGlowMask;
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 27000;
            Item.rare = 3;
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
                    type = base.Mod.Find<ModItem>("MeteIII").Type;
                    break;
                case 2:
                    type = base.Mod.Find<ModItem>("PoisIII").Type;
                    break;
                case 3:
                    type = base.Mod.Find<ModItem>("FrozIII").Type;
                    break;
                case 4:
                    type = base.Mod.Find<ModItem>("LighII").Type;
                    break;
                case 5:
                    type = base.Mod.Find<ModItem>("ShadII").Type;
                    break;
                case 6:
                    type = base.Mod.Find<ModItem>("PoisIII").Type;
                    break;
                case 7:
                    type = base.Mod.Find<ModItem>("BStarIII").Type;
                    break;
                case 8:
                    type = base.Mod.Find<ModItem>("FlowerII").Type;
                    break;
            }
            player.QuickSpawnItem(type, 1);
            Item.stack--;
            return true;
        }
    }
}