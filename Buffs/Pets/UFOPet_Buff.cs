using Terraria;
using Terraria.ModLoader;

namespace Critters.Buffs.Pets
{
	public class UFOPet_Buff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("IFO");
			Description.SetDefault("'It's found a new home'");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<MyPlayer>().UFOPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("UFOPet")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("UFOPet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}