using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NotPracticalFancyAmmo.Items.Weapons;
using NotPracticalFancyAmmo.Projectiles;
using NotPracticalFancyAmmo.Items.Weapons.Ammo;
using NotPracticalFancyAmmo.Items.Materials;

namespace NotPracticalFancyAmmo.Items.Weapons.Ammo
{

    internal class ChaosBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            
            Item.damage=24;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack=4.5f;

            Item.maxStack = 9999;
            Item.consumable = true;

            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<ChaosBulletProjectile>();
            Item.shootSpeed = 60;

        }
         public override void AddRecipes()
        {
            CreateRecipe(50)
                .AddIngredient<ChaoticBone>()
                .AddIngredient(ItemID.MusketBall, 50)
                
                .AddTile(TileID.Anvils)
                .Register();
        }
    }

}