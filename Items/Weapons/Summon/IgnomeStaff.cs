using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Critters.Items.Weapons.Summon
{
	public class IgnomeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ignome Scepter");
            Tooltip.SetDefault("Summons volatile Ignomes that quickly combust");
			CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/IgnomeStaff");

        }


		public override void SetDefaults()
		{
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 3, 0);
            item.rare = 8;
            item.mana = 12;
            item.damage = 81;
            item.knockBack = 1f;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;    
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("IgnomeSummon");
            item.UseSound = SoundID.Item44;
        }
					public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        
        public override bool UseItem(Player player)
        {
            if(player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture;
			texture = Main.itemTexture[item.type];
			spriteBatch.Draw
			(
				ModContent.GetTexture("Critters/Glowmask/IgnomeStaff"),
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
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			return player.altFunctionUse != 2;
            position = Main.MouseWorld;
            speedX = speedY = 0;
            return true;
        }
		  public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IgnomeItem", 6);
	           recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);		
            recipe.AddIngredient(ItemID.LunarTabletFragment, 12);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}