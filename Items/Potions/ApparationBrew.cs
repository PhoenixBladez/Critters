using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Potions
{
    public class ApparationBrew : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apparation Brew");
			Tooltip.SetDefault("Transforms the player into an invulnerable ghost\nAs a ghost, the player's movement speed increases by 60%\nGhosts are unable to use items or regenerate life");
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

            item.buffType = mod.BuffType("Apparition_Buff");
            item.buffTime = 360;

            item.UseSound = SoundID.Item3;
        }
		public override bool CanUseItem(Player player)
		{
			player.AddBuff(BuffID.Cursed, 420);
			return true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GhostReedItem", 1);
            recipe.AddIngredient(ItemID.Waterleaf, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
