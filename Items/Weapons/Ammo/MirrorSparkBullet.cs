using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TestMod.Items.Weapons;
using TestMod.Projectiles;
using TestMod.Items.Weapons.Ammo;

namespace TestMod.Items.Weapons.Ammo
{

    internal class MirrorSparkBullet : ModItem
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
            Item.knockBack=2.5f;

            Item.maxStack = 9999;
            Item.consumable = true;

            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<MirrorSparkBulletProjectile>();
            Item.shootSpeed = 40;

        }
    }

}