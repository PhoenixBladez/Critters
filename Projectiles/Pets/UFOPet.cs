using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.Pets
{
	public class UFOPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("IFO");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead)
				modPlayer.UFOPet = false;

			if (modPlayer.UFOPet)
				projectile.timeLeft = 2;
		}

	}
}