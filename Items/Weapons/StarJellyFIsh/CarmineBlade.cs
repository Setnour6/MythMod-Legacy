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

namespace MythMod.Items.Weapons.StarJellyFIsh
{
    public class CarmineBlade : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "胭脂幻光刀");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 120;//�˺�
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//�Ƿ��ǽ�ս
            Item.width = 52;//��
            Item.height = 84;//��
            Item.useTime = 27;//ʹ��ʱ�Ӷ����ʱ��
            Item.rare = 8;//Ʒ��
            Item.useAnimation = 27;//�Ӷ�ʱ��������ʱ��
            Item.useStyle = 1;//ʹ�ö����������ǻӶ�
            Item.knockBack = 2.2f;//����
            Item.UseSound = SoundID.Item1;//�Ӷ�����
            Item.autoReuse = true;//�ܷ�����Ӷ�
            Item.crit = 14;//����
            Item.shoot = Mod.Find<ModProjectile>("胭脂凝胶剑气").Type;
            Item.shootSpeed = 12f;
            Item.value = 80000;//��ֵ��1��ʾһͭ�ң�������100�����
            Item.scale = 1f;//��С
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                int i = Main.rand.Next(0, 2);
                if (i == 1)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX * 1.4f, speedY * 1.4f, Mod.Find<ModProjectile>("胭脂凝胶剑气").Type, damage * 2, knockBack, player.whoAmI);
                }
                else
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX * 1.25f, speedY * 1.25f, Mod.Find<ModProjectile>("星渊凝胶剑气").Type, damage, knockBack, player.whoAmI);
                }
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("胭脂凝胶剑气").Type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.Item.damage = 268;
                base.Item.useTime = 20;
                base.Item.useAnimation = 20;
            }
            else
            {
                base.Item.damage = 135;
                base.Item.useTime = 27;
                base.Item.useAnimation = 27;
            }
            return base.CanUseItem(player);
        }
        // Token: 0x040001CB RID: 459
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 3)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 1.2f)) / 16f), 0.1f, 0.08f, 0.0f);
        }
    }
}
