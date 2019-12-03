using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.Ammo
{
	public class FeatherArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plumed Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.damage = 50;
			projectile.extraUpdates = 1;
			projectile.penetrate = 1;
			aiType = ProjectileID.Bullet;
		}

		public override void Kill(int timeLeft)
		{
			for (int I = 0; I < 8; I++)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 115, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
		}
	}
}
