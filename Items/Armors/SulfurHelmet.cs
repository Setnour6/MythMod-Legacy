﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Armors
{
	[AutoloadEquip(new EquipType[]
	{
        0
	})]
	public class SulfurHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺头盔");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "远程伤害提高14%,远程暴击率提高14%");
		}
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 36, 0, 0);
			base.item.rare = 11;
			base.item.defense = 16;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 40);
            modRecipe.AddIngredient(null, "Sulfur", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            player.rangedCrit += 14;
            player.rangedDamage *= 1.4f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == base.mod.ItemType("SulfurBreastplate") && legs.type == base.mod.ItemType("SulfurLegging");
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void UpdateArmorSet(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            player.setBonus = "没有怪的时候生成硫磺法球,一旦怪物靠近,立马释放\n远程伤害提高14%,远程暴击率提高14%";
            mplayer.Su = 2;
            player.rangedCrit += 14;
            player.rangedDamage *= 1.4f;
            if (mplayer.Su2 == 0)
            {
                for (int j = 0; j < 16; j++)
                {
                    int num2 = Dust.NewDust(player.Center + new Vector2(0, -50), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                    Main.dust[num2].noGravity = true;
                    num2 = Dust.NewDust(player.Center + new Vector2(0, -50), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                    Main.dust[num2].noGravity = true;
                }
                for (int i = 0; i <= 5; i++)
                {
                    float num4 = (float)(Main.rand.Next(500, 5000));
                    double num1 = Main.rand.Next(0, 1000) / 500f;
                    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                    Projectile.NewProjectile((player.Center + new Vector2(0, -50)).X, (player.Center + new Vector2(0, -50)).Y, (float)num2, (float)num3, base.mod.ProjectileType("SulfurDust"), 80, 2, Main.myPlayer, 0f, 0f);
                }
                Projectile.NewProjectile((player.Center + new Vector2(0, -50)).X, (player.Center + new Vector2(0, -50)).Y, player.velocity.X, player.velocity.Y, base.mod.ProjectileType("SulfurMeltingBall2"), 600, 2, Main.myPlayer, 0f, 0f);
                mplayer.Su2 = 60;
            }
        }
    }
}
