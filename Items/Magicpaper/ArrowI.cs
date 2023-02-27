using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper
{
    public class ArrowI : ModItem//血晶之魂是物件名称
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("一阶万箭齐发符咒");
            Tooltip.SetDefault("让玩家射出箭雨\n冷却10s");//物品介绍
        }
        public override void SetDefaults()
        {
            item.width = 26;//长度
            item.height = 40;//高度
            item.maxStack = 999;//最大叠加
            item.damage = 30;
            item.value = 2000;//价值
            item.rare = 0;//稀有度
            base.item.useStyle = 2;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.ArrowMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        Vector2 speed = (v1 - player.position) / (v1 - player.position).Length();
                        Vector2 v2 = player.position + new Vector2(speed.X, speed.Y) * 11f;
                        Vector2 v = new Vector2(speed.X * 11f, speed.Y * 11f).RotatedBy((float)Math.PI * (4 - i) / 50f) * (0.3f + j / 8f) * Main.rand.Next(10, 40) / 15f;
                        int u =  Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, 81, 30, 3, player.whoAmI, 0f, 0f);
                        Main.projectile[u].friendly = true;
                        Main.projectile[u].hostile = false;
                    }
                }
                mplayer.MagicCool += 600;
                item.stack--;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EmpMagic", 1);
            recipe.AddIngredient(40, 25);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}