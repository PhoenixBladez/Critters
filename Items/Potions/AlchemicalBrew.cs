using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Potions
{
    public class AlchemicalBrew : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemical Brew");
			Tooltip.SetDefault("Attacks may apply a venemous toxin on foes\nCauses the player to slowly lose life sporadically, especially when injured");
		}


        public override void SetDefaults()
        {
            item.width = 20; 
            item.height = 30;
            item.rare = 2;
            item.maxStack = 30;

            item.useStyle = 2;
            item.useTime = item.useAnimation = 20;

            item.consumable = true;
            item.autoReuse = false;

            item.buffType = mod.BuffType("Alchemical_Buff");
            item.buffTime = 14600;

            item.UseSound = SoundID.Item3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DeathCapItem", 1);
            recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
