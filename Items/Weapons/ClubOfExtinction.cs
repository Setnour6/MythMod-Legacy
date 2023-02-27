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
    public class ClubOfExtinction : ModItem
    {
        private int num = 0;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("灭绝棍棒");
            Tooltip.SetDefault("作弊武器\n产生大量高能漩涡，触碰消除");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 1960000;
            item.melee = true;
            item.width = 106;
            item.height = 106;
            item.useTime = 1;
            item.rare = 11;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 4;
            item.useStyle = 1;
            item.knockBack = 30;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 10000;
            item.value = 9000000;
            item.shoot = mod.ProjectileType("ClubOfExtinction");
            item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
            if (!Main.mouseLeft)
            {
                St = false;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (!St && Main.mouseLeft)
            {
                St = true;
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.lifeMax = 0;
            target.life = 0;
            target.NPCLoot();
        }
        public override void PostUpdate()
        {
        }
    }
}
