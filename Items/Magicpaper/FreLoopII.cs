using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class FreLoopII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("二阶冰环符咒");
            Tooltip.SetDefault("释放一个冰环\n冷却10s");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.damage = 1360;
            item.value = 6000;
            item.rare = 2;
            base.item.useStyle = 1;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.FreLoopMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 27, 1f, 0f);
            if (mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 10f;
                for (int k = 0; k <= 40; k++)
                {
                    Vector2 v = new Vector2(0, 50).RotatedBy(MathHelper.Pi * k / 20d);
                    int num4 = Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X * 0.06f, v.Y * 0.06f, base.mod.ProjectileType("FreezeLoop"), item.damage, item.knockBack, Main.myPlayer, 0f, 480/*决定了冰冻时间*/);
                    Main.projectile[num4].timeLeft = 120;
                }
                for (int k = 0; k <= 40; k++)
                {
                    Vector2 v = new Vector2(0, 45.7f).RotatedBy(MathHelper.Pi * (k + 0.5) / 20d);
                    int num4 = Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X * 0.06f, v.Y * 0.06f, base.mod.ProjectileType("FreezeLoop"), item.damage, item.knockBack, Main.myPlayer, 0f, 480/*决定了冰冻时间*/);
                    Main.projectile[num4].timeLeft = 120;
                }
                mplayer.MagicCool += 600;
                item.stack--;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
        }
    }
}