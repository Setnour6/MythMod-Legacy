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
            Item.width = 26;//长度
            Item.height = 40;//高度
            Item.maxStack = 999;//最大叠加
            Item.damage = 30;
            Item.value = 2000;//价值
            Item.rare = 0;//稀有度
            base.Item.useStyle = 2;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
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
                Item.stack--;
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
            recipe.AddIngredient(null, "EmpMagic", 1);
            recipe.AddIngredient(40, 25);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
    }
}