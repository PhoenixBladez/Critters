using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Critters.Projectiles.Summon;

namespace Critters.Projectiles.Summon
{
	public class IgnomeSummon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unstable Ignome");
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.Homing[base.projectile.type] = true;
			Main.projFrames[projectile.type] = 8;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Raven);
			projectile.width = 40;
			projectile.height = 20;
			projectile.minion = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.netImportant = true;
			aiType = ProjectileID.Raven;
			projectile.alpha = 0;
			projectile.penetrate = 2;
			projectile.minionSlots = 0;
			projectile.timeLeft = 300;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.penetrate == 0)
				projectile.Kill();

			return false;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[projectile.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)(texture2D.Height / Main.projFrames[projectile.type]) * 0.5f);
			SpriteEffects effects = (projectile.direction == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 value = new Vector2(projectile.Center.X - 4f, projectile.Center.Y - 8f);
			Main.spriteBatch.Draw(texture2D, value - Main.screenPosition, new Rectangle?(Utils.Frame(texture2D, 1, Main.projFrames[projectile.type], 0, projectile.frame)), lightColor, projectile.rotation, origin, projectile.scale, effects, 0f);
			return false;
		}
		  public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		public override bool PreAI()
		{
			Vector2 position = projectile.Center + Vector2.Normalize(projectile.velocity) * 8;

			Dust newDust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height + 20, 6, 0f, 0f, 0, default(Color), 1f)];
			newDust.position = position;
			newDust.velocity = projectile.velocity.RotatedBy(Math.PI / 2.4f, default(Vector2)) * 0.23F + projectile.velocity / 2;
			newDust.position += projectile.velocity.RotatedBy(Math.PI / 2.4f, default(Vector2));
			newDust.fadeIn = 0.5f;
			newDust.noGravity = true;
			newDust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height + 10, 6, 0f, 0f, 0, default(Color), 1)];
			newDust.position = position;
			newDust.velocity = projectile.velocity.RotatedBy(-Math.PI / 2.4f, default(Vector2)) * 0.23F + projectile.velocity / 2;
			newDust.position += projectile.velocity.RotatedBy(-Math.PI / 2.4f, default(Vector2));
			newDust.fadeIn = 0.5F;
			newDust.noGravity = true;

			for (int i = 0; i < 1; i++)
			{
				newDust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1f)];
				newDust.velocity *= 0.5F;
				newDust.scale *= 1.3F;
				newDust.fadeIn = 1F;
				newDust.noGravity = true;
			}


			return true;
		}
		public override bool MinionContactDamage()
		{
			return true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180, true);
		}
		public override void Kill(int timeLeft)
		{
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Main.rand.Next(0) / 100), (float)Main.rand.Next(0, 0), mod.ProjectileType("Explosion"), projectile.damage + 10, 0f, projectile.owner, 0f, 0f);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 50;
			projectile.height = 50;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int i = 0; i < 20; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num].velocity *= 3f;
				Main.dust[num].noGravity = true;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int k = 0; k < 3; k++)
			{
				float scaleFactor = 0.33f;
				if (k == 1)
				{
					scaleFactor = 0.66f;
				}
				else if (k == 2)
				{
					scaleFactor = 1f;
				}
				int num3 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_417_cp_0 = Main.gore[num3];
				expr_417_cp_0.velocity.X = expr_417_cp_0.velocity.X + 1f;
				Gore expr_435_cp_0 = Main.gore[num3];
				expr_435_cp_0.velocity.Y = expr_435_cp_0.velocity.Y + 1f;
				num3 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_4E0_cp_0 = Main.gore[num3];
				expr_4E0_cp_0.velocity.X = expr_4E0_cp_0.velocity.X - 1f;
				Gore expr_4FE_cp_0 = Main.gore[num3];
				expr_4FE_cp_0.velocity.Y = expr_4FE_cp_0.velocity.Y + 1f;
				num3 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_5A9_cp_0 = Main.gore[num3];
				expr_5A9_cp_0.velocity.X = expr_5A9_cp_0.velocity.X + 1f;
				Gore expr_5C7_cp_0 = Main.gore[num3];
				expr_5C7_cp_0.velocity.Y = expr_5C7_cp_0.velocity.Y - 1f;
				num3 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_672_cp_0 = Main.gore[num3];
				expr_672_cp_0.velocity.X = expr_672_cp_0.velocity.X - 1f;
				Gore expr_690_cp_0 = Main.gore[num3];
				expr_690_cp_0.velocity.Y = expr_690_cp_0.velocity.Y - 1f;
			}
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 10;
			projectile.height = 10;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14, 1f, 0f);
			for (int l = 0; l < 40; l++)
			{
				int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, -2f, 0, default(Color), 2f);
				Main.dust[num4].noGravity = true;
				Dust expr_824_cp_0 = Main.dust[num4];
				expr_824_cp_0.position.X = expr_824_cp_0.position.X + ((float)Main.rand.Next(-50, 51) * 0.05f - 1.5f);
				Dust expr_858_cp_0 = Main.dust[num4];
				expr_858_cp_0.position.Y = expr_858_cp_0.position.Y + ((float)Main.rand.Next(-50, 51) * 0.05f - 1.5f);
				if (Main.dust[num4].position != projectile.Center)
				{
					Main.dust[num4].velocity = projectile.DirectionTo(Main.dust[num4].position) * 6f;
				}
			}
		}
	}
}
}