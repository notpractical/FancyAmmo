using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using NotPracticalFancyAmmo.Items.Weapons.Ammo;

namespace NotPracticalFancyAmmo.Projectiles
{
    public class ChaosBulletProjectile : ModProjectile
    {
        
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 260;
            Projectile.light = 4f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            AIType = ProjectileID.Bullet;
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if(Projectile.penetrate <= 0)
            {
                Projectile.Kill();
                return false;
            }

            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

            SoundEngine.PlaySound(SoundID.Tink, Projectile.position);

            if(Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            if(Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }

           return false;


        }

        public override void AI()
        {
            SoundEngine.PlaySound(SoundID.GuitarC.WithVolumeScale(0.5f),Projectile.position);
            int dust = Dust.NewDust(Projectile.Center,1,1,DustID.WitherLightning,0f,0f,0,default(Color),1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0.3f;
            Main.dust[dust].scale = 0.013f;

            int dust2 = Dust.NewDust(Projectile.Center,1,1,DustID.GolfPaticle,0f,0f,0,default(Color),1f);
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 0.3f;
            Main.dust[dust2].scale  = 0.013f;
           

    }
       public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Bleeding, 240);
            target.AddBuff(BuffID.Ichor,240);
            target.AddBuff(BuffID.Electrified,240);
            target.AddBuff(BuffID.Poisoned,240);
            target.AddBuff(BuffID.Venom,240);
            target.AddBuff(BuffID.OnFire,240);
            target.AddBuff(BuffID.CursedInferno,240);
            target.AddBuff(BuffID.Frozen,240);
        }
}
}