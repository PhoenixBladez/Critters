using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Furniture
{
	public class Streetlamp : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Streetlamp");
		}


		public override void SetDefaults()
		{
            item.width = 18;
			item.height = 54;
            item.value = 6000;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Streetlamp");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"Brightbulb", 1);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}