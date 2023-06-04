using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//0‰00‡4¡Á¡Â0‡80‡5mod0‡10‹4¡Á0‰0
{
    public class MoonMossSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");//0†50ˆ00…60ˆ0 0‡80‡50ˆ20Š70‡4¡¤0†5¨¦0‡70‰5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 422;//0‡70‡90†20„7
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//0‡80‡5¡¤0Š90‡80‡50†5¨¹0ˆ90†5
            Item.width = 20;//0†7¨ª
            Item.height = 20;//0†00‰8
            Item.useTime = 24;//0‡80†10ˆ70‡10‡8¡À0†30ˆ70…90…40†40Š10†00‹00‡8¡À0†40Š1
            Item.rare = 9;//0‡4¡¤0‰00‡8
            Item.useAnimation = 24;//0†30ˆ70…90…40‡8¡À0…90…4¡Á¡Â0…60‰00ˆ40‹30‡8¡À0†40Š1
            Item.useStyle = 1;//0‡80†10ˆ70‡10…90…40†30…20„50…10ˆ90‰90†80Š70‡80‡50†30ˆ70…90…4
            Item.knockBack = 11.6f;//0†3¡Â0ˆ10‡9
            Item.UseSound = SoundID.Item1;//0†30ˆ70…90…40‡7¨´0ˆ60‹0
            Item.autoReuse = true;//0‡20‰5¡¤0Š90…60‰00ˆ40‹30†30ˆ70…90…4
            Item.crit = 14;//¡À0„80†3¡Â
            Item.shoot = Mod.Find<ModProjectile>("0ˆ80‡00ˆ7¡ã¡À0…10ˆ9¡§").Type;
            Item.shootSpeed = 9;
            Item.value = 9000000;//0†40‰40‰00…80„50…11¡À¨ª0‡80†60ˆ60†30ˆ10…2¡À0ˆ60„50…10ˆ90‰90†80Š70‡80‡51000…50…10†50Š8¡À0ˆ6
            Item.scale = 1f;//0…7¨®0ˆ40„3

        }
    }
}
