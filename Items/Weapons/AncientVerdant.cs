using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
    public class AncientVerdant : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("远古葱茏");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 4000;
            item.melee = true;
            item.width = 92;
            item.height = 92;
            item.useTime = 25;
            item.rare = 2;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 14f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 24;
            item.value = 2000000;
            item.scale = 1f;
            item.shoot = 1;
            item.shootSpeed = 14f;
        }
		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine tooltipLine in list)
			{
				if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.overrideColor = new Color?(new Color(0, 246, 255));
				}
			}
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			switch (Main.rand.Next(1 , 7))
			{
			case 1:
                type = base.mod.ProjectileType("火山剑气");
				break;
			case 2:
                type = base.mod.ProjectileType("海洋剑气");
				break;
            case 3:
                type = base.mod.ProjectileType("林木剑气");
                break;
            case 4:
                type = base.mod.ProjectileType("远古剑气");
                break;
            case 5:
                type = base.mod.ProjectileType("远古剑气");
                break;
            case 6:
                type = base.mod.ProjectileType("远古剑气");
                break;
			}
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(47, 480, false);
        }    
    }
}
