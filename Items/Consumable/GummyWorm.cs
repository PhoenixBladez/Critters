using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class GummyWorm : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gummy Worm");
			Tooltip.SetDefault("'Hopefully fish like gummy snacks'");
		}


        public override void SetDefaults()
        {
            item.width = 20;
			item.height = 12;
            item.rare = 1;
            item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;
			item.bait = 30;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BabySlimeBlue", 1);
            recipe.AddIngredient(ItemID.Worm, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
