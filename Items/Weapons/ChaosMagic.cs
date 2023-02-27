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
			base.item.damage = 180;
			base.item.magic = true;
			base.item.mana = 10;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6f;
			base.item.value = 50000;
			base.item.rare = 7;
			base.item.UseSound = SoundID.Item14;
			base.item.autoReuse = true;
			base.item.shoot = 467;
			base.item.shootSpeed = 20f;
        }
        private int l = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
