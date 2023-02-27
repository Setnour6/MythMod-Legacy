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
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "风之子");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 6));
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.noUseGraphic = true;
			base.Item.damage = 180;
			base.Item.DamageType = DamageClass.Summon;
			base.Item.mana = 20;
            Item.width = 54;
            Item.height = 54;
			base.Item.useTime = 26;
			base.Item.useAnimation = 26;
			base.Item.useStyle = 1;
			base.Item.knockBack = 0.3f;
			base.Item.value = 120000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("WindChild").Type;
			base.Item.shootSpeed = 6f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        private int o = 0;
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (player.altFunctionUse == 2)
            {
                MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
                if (mplayer.WindC == 0)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WindChild2").Type, Item.damage, Item.knockBack, Main.myPlayer, 0f, 0f);
                }
            }
            else
            {
                player.AddBuff(Mod.Find<ModBuff>("WindSprite1").Type, 3600, true);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WindChild").Type, Item.damage, Item.knockBack, Main.myPlayer, 0f, 0f);
            }
            return base.UseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "WindFragment", 333);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (player.altFunctionUse == 2)
            {
                if (mplayer.WindC == 0)
                {
                    Item.shoot = Mod.Find<ModProjectile>("WindChild2").Type;
                }
                else
                {
                    Item.shoot = -1;
                }
                base.Item.useTime = 2;
                Item.useStyle = 5;
                base.Item.useAnimation = 6;
                base.Item.mana = 4;
            }
            else
            {
                Item.useStyle = 1;
                Item.shoot = base.Mod.Find<ModProjectile>("WindChild").Type;
                base.Item.useTime = 26;
                base.Item.useAnimation = 26;
                base.Item.autoReuse = false;
                base.Item.mana = 20;
            }
            return base.CanUseItem(player);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(Item.width / 2f, Item.height / 2f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/SkyWeapons/WindChildGlow"), base.Item.Center - Main.screenPosition, new Rectangle(0, ((int)(Main.time / 8f) % 4) * 54,Item.width,Item.height), new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
