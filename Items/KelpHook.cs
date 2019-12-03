using System;
using Terraria.ModLoader;

namespace Critters.Items
{
	internal class KelpHook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kelp Swinger");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(1236);
			item.shootSpeed = 18f;
			item.shoot = mod.ProjectileType("KelpHookHead");
		}
	}
}
