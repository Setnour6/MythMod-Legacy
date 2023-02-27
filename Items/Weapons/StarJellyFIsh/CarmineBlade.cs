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
            item.glowMask = GetGlowMask;
            item.damage = 120;//�˺�
            item.melee = true;//�Ƿ��ǽ�ս
            item.width = 52;//��
            item.height = 84;//��
            item.useTime = 27;//ʹ��ʱ�Ӷ����ʱ��
            item.rare = 8;//Ʒ��
            item.useAnimation = 27;//�Ӷ�ʱ��������ʱ��
            item.useStyle = 1;//ʹ�ö����������ǻӶ�
            item.knockBack = 2.2f;//����
            item.UseSound = SoundID.Item1;//�Ӷ�����
            item.autoReuse = true;//�ܷ�����Ӷ�
            item.crit = 14;//����
            item.shoot = mod.ProjectileType("胭脂凝胶剑气");
            item.shootSpeed = 12f;
            item.value = 80000;//��ֵ��1��ʾһͭ�ң�������100�����
            item.scale = 1f;//��С
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                int i = Main.rand.Next(0, 2);
                if (i == 1)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX * 1.4f, speedY * 1.4f, mod.ProjectileType("胭脂凝胶剑气"), damage * 2, knockBack, player.whoAmI);
                }
                else
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX * 1.25f, speedY * 1.25f, mod.ProjectileType("星渊凝胶剑气"), damage, knockBack, player.whoAmI);
                }
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("胭脂凝胶剑气"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.item.damage = 268;
                base.item.useTime = 20;
                base.item.useAnimation = 20;
            }
            else
            {
                base.item.damage = 135;
                base.item.useTime = 27;
                base.item.useAnimation = 27;
            }
            return base.CanUseItem(player);
        }
        // Token: 0x040001CB RID: 459
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 3)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 1.2f)) / 16f), 0.1f, 0.08f, 0.0f);
        }
    }
}
