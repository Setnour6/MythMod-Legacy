using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class OceanCrystalClub : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("蓝晶石棍棒");
        }
        public override void SetDefaults()
        {
            item.damage = 270;
            item.melee = true;
            item.width = 74;
            item.height = 80;
            item.useTime = 20;
            item.rare = 8;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5.0f ;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 27000;
            item.scale = 1f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //Lighting.AddLight(new Vector2((float)hitbox.X, (float)hitbox.Y), 0 / 255f, 12 / 255f, 220 / 255f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Aquamarine"), 0f, 0f, 0, default(Color), 1.8f);
        }
    }
}
