using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper
{
    public class BStarI : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("一阶魔法落星符咒");
            // Tooltip.SetDefault("从鼠标往下释放蓝色落星\n冷却10s");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.damage = 110;
            Item.value = 2000;
            Item.rare = 1;
            base.Item.useStyle = 2;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.BstarMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                for(int t = 0;t < 24;t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v3 = new Vector2(0, 10).RotatedBy(Main.rand.NextFloat(-0.5f,0.5f) * Main.rand.NextFloat(0f,1.2f)) * Main.rand.NextFloat(0.4f, 1.2f);
                    Vector2 v2 = new Vector2(v3.X, v3.Y * v3.Y * 0.15f) * 0.9f;
                    int y = Projectile.NewProjectile(v1.X, v1.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("BlueStar").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[y].scale = Main.rand.NextFloat(0.4f, 1.7f);
                    Main.projectile[y].damage = (int)(Item.damage * Main.projectile[y].scale);
                }
                float num8 = Main.rand.Next(-1000, 1000) / 100f;
                double num9 = (double)Math.Sqrt(100 - num8 * num8);
                Vector2 v4 = Vector2.Normalize(new Vector2((float)num8, (float)num9)) * 5f;
                float num6 = (float)Main.rand.NextFloat(0, 10000f);
                float num7 = (float)Main.rand.NextFloat(num6, 10000f);
                for (int i = 0; i < 15; i++)
                {
                    Vector2 v0 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    v4 = v4.RotatedBy(Math.PI / 7.5d);
                    Vector2 v2 = new Vector2(v4.X * (float)num6 / 10000f, v4.Y);
                    int p = Projectile.NewProjectile(v0.X, v0.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("BlueGemDust").Type, 0, 0, Main.myPlayer, 0f, 0f);
                    Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 4f;
                    Main.projectile[p].scale = (0.3f + Math.Abs((float)Math.Atan2(-v4.Y, -v4.X) / (1 + (float)num6 / 2000f)));
                }
                for (int i = 0; i < 15; i++)
                {
                    Vector2 v0 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    v4 = v4.RotatedBy(Math.PI / 7.5d);
                    Vector2 v2 = new Vector2(v4.X * (float)num6 / 10000f, v4.Y);
                    int p = Projectile.NewProjectile(v0.X, v0.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("BlueGemDust").Type, 0, 0, Main.myPlayer, 0f, 0f);
                    Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9) + Math.PI * 0.5d) * 4f;
                    Main.projectile[p].scale = (0.3f + Math.Abs((float)Math.Atan2(-v4.Y, -v4.X) / (1 + (float)num6 / 2000f)));
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