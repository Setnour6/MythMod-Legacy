using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper
{
    public class FlowerII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("二阶绽花符咒");
            Tooltip.SetDefault("从鼠标炸出落花\n冷却10s");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.damage = 374;
            Item.value = 8000;
            Item.rare = 3;
            base.Item.useStyle = 2;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.FlowMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                for (int t = 0; t < 60; t++)
                {
                    Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0, 12f)).RotatedByRandom(Math.PI * 2d);
                    int y = Projectile.NewProjectile(v1.X, v1.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("Flowerpetal").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[y].scale = Main.rand.NextFloat(0.9f, 1.1f);
                    Main.projectile[y].damage = (int)(Item.damage * Main.projectile[y].scale);
                    Main.projectile[y].frame = Main.rand.Next(0, 8);
                }
                for (int i = 0; i <= 24; i++)
                {
                    float num4 = (float)(Main.rand.Next(500, 8000)) + 0.4f;
                    double num1 = Main.rand.Next(0, 1000) / 500f;
                    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 120f;
                    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 120f;
                    int num5 = Projectile.NewProjectile(v1.X, v1.Y, (float)num2, (float)num3, base.Mod.Find<ModProjectile>("GarnetGemDust").Type, 0, 0, Main.myPlayer, 0f, 0f);
                    Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
                }
                for (int a = 0; a < 60; a++)
                {
                    Vector2 vector = v1;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(5f, 26.5f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("GarnetEffect2").Type, v.X, v.Y, 0, default(Color), 2f * Main.rand.NextFloat(0.4f, 1.2f));
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
                }
                mplayer.MagicCool += 600;
                player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
                Item.stack--;
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EmpMagic", 1);
            recipe.AddIngredient(116, 9);
            recipe.AddIngredient(75, 3);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }*/
    }
}