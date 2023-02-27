using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class CursII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("二阶咒火球符咒");
            Tooltip.SetDefault("释放一发更超级咒火球\n冷却10s");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.damage = 3700;
            Item.value = 15000;
            Item.rare = 3;
            base.Item.useStyle = 1;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.CurseMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 10f;
                v2 = v2.RotatedBy(Main.rand.NextFloat(-0.007f, 0.007f)) * Main.rand.NextFloat(0.9f, 1.1f);
                int j = Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("SuperCurseBall").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                Main.projectile[j].extraUpdates = 3;
                mplayer.MagicCool += 600;
                Item.stack--;
                player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
    }
}