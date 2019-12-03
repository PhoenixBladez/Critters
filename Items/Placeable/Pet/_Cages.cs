using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Placeable.Pet
{
	public class BlossomCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blossmoon Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Blossom_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BlossmoonItem", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class CleftCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cleft Hopper Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Cleft_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CleftItem", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class CrismiteCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crismite Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("Crismite_Tile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"CrismiteItem", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class GreenCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Green Slime Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("GreenCage");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BabySlimeGreen", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class BlueCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Blue Slime Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("BlueCage");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BabySlimeBlue", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class IceCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Ice Slime Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("IceCage");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BabySlimeIce", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class SandCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Sand Slime Cage");
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("SandCage");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BabySlimeSand", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
		public class RainbowCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Rainbow Slime Cage");
		    Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}


		public override void SetDefaults()
		{
            item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(0, 0, 30, 0);;

            item.maxStack = 999;

            item.useStyle = 1;
			item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("RainbowCage");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BabySlimeRainbow", 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}