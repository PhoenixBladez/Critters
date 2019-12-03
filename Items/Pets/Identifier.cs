using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Pets
{
	public class Identifier : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Identifier");
			Tooltip.SetDefault("Summons a friendly IFO");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Fish);
			item.shoot = mod.ProjectileType("UFOPet");
			item.buffType = mod.BuffType("UFOPet_Buff");
			item.UseSound = SoundID.Item8;
			item.rare = 5;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override bool CanUseItem(Player player)
		{
			return player.miscEquips[0].IsAir;
		}
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "UFOItem", 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}