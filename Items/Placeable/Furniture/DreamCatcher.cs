using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Furniture
{
	public class DreamCatcher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreamcatcher");
			Tooltip.SetDefault("'Provides immunity to the 'Cursed' and 'Darkness' debuffs to nearby players\n'Legends say that it wards off evil spirits'");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.height = 36;
            item.value = 6000;

            item.maxStack = 99;
			item.rare = 4;
            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("DreamCatcher_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CrimsonFeather", 3);
			recipe.AddIngredient(ItemID.Feather, 5);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddRecipeGroup("Woods", 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}