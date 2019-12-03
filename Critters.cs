using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Initializers;
using Terraria.IO;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.Linq;
using Terraria.UI;
using Terraria.GameContent.UI;
using Terraria.Graphics;

namespace Critters
{
	class Critters : Mod
	{
		public Critters()
		{
		}
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Iron Bar" + Lang.GetItemNameValue(ItemType("Iron Bar")), new int[]
			{
				ItemID.IronBar,
				ItemID.LeadBar
			});
			RecipeGroup.RegisterGroup("IronBars", group);
			group = new RecipeGroup(() => Lang.misc[37] + " Wood" + Lang.GetItemNameValue(ItemType("Wood")), new int[]
			{
				9,
				620,
				619,
				911,
				621,
				2260,
				1729
			});
			RecipeGroup.RegisterGroup("Woods", group);
		}
	}
}
