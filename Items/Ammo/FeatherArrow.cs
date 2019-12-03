using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Ammo
{
	class FeatherArrow : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plumed Arrow");
            Tooltip.SetDefault("'Flies straight and quickly finds its mark'");
        }
        public override void SetDefaults()
        {
            item.width = 14;
			item.height = 40;
            item.value = Item.buyPrice(0, 0, 0, 6);
            item.rare = 1;

            item.maxStack = 999;

            item.damage = 7;
			item.knockBack = 2f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("FeatherArrow");
            item.shootSpeed = 2.1f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CrimsonFeather"), 1);
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
             recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }		
	}
}
