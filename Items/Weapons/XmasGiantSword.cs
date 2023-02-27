using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class XmasGiantSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("圣诞树巨剑");
            base.Tooltip.SetDefault("");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 280;//伤害
            item.melee = true;//是否是近战
            item.width = 120;//宽
            item.height = 120;//高
            item.useTime = 40;//使用时挥动间隔时间
            item.rare = 11;//品质
            item.useAnimation = 20;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f ;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 9;//暴击
            item.value = 50000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
            item.shoot = 335;
            item.shootSpeed = 41f;
        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(60f, 60f);
			spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞星"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
            if ((int)(Main.time / 5f) % 600 >= 0 && (int)(Main.time / 5f) % 600 < 120)
            {
                if ((int)(Main.time / 5f) % 24 >= 0 && (int)(Main.time / 5f) % 24 < 6)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 24 >= 6 && (int)(Main.time / 5f) % 24 < 12)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 24 >= 12 && (int)(Main.time / 5f) % 24 < 18)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 24 >= 18 && (int)(Main.time / 5f) % 24 < 24)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
            if ((int)(Main.time / 5f) % 600 >=120 && (int)(Main.time / 5f) % 600 < 240)
            {
                if ((int)(Main.time / 5f) % 120 >= 0 && (int)(Main.time / 5f) % 120 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 0 && (int)(Main.time / 5f) % 120 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 10 && (int)(Main.time / 5f) % 120 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 10 && (int)(Main.time / 5f) % 120 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 50 && (int)(Main.time / 5f) % 120 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 50 && (int)(Main.time / 5f) % 120 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 60 && (int)(Main.time / 5f) % 120 < 70)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 60 && (int)(Main.time / 5f) % 120 < 70)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 70 && (int)(Main.time / 5f) % 120 < 110)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 70 && (int)(Main.time / 5f) % 120 < 110)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 110 && (int)(Main.time / 5f) % 120 < 120)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 110 && (int)(Main.time / 5f) % 120 < 120)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
            if ((int)(Main.time / 5f) % 600 >= 240 && (int)(Main.time / 5f) % 600 < 360)
            {
                if ((int)(Main.time / 5f) % 60 >= 0 && (int)(Main.time / 5f) % 60 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 0 && (int)(Main.time / 5f) % 60 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 10 && (int)(Main.time / 5f) % 60 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 10 && (int)(Main.time / 5f) % 60 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 50 && (int)(Main.time / 5f) % 60 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 50 && (int)(Main.time / 5f) % 60 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 0 && (int)(Main.time / 5f) % 60 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * (((int)(Main.time / 5f) - 60) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 0 && (int)(Main.time / 5f) % 60 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * (((int)(Main.time / 5f) - 60) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 10 && (int)(Main.time / 5f) % 60 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 10 && (int)(Main.time / 5f) % 60 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 50 && (int)(Main.time / 5f) % 60 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(120 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 60 >= 50 && (int)(Main.time / 5f) % 60 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(120 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
            if ((int)(Main.time / 5f) % 600 >= 360 && (int)(Main.time / 5f) % 600 < 480)
            {
                if ((int)(Main.time / 5f) % 120 >= 0 && (int)(Main.time / 5f) % 120 < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 30 && (int)(Main.time / 5f) % 120 < 40)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(Main.time / 5f) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 10 && (int)(Main.time / 5f) % 120 < 50)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 40 && (int)(Main.time / 5f) % 120 < 80)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 50 && (int)(Main.time / 5f) % 120 < 60)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 80 && (int)(Main.time / 5f) % 120 < 90)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(60 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 60 && (int)(Main.time / 5f) % 120 < 70)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * (((int)(Main.time / 5f) - 60) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 90 && (int)(Main.time / 5f) % 120 < 100)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * (((int)(Main.time / 5f) - 60) % 120 / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 70 && (int)(Main.time / 5f) % 120 < 110)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 100 || (int)(Main.time / 5f) % 120 < 20)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 110 && (int)(Main.time / 5f) % 120 < 120)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(120 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
                if ((int)(Main.time / 5f) % 120 >= 20 && (int)(Main.time / 5f) % 120 < 30)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * ((int)(120 - (Main.time / 5f) % 120) / 10f), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
            if ((int)(Main.time / 5f) % 600 >= 480 && (int)(Main.time / 5f) % 600 < 600)
            {
                if ((int)(Main.time / 5f) % 8 >= 3 && (int)(Main.time / 5f) % 8 < 8)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞蓝灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞红灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞绿灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/圣诞黄灯"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 93, 0f, 0f, 0, default(Color), 0.6f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 v = new Vector2(speedX, speedY);
            Projectile.NewProjectile(position.X, position.Y, speedX * 0.6f, speedY * 0.6f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            v = new Vector2(speedX, speedY).RotatedBy(Main.rand.Next(-200, 200) / 1000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile(position.X, position.Y, v.X * 0.6f, v.Y * 0.6f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            v = new Vector2(speedX, speedY).RotatedBy(Main.rand.Next(-200, 200) / 1000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile(position.X, position.Y, v.X * 0.6f, v.Y * 0.6f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            if (Main.rand.Next(2) == 0)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, 503, (int)damage * 10, (float)knockBack, player.whoAmI, 0f, 0f);
            }
            if (Main.rand.Next(2) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 0.4f, speedY * 0.4f, mod.ProjectileType("灯头"), damage, knockBack, Main.myPlayer, 0f, 0f);
            }
            if (Main.rand.Next(10) == 0)
            {
                for(int i = 0;i < 4;i++)
                {
                    Vector2 v3 = (v * Main.rand.NextFloat(0.14f, 0.20f)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(position.X, position.Y, v3.X, v3.Y, mod.ProjectileType("红灯"), damage, knockBack, Main.myPlayer, 0f, 0f);
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 v3 = (v * Main.rand.NextFloat(0.14f, 0.20f)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(position.X, position.Y, v3.X, v3.Y, mod.ProjectileType("黄灯"), damage, knockBack, Main.myPlayer, 0f, 0f);
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 v3 = (v * Main.rand.NextFloat(0.14f, 0.20f)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(position.X, position.Y, v3.X, v3.Y, mod.ProjectileType("蓝灯"), damage, knockBack, Main.myPlayer, 0f, 0f);
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 v3 = (v * Main.rand.NextFloat(0.14f, 0.20f)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(position.X, position.Y, v3.X, v3.Y, mod.ProjectileType("绿灯"), damage, knockBack, Main.myPlayer, 0f, 0f);
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1928, 5);
            modRecipe.AddIngredient(null, "SoulOfPine", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
