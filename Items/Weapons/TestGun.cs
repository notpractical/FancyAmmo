using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using NotPracticalFancyAmmo.Items.Weapons.Ammo;
using NotPracticalFancyAmmo.Items.Materials;
using System.CommandLine;
using rail;
using Terraria.Enums;

namespace NotPracticalFancyAmmo.Items.Weapons
{
    internal class TestGun : ModItem

    {
        public override void SetStaticDefaults()
        {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 100;
            Item.height = 60;

            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;

            Item.DamageType=  DamageClass.Ranged;
            Item.damage = 25;
            Item.knockBack = 3f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 5f;
            Item.useAmmo = AmmoID.Bullet;


        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 2f);
        }
        
    }



}
