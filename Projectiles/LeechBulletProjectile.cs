using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using TestMod.Items.Weapons.Ammo;
using static Terraria.ModLoader.ModContent;


namespace TestMod.Projectiles
{
    public class LeechBulletProjectile : ModProjectile
    {
        
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 160;
            Projectile.timeLeft = 260;
            Projectile.light = 0.25f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            AIType = ProjectileID.Bullet;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 1;
            Projectile.DamageType = DamageClass.Default ;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
           

            SoundEngine.PlaySound(SoundID.Tink, Projectile.position);

          

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

		
        
			float maxDetectRadius = 300f; // The maximum radius at which a projectile can detect a target
			float projSpeed = 30f; // The speed at which the projectile moves towards the target

			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
			Projectile.velocity =  (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
		
        }
		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance) {
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++) {
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy()) {
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance) {
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

     //   public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
      //  {
		//	target.AddBuff(BuffID.Bleeding, 240);
     //   }

    }
}