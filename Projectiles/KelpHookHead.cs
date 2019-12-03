using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Critters.Projectiles
{
	public class KelpHookHead : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 16;
			projectile.aiStyle = 7;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.timeLeft *= 10;
			Main.projHook[projectile.type] = true;
		}

		public override bool PreAI()
		{
			if (Main.player[projectile.owner].dead || Main.player[projectile.owner].stoned || Main.player[projectile.owner].webbed || Main.player[projectile.owner].frozen)
			{
				projectile.Kill();
				return false;
			}
			Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
			Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			float num = mountedCenter.X - vector.X;
			float num2 = mountedCenter.Y - vector.Y;
			float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			projectile.rotation = (float)Math.Atan2((double)num2, (double)num) - 1.57f;
			if (projectile.ai[0] == 0f)
			{
				if (num3 > 300f)
				{
					projectile.ai[0] = 1f;
				}
				Vector2 value = projectile.Center - new Vector2(5f);
				Vector2 value2 = projectile.Center + new Vector2(5f);
				Point point = Utils.ToTileCoordinates(value - new Vector2(16f));
				Point point2 = Utils.ToTileCoordinates(value2 + new Vector2(32f));
				int num4 = point.X;
				int num5 = point2.X;
				int num6 = point.Y;
				int num7 = point2.Y;
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int i = num4; i < num5; i++)
				{
					int j = num6;
					while (j < num7)
					{
						if (Main.tile[i, j] == null)
						{
							Main.tile[i, j] = new Tile();
						}
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						if (value.X + 10f > vector2.X && value.X < vector2.X + 16f && value.Y + 10f > vector2.Y && value.Y < vector2.Y + 16f && Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 314) && (projectile.type != 403 || Main.tile[i, j].type == 314))
						{
							if (Main.player[projectile.owner].grapCount < 10)
							{
								Main.player[projectile.owner].grappling[Main.player[projectile.owner].grapCount] = projectile.whoAmI;
								Main.player[projectile.owner].grapCount++;
							}
							if (Main.myPlayer == projectile.owner)
							{
								int num8 = 0;
								int num9 = -1;
								int num10 = 100000;
								int num11 = 1;
								for (int k = 0; k < 1000; k++)
								{
									if (Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type)
									{
										if (Main.projectile[k].timeLeft < num10)
										{
											num9 = k;
											num10 = Main.projectile[k].timeLeft;
										}
										num8++;
									}
								}
								if (num8 > num11)
								{
									Main.projectile[num9].Kill();
								}
							}
							WorldGen.KillTile(i, j, true, true, false);
							Main.PlaySound(0, i * 16, j * 16, 1, 1f, 0f);
							projectile.velocity.X = 0f;
							projectile.velocity.Y = 0f;
							projectile.ai[0] = 2f;
							projectile.position.X = (float)(i * 16 + 8 - projectile.width / 2);
							projectile.position.Y = (float)(j * 16 + 8 - projectile.height / 2);
							projectile.damage = 0;
							projectile.netUpdate = true;
							if (Main.myPlayer == projectile.owner)
							{
								NetMessage.SendData(13, -1, -1, null, projectile.owner, 0f, 0f, 0f, 0, 0, 0);
								break;
							}
							break;
						}
						else
						{
							j++;
						}
					}
					if (projectile.ai[0] == 2f)
					{
						return false;
					}
				}
				return false;
			}
			if (projectile.ai[0] == 1f)
			{
				float num12 = 24f;
				if (num3 < 24f)
				{
					projectile.Kill();
				}
				num3 = num12 / num3;
				num *= num3;
				num2 *= num3;
				projectile.velocity.X = num;
				projectile.velocity.Y = num2;
				return false;
			}
			if (projectile.ai[0] == 2f)
			{
				int num13 = (int)(projectile.position.X / 16f) - 1;
				int num14 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 2;
				int num15 = (int)(projectile.position.Y / 16f) - 1;
				int num16 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 2;
				if (num13 < 0)
				{
					num13 = 0;
				}
				if (num14 > Main.maxTilesX)
				{
					num14 = Main.maxTilesX;
				}
				if (num15 < 0)
				{
					num15 = 0;
				}
				if (num16 > Main.maxTilesY)
				{
					num16 = Main.maxTilesY;
				}
				bool flag = true;
				for (int l = num13; l < num14; l++)
				{
					for (int m = num15; m < num16; m++)
					{
						if (Main.tile[l, m] == null)
						{
							Main.tile[l, m] = new Tile();
						}
						Vector2 vector3;
						vector3.X = (float)(l * 16);
						vector3.Y = (float)(m * 16);
						if (projectile.position.X + (float)(projectile.width / 2) > vector3.X && projectile.position.X + (float)(projectile.width / 2) < vector3.X + 16f && projectile.position.Y + (float)(projectile.height / 2) > vector3.Y && projectile.position.Y + (float)(projectile.height / 2) < vector3.Y + 16f && Main.tile[l, m].nactive() && (Main.tileSolid[(int)Main.tile[l, m].type] || Main.tile[l, m].type == 314 || Main.tile[l, m].type == 5))
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					projectile.ai[0] = 1f;
					return false;
				}
				if (Main.player[projectile.owner].grapCount < 1)
				{
					Main.player[projectile.owner].grappling[Main.player[projectile.owner].grapCount] = projectile.whoAmI;
					Main.player[projectile.owner].grapCount++;
					return false;
				}
			}
			return false;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = ModContent.GetTexture("Critters/Projectiles/KelpHook_Chain");
			Vector2 vector = projectile.Center;
			Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = null;
			Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
			float num = (float)texture.Height;
			Vector2 vector2 = mountedCenter - vector;
			float rotation = (float)Math.Atan2((double)vector2.Y, (double)vector2.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(vector.X) && float.IsNaN(vector.Y))
			{
				flag = false;
			}
			if (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y))
			{
				flag = false;
			}
			while (flag)
			{
				if ((double)vector2.Length() < (double)num + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 value = vector2;
					value.Normalize();
					vector += value * num;
					vector2 = mountedCenter - vector;
					Color color = Lighting.GetColor((int)vector.X / 16, (int)((double)vector.Y / 16.0));
					color = projectile.GetAlpha(color);
					Main.spriteBatch.Draw(texture, vector - Main.screenPosition, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
				}
			}
		}
	}
}
