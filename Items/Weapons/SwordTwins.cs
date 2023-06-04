using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordTwins : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("荣耀之剑·双子魔眼");
            // base.Tooltip.SetDefault("你的实力已经碾压了双子魔眼，这把属于你的剑里面封印了它的灵魂");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 42;//伤害
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//是否是近战
            Item.width = 48;//宽
            Item.height = 48;//高
            Item.useTime = 40;//使用时挥动间隔时间
            Item.rare = 2;//品质
            Item.useAnimation = 20;//挥动时动作持续时间
            Item.useStyle = 1;//使用动画，这里是挥动
            Item.knockBack = 5.0f;//击退
            Item.UseSound = SoundID.Item1;//挥动声音
            Item.autoReuse = true;//能否持续挥动
            Item.crit = 9;//暴击
            Item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            Item.scale = 1f;//大小
            Item.shoot = Mod.Find<ModProjectile>("TwinsBeam1").Type;
            Item.shootSpeed = 12f;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(Item.width / 2f, Item.height / 2f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/荣耀之剑TwinsGlow"), base.Item.Center - Main.screenPosition, null, new Color(255,255,255,0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            switch (Main.rand.Next(1, 3))
            {
                case 1:
                    type = base.Mod.Find<ModProjectile>("TwinsBeam1").Type;
                    break;
                case 2:
                    type = base.Mod.Find<ModProjectile>("TwinsBeam2").Type;
                    break;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
    }
}
