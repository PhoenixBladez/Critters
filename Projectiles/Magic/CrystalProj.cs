using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.Magic
{
	public class CrystalProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Blast");
		}

		public override void SetDefaults()
		{
			projectile.hostile = false;
			projectile.magic = true;
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.alpha = 255;
			projectile.timeLeft =  540;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
				projectile.Kill();
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
					projectile.velocity.X = -oldVelocity.X;

				if (projectile.velocity.Y != oldVelocity.Y)
					projectile.velocity.Y = -oldVelocity.Y;

				projectile.velocity *= 0.75f;
			}
			return false;
		}
		public override bool PreAI()
		{
			for (int i = 0; i < 8; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 9f * (float)i;
				float y = projectile.Center.Y - projectile.velocity.Y / 9f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, 187, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].alpha = projectile.alpha;
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}


			return true;
		}
		public override void Kill(int timeLeft)
		{
			int n = Main.rand.Next(2, 5);
			int deviation = Main.rand.Next(0, 300);
			for (int i = 0; i < n; i++)
			{
				float rotation = MathHelper.ToRadians(270 / n * i + deviation);
				Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
				perturbedSpeed.Normalize();
				perturbedSpeed.X *= 5.5f;
				perturbedSpeed.Y *= 5.5f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("CrystalBolt"), projectile.damage / 3 * 2, projectile.knockBack, projectile.owner);
			}

			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
		}
	}
}
