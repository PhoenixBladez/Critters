using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Fish
{
    public class FishFingers : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fish Fingers");
			Tooltip.SetDefault("Provides the 'Well Fed' buff\n'Crispy and delicious'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 24;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.useStyle = 1;
            item.useTime = item.useAnimation = 30;
			
			item.buffType = BuffID.WellFed;
			item.buffTime = 72000;
            item.noMelee = true;
            item.consumable = true;
			item.UseSound = SoundID.Item2;
            item.autoReuse = false;

        }
		public override void AddRecipes()
		{			
			ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "RawFish", 3);
            recipe2.AddTile(TileID.CookingPots);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
		}
    }
}
