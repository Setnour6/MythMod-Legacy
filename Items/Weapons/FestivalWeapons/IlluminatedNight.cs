using System;
using Terraria;
using Terraria.DataStructures;
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
            // base.DisplayName.SetDefault("千灯耀夜");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "千灯耀夜");
        }
		public override void SetDefaults()
		{
			base.Item.damage = 340;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 8;
			base.Item.width = 70;
			base.Item.height = 74;
			base.Item.useTime = 4;
			base.Item.useAnimation = 16;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 9, 99, 99);
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("LanternBoomLiF").Type;
			base.Item.shootSpeed = 4f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for(int p = 0;p < 2;p++)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-400, 400), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-240, 240)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
                v2 = v2.RotatedBy(Main.rand.NextFloat(-0.15f, 0.15f)) / v2.Length() * 4f;
                Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, base.Mod.Find<ModProjectile>("LanternBoomLiF").Type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(Item.width / 2f, Item.height / 2f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/FestivalWeapons/千灯耀夜Glow"), base.Item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override void AddRecipes()
        {
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 2)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
