using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Core;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace TestMod.Items.Materials
{
    public class VampireFang : ModItem
    {
        public override void SetStaticDefaults()
        {
                    CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.height = 8;
            Item.width = 8;

             Item.maxStack = 9999;
            
        }
    }
}