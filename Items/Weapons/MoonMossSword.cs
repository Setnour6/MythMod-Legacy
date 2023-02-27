using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//�0�0�0�4���0�8�0�5mod�0�1�0�4���0�0
{
    public class MoonMossSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�0�5�0�0�0�6�0�0 �0�8�0�5�0�2�0�7�0�4���0�5���0�7�0�5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 422;//�0�7�0�9�0�2�0�7
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//�0�8�0�5���0�9�0�8�0�5�0�5���0�9�0�5
            Item.width = 20;//�0�7��
            Item.height = 20;//�0�0�0�8
            Item.useTime = 24;//�0�8�0�1�0�7�0�1�0�8���0�3�0�7�0�9�0�4�0�4�0�1�0�0�0�0�0�8���0�4�0�1
            Item.rare = 9;//�0�4���0�0�0�8
            Item.useAnimation = 24;//�0�3�0�7�0�9�0�4�0�8���0�9�0�4���0�6�0�0�0�4�0�3�0�8���0�4�0�1
            Item.useStyle = 1;//�0�8�0�1�0�7�0�1�0�9�0�4�0�3�0�2�0�5�0�1�0�9�0�9�0�8�0�7�0�8�0�5�0�3�0�7�0�9�0�4
            Item.knockBack = 11.6f;//�0�3�0�1�0�9
            Item.UseSound = SoundID.Item1;//�0�3�0�7�0�9�0�4�0�7���0�6�0�0
            Item.autoReuse = true;//�0�2�0�5���0�9�0�6�0�0�0�4�0�3�0�3�0�7�0�9�0�4
            Item.crit = 14;//���0�8�0�3��
            Item.shoot = Mod.Find<ModProjectile>("�0�8�0�0�0�7����0�1�0�9��").Type;
            Item.shootSpeed = 9;
            Item.value = 9000000;//�0�4�0�4�0�0�0�8�0�5�0�11�����0�8�0�6�0�6�0�3�0�1�0�2���0�6�0�5�0�1�0�9�0�9�0�8�0�7�0�8�0�5100�0�5�0�1�0�5�0�8���0�6
            Item.scale = 1f;//�0�7���0�4�0�3

        }
    }
}
