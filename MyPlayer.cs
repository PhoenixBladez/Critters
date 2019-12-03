using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Critters.NPCs;


namespace Critters
{
	public class MyPlayer : ModPlayer
	{
	public bool ColdHeartBuff;
	public bool Alchemical;
	public bool UFOPet = false;
	public override void ResetEffects()
	{
		this.ColdHeartBuff = false;
		this.Alchemical = false;
		UFOPet = false;
	}
	public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
				return;

			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ZoneBeach && Main.rand.Next(35) == 0)
			{
				caughtType = mod.ItemType("FishCrate");
			}
			if (Main.rand.Next(15) == 1 && player.ZoneBeach)
			{
				caughtType = mod.ItemType("KelpfishItem");
			}
			if (Main.rand.Next(15) == 1 && player.ZoneBeach)
			{
				caughtType = mod.ItemType("CoralfishItem");
			}
			if (Main.rand.Next(18) == 1 && player.ZoneBeach && !Main.dayTime)
			{
				caughtType = mod.ItemType("FloaterItem");
			}
			if (Main.rand.Next(15) == 1 && player.ZoneRockLayerHeight)
			{
				caughtType = mod.ItemType("LanternfishItem");
			}
			if (Main.rand.Next(18) == 1 && player.ZoneRockLayerHeight)
			{
				caughtType = mod.ItemType("LuvdiscItem");
			}
		}
	public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
	{
		if (this.ColdHeartBuff && Main.rand.Next(2) == 1)
		{
			Projectile.NewProjectile(target.Center.X+ Main.rand.Next(-5, 5), target.Center.Y - 1000, 0, Main.rand.Next(40, 45), 337, 25, 0, player.whoAmI, 0f, 0f);

		}
		if (this.ColdHeartBuff && Main.rand.Next(10) == 1)
		{
			player.AddBuff(BuffID.Chilled, 120);

		}
		if (this.Alchemical && Main.rand.Next(10) == 3)
		{
			target.AddBuff(mod.BuffType("Alchemical_Buff"), 240);

		}
	}
	public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
	{
		if (this.ColdHeartBuff && Main.rand.Next(2) == 1)
		{
			if (proj.type != 337)
			{
			Projectile.NewProjectile(target.Center.X+ Main.rand.Next(-5, 5), target.Center.Y - 1000, 0, Main.rand.Next(40, 45), 337, 25, 0, player.whoAmI, 0f, 0f);
			}

		}
		if (this.ColdHeartBuff && Main.rand.Next(10) == 1)
		{
			player.AddBuff(BuffID.Chilled, 120);

		}
		if (this.Alchemical && Main.rand.Next(10) == 3)
		{
			target.AddBuff(mod.BuffType("Alchemical_Buff"), 240);

		}
	}
	}
}