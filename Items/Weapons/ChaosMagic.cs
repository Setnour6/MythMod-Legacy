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


namespace MythMod.Items.Weapons
{
    public class ChaosMagic : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "混沌妖法");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "神话");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 180;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 10;
			base.Item.width = 28;
			base.Item.height = 30;
			base.Item.useTime = 12;
			base.Item.useAnimation = 12;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 6f;
			base.Item.value = 50000;
			base.Item.rare = 7;
			base.Item.UseSound = SoundID.Item14;
			base.Item.autoReuse = true;
			base.Item.shoot = 467;
			base.Item.shootSpeed = 20f;
        }
        private int l = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (l % 3 == 0)
            {
                type = 467;
                int num = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage * 1.3), knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
            }
            else if(l % 3 == 1)
            {
                type = 468;
                int num = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage * 1.3), knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
            }
            else
            {
                for(int i = 0; i < 5;i++)
                {
                    type = 337;
                    Vector2 v = new Vector2(speedX, speedY).RotatedBy(Main.rand.NextFloat(-0.8f, 0.8f)) * Main.rand.NextFloat(0.6f,1f);
                    int num = Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, type, (int)(damage * 1.3), knockBack, Main.myPlayer, 0f, 0f);
                    Main.projectile[num].hostile = false;
                    Main.projectile[num].friendly = true;
                }
            }
            l++;
            return false;
        }
    }
}
