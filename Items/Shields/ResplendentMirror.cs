using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Shields
{
	public class ResplendentMirror : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("璀璨镜");
            Tooltip.AddTranslation(GameCulture.Chinese, "拿在手上增加250防御,并且受到伤害减少60%\n反射盾牌方向的弹幕");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.maxStack = 1;
            Item.flame = true;
            Item.value = 100;
            Item.defense = 250;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 5)
            {
                mplayer.SD = 5;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, Mod.Find<ModProjectile>("ResplendentMirror").Type, 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
            mplayer.AddDef = 250;
            mplayer.DisHurt = 60;
            player.noKnockback = true;
        }
    }
}