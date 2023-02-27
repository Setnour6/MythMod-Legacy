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
            Item.width = 20;
            Item.height = 32;
            Item.maxStack = 30;
            Item.value = 80000;
            Item.rare = 6;
            Item.consumable = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useStyle = 2;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.buffType = Mod.Find<ModBuff>("雷电护体").Type;
            Item.buffTime = 1200;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(10f, 16f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Potions/ThunderwaterGlow"), base.Item.Center - Main.screenPosition, new Rectangle(0, (int)(Main.time / 4) % 4 * 28, 20, 28), new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }

        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.Ele == 0)
            {
                Projectile.NewProjectile(player.Center.X + 200, player.Center.Y, 0, -2f, Mod.Find<ModProjectile>("Lighting0").Type, 400, 0.5f, Main.myPlayer, 10f, 25f);
                mplayer.Ele += 1200;
                player.AddBuff(base.Mod.Find<ModBuff>("雷电护体").Type, 1200, true);
                Item.stack--;
            }
            return mplayer.Ele > 0;
        }
    }
}