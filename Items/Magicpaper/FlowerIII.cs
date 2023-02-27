using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper
{
    public class FlowerIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶绽花符咒");
            Tooltip.SetDefault("从鼠标炸出落花\n冷却10s");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.damage = 743;
            item.value = 40000;
            item.rare = 4;
            base.item.useStyle = 2;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
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
                for (int t = 0; t < 70; t++)
                {
                    Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0, 14f)).RotatedByRandom(Math.PI * 2d);
                    int y = Projectile.NewProjectile(v1.X, v1.Y, v2.X, v2.Y, mod.ProjectileType("Flowerpetal"), item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[y].scale = Main.rand.NextFloat(0.9f, 1.1f);
                    Main.projectile[y].damage = (int)(item.damage * Main.projectile[y].scale);
                    Main.projectile[y].frame = Main.rand.Next(0, 8);
                }
                for (int i = 0; i <= 32; i++)
                {
                    float num4 = (float)(Main.rand.Next(500, 8000)) + 0.4f;
                    double num1 = Main.rand.Next(0, 1000) / 500f;
                    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 90f;
                    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 90f;
                    int num5 = Projectile.NewProjectile(v1.X, v1.Y, (float)num2, (float)num3, base.mod.ProjectileType("GarnetGemDust"), 0, 0, Main.myPlayer, 0f, 0f);
                    Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
                }
                for (int a = 0; a < 90; a++)
                {
                    Vector2 vector = v1;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(5f, 26.5f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("GarnetEffect2"), v.X, v.Y, 0, default(Color), 2f * Main.rand.NextFloat(0.4f, 1.2f));
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
                }
                mplayer.MagicCool += 600;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
                item.stack--;
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