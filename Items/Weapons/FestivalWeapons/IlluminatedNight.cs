using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class IlluminatedNight : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("千灯耀夜");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "千灯耀夜");
        }
		public override void SetDefaults()
		{
			base.item.damage = 340;
			base.item.magic = true;
			base.item.mana = 8;
			base.item.width = 70;
			base.item.height = 74;
			base.item.useTime = 4;
			base.item.useAnimation = 16;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 9, 99, 99);
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("LanternBoomLiF");
			base.item.shootSpeed = 4f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int p = 0;p < 2;p++)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-400, 400), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-240, 240)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
                v2 = v2.RotatedBy(Main.rand.NextFloat(-0.15f, 0.15f)) / v2.Length() * 4f;
                Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, base.mod.ProjectileType("LanternBoomLiF"), (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/FestivalWeapons/千灯耀夜Glow"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override void AddRecipes()
        {
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 2)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
