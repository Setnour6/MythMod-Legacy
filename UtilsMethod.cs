using MythMod;
using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.ID;

namespace Terraria
{
    public static class UtilsMethod
    {
        public static void QuickSetDefault( this Item item , int rare )
        {
            item.rare = rare;
            item.width = 40;
            item.height = 40;
            item.UseSound = SoundID.Item1;
            item.maxStack = 9999;
        }

        public static void QuickSword( this Item item , int rare )
        {
            item.QuickSetDefault( rare );
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 12;
            item.useAnimation = 12;
            item.UseSound = SoundID.Item1;
            item.rare = rare;
            item.melee = true;
            item.damage = item.rare * 8;
            item.knockBack = 1.2f + item.rare * 0.7f;
            item.crit = 4 + item.rare;
            item.useTime = 20 - item.rare;
            item.useAnimation = 20 - item.rare;
            item.autoReuse = true;
            item.maxStack = 1;
        }

        public static void QuickSword( this Item item , int rare , int shoot )
        {
            item.QuickSword( rare );
            item.shoot = shoot;
            item.shootSpeed = 10 + item.rare;
            item.useTime = item.useAnimation * 4 - item.rare;
        }

        public static void QuickBow( this Item item , int rare )
        {
            item.QuickSword( rare );
            item.melee = false;
            item.ranged = true;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 10 + item.rare;
            item.useAmmo = AmmoID.Arrow;
            item.useTime = item.useAnimation;
            item.UseSound = SoundID.Item5;
        }

        public static void QuickBow( this Item item , int rare , int shoot )
        {
            item.QuickBow( rare );
            item.shoot = shoot;
        }

        public static void QuickBow( this Item item , int rare , int shoot , int useAmmo )
        {
            item.QuickBow( rare , shoot );
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = shoot;
            item.useAmmo = useAmmo;
        }

        public static void QuickRod( this Item item , int rare )
        {
            item.QuickSword( rare );
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.mana = item.rare;
            item.shoot = ProjectileID.DiamondBolt;
            item.shootSpeed = 10 + item.rare;
            item.useTime = item.useAnimation;
            item.UseSound = SoundID.Item43;
        }

        public static void QuickPick( this Item item , int rare )
        {
            item.QuickSetDefault( rare );
            item.melee = true;
            item.rare = rare;
            item.damage = item.rare + 2;
            item.knockBack = 1.2f;
            item.crit = 4;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10 - item.rare;
            item.useAnimation = 24 - item.rare;
            item.pick = rare * 20;
            item.autoReuse = true;
            item.maxStack = 1;
        }

        public static void QuickAxe( this Item item , int rare )
        {
            item.QuickSetDefault( rare );
            item.melee = true;
            item.rare = rare;
            item.damage = item.rare + 2;
            item.knockBack = 1.2f;
            item.crit = 4;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10 - item.rare;
            item.useAnimation = 24 - item.rare;
            item.axe = rare * 4;
            item.autoReuse = true;
            item.maxStack = 1;
        }

        public static void QuickArrow( this Projectile projectile )
        {
            projectile.light = 0.1f;
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ownerHitCheck = true;
            projectile.usesLocalNPCImmunity = true;
        }

        public static void QuickCut( this Projectile projectile )
        {
            projectile.light = 0.5f;
            projectile.aiStyle = -1;
            projectile.penetrate = 30;
            projectile.timeLeft = 600;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ownerHitCheck = true;
            projectile.usesLocalNPCImmunity = true;
        }

        public static void Dash( this Player player , int immuneTime , float speed )
        {
            player.immune = true;
            player.immuneTime += immuneTime;
            player.velocity.X += player.direction == 1 ? speed : -speed;
        }

        public static float Distance( this Vector2 Origin , Vector2 Target )
        {
            return Vector2.Distance( Origin , Target );
        }

        public static bool MouseInRectangle( this Rectangle rectangle )
        {
            return rectangle.Intersects( new Rectangle( Main.mouseX , Main.mouseY , 1 , 1 ) );
        }

        public static bool MouseInRectangle( this Rectangle rectangle , int OFFXLeft = 0 , int OFFYTop = 0 )
        {
            Vector2 vector = Main.screenPosition + new Vector2( (float)Main.mouseX , (float)Main.mouseY );
            return new Rectangle( (int)vector.X , (int)vector.Y , 0 , 0 ).Intersects( new Rectangle( (int)( (float)rectangle.X + Main.screenPosition.X - (float)OFFXLeft ) , (int)( (float)rectangle.Y + Main.screenPosition.Y - (float)OFFYTop ) , rectangle.Width , rectangle.Height ) );
        }

        public static void DrawMouseText( DynamicSpriteFont font , string text )
        {
            Vector2 mouseScreen = Main.MouseScreen;
            Utils.DrawBorderStringFourWay( Main.spriteBatch , font , text , mouseScreen.X + 15 , mouseScreen.Y + 15  , Color.White , Color.Black , Vector2.Zero , 1 );
        }
    }
}
