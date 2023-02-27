using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//ÖÆ×÷ÊÇmodÃû×Ö
{
    public class MoonMossSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//½Ì³Ì ÊÇÎïÆ·½éÉÜ
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 422;//ÉËº¦
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//ÊÇ·ñÊÇ½üÕ½
            Item.width = 20;//¿í
            Item.height = 20;//¸ß
            Item.useTime = 24;//Ê¹ÓÃÊ±»Ó¶¯¼ä¸ôÊ±¼ä
            Item.rare = 9;//Æ·ÖÊ
            Item.useAnimation = 24;//»Ó¶¯Ê±¶¯×÷³ÖÐøÊ±¼ä
            Item.useStyle = 1;//Ê¹ÓÃ¶¯»­£¬ÕâÀïÊÇ»Ó¶¯
            Item.knockBack = 11.6f;//»÷ÍË
            Item.UseSound = SoundID.Item1;//»Ó¶¯ÉùÒô
            Item.autoReuse = true;//ÄÜ·ñ³ÖÐø»Ó¶¯
            Item.crit = 14;//±©»÷
            Item.shoot = Mod.Find<ModProjectile>("ÔÂÓ°±¬Õ¨").Type;
            Item.shootSpeed = 9;
            Item.value = 9000000;//¼ÛÖµ£¬1±íÊ¾Ò»Í­±Ò£¬ÕâÀïÊÇ100²¬½ð±Ò
            Item.scale = 1f;//´óÐ¡

        }
    }
}
