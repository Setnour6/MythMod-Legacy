using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class FreLoopIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶冰环符咒");
            Tooltip.SetDefault("释放一个冰环\n冷却10s");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.damage = 2700;
            Item.value = 25000;
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
            mplayer.FreLoopMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            SoundEngine.PlaySound(SoundID.Item27, player.position);
            if (mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center) / (v1 - player.Center).Length() * 10f;
                for (int k = 0; k <= 40; k++)
                {
                    Vector2 v = new Vector2(0, 60).RotatedBy(MathHelper.Pi * k / 20d);
                    int num4 = Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X * 0.06f, v.Y * 0.06f, base.Mod.Find<ModProjectile>("FreezeLoop").Type, Item.damage, Item.knockBack, Main.myPlayer, 0f, 720/*决定了冰冻时间*/);
                    Main.projectile[num4].timeLeft = 135;
                }
                for (int k = 0; k <= 40; k++)
                {
                    Vector2 v = new Vector2(0, 55f).RotatedBy(MathHelper.Pi * (k + 0.5) / 20d);
                    int num4 = Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X * 0.06f, v.Y * 0.06f, base.Mod.Find<ModProjectile>("FreezeLoop").Type, Item.damage, Item.knockBack, Main.myPlayer, 0f, 720/*决定了冰冻时间*/);
                    Main.projectile[num4].timeLeft = 135;
                }
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
        public override void AddRecipes()
        {
        }
    }
}