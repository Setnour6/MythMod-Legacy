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
namespace MythMod.Items.Accessories
{
    public class MoonHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("幻影之心");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "幻影之心");
            Tooltip.SetDefault("增加17%闪避和伤害");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "增加17%闪避和伤害");
        }
        public override void SetDefaults()
        {
            base.item.width = 44;
            base.item.height = 32;
            base.item.value = 50000;
            base.item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.arrowDamage *= 1.17f;
            player.meleeDamage *= 1.17f;
            player.bulletDamage *= 1.17f;
            player.magicDamage *= 1.17f;
            player.minionDamage *= 1.17f;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.MoonHeart = 2;
        }
    }
}
