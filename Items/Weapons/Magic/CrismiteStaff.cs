using Terraria;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Critters;
using System.Collections.Generic;

namespace Critters.Items.Weapons.Magic
{
	public class CrismiteStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Refractor");
			Tooltip.SetDefault("Shoots out a bright beam of energy");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/Crismite");
		}


		public override void SetDefaults()
		{
			item.damage = 43;
			item.magic = true;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 1;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CrystalProj");
			item.shootSpeed = 20f;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				ModContent.GetTexture("Critters/Glowmask/Crismite"),
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
		}////////
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(mod.ItemType("CrismiteCrystal"), 1);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
             recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
