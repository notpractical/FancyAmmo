using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TestMod.Items.Weapons;
using TestMod.Projectiles;
using TestMod.Items.Weapons.Ammo;
using TestMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
namespace TestMod.Items.Weapons.Ammo
{

    internal class LeechBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            
            Item.damage = -45;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack=2.5f;

            Item.maxStack = 9999;
            Item.consumable = true;

            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<LeechBulletProjectile>();
            Item.shootSpeed = 1;

        }
        public override void AddRecipes()
        {
            CreateRecipe(50)
                .AddIngredient<VampireFang>()
                .AddIngredient(ItemID.ChlorophyteBullet, 50)
                .AddTile(TileID.Anvils)
                .Register();
        }

        
    }

}