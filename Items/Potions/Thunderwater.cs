using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions//在虚无mod的Items文件夹里
{
    public class Thunderwater : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("天雷药剂");//在游戏里的名称
            Tooltip.SetDefault("");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.maxStack = 30;
            item.value = 80000;
            item.rare = 6;
            item.consumable = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.buffType = mod.BuffType("雷电护体");
            item.buffTime = 1200;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(10f, 16f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Potions/ThunderwaterGlow"), base.item.Center - Main.screenPosition, new Rectangle(0, (int)(Main.time / 4) % 4 * 28, 20, 28), new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }

        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.Ele == 0)
            {
                Projectile.NewProjectile(player.Center.X + 200, player.Center.Y, 0, -2f, mod.ProjectileType("Lighting0"), 400, 0.5f, Main.myPlayer, 10f, 25f);
                mplayer.Ele += 1200;
                player.AddBuff(base.mod.BuffType("雷电护体"), 1200, true);
                item.stack--;
            }
            return mplayer.Ele > 0;
        }
    }
}