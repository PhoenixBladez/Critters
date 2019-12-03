using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Potions
{
    public class ColdHeartBrew : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coldheart Brew");
			Tooltip.SetDefault("Hitting foes will pelt them with icicles\nIncreases defense by 3\nAttacks on foes may chill the player");
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

            item.buffType = mod.BuffType("ColdHeart_Buff");
            item.buffTime = 14600;

            item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryovineItem", 1);
            recipe.AddIngredient(ItemID.Shiverthorn, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
