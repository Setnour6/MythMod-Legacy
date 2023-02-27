using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items.Weapons.SkyWeapons
{
    public class WindChild : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("风之子");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "风之子");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.noUseGraphic = true;
			base.item.damage = 180;
			base.item.summon = true;
			base.item.mana = 20;
            item.width = 54;
            item.height = 54;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 1;
			base.item.knockBack = 0.3f;
			base.item.value = 120000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("WindChild");
			base.item.shootSpeed = 6f;
            item.noMelee = true;
            item.noUseGraphic = true;
        }
        private int o = 0;
        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
                if (mplayer.WindC == 0)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("WindChild2"), item.damage, item.knockBack, Main.myPlayer, 0f, 0f);
                }
            }
            else
            {
                player.AddBuff(mod.BuffType("WindSprite1"), 3600, true);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("WindChild"), item.damage, item.knockBack, Main.myPlayer, 0f, 0f);
            }
            return base.UseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "WindFragment", 333);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (player.altFunctionUse == 2)
            {
                if (mplayer.WindC == 0)
                {
                    item.shoot = mod.ProjectileType("WindChild2");
                }
                else
                {
                    item.shoot = -1;
                }
                base.item.useTime = 2;
                item.useStyle = 5;
                base.item.useAnimation = 6;
                base.item.mana = 4;
            }
            else
            {
                item.useStyle = 1;
                item.shoot = base.mod.ProjectileType("WindChild");
                base.item.useTime = 26;
                base.item.useAnimation = 26;
                base.item.autoReuse = false;
                base.item.mana = 20;
            }
            return base.CanUseItem(player);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/SkyWeapons/WindChildGlow"), base.item.Center - Main.screenPosition, new Rectangle(0, ((int)(Main.time / 8f) % 4) * 54,item.width,item.height), new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
