using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class LazaS : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("激光雨符咒石");
            // Tooltip.SetDefault("降下激光雨\n无精准度可言\n冷却10s\n无消耗");
        }
        public override void SetDefaults()
        {
            Item.width = 26;//长度
            Item.height = 40;//高度
            Item.maxStack = 999;//最大叠加
            Item.damage = 370;
            Item.value = 120000;//价值
            Item.rare = 4;//稀有度
            base.Item.useStyle = 2;
            Item.consumable = false;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            Item.noMelee = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.LazaMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                for (int t = 0; t < 288; t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                    int num = Projectile.NewProjectile(v1.X + Main.rand.Next(-600, 600), v1.Y - 1000 + Main.rand.Next(-4800, 200), v2.X * 4f, v2.Y * 4f, 83, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[num].friendly = true;
                    Main.projectile[num].hostile = false;
                }
                mplayer.MagicCool += 600;
                player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "LazaIII", 1);
            recipe.AddIngredient(null, "MagicStone", 1);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
    }
}