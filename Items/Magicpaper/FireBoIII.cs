using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class FireBoIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶爆炸烈焰符咒");
            Tooltip.SetDefault("释放一个巨型爆炸陷阱,和若干小爆炸陷阱\n冷却10s");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.damage = 1680;
            item.value = 1000;
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
            //mplayer.FireMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 10f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("FireBomb3"), item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                double m = Main.rand.NextFloat(0,3f);
                for(int i = 0; i < 8; i++)
                {
                    Vector2 v = new Vector2(0, 300).RotatedBy(MathHelper.Pi * i / 4d + m);
                    int y = Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, mod.ProjectileType("FireBomb"), 420, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[y].timeLeft = Main.rand.Next(35900, 36100);
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