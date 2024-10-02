namespace PrismBox.core.script_it.prism_it_comps
{
    /// <summary>
    /// An Item Component which marks an item "Deprecated", which will default all of its values and render it useless. <br></br>
    /// Useful for getting rid of items which no longer serve a particular purpose (such as Vanilla total conversions).
    /// </summary>
    internal class DeprecatedComponent : ItemComponent
    {
        public override void C_SetDefaults(Item it)
        {
            it.accessory = false;
            it.autoReuse = false;
            it.beingGrabbed = false;
            it.buy = false;
            it.buyOnce = false;
            it.cartTrack = false;
            it.channel = false;
            it.chlorophyteExtractinatorConsumable = false;
            it.consumable = false;
            it.DD2Summon = false;
            it.expert = false;
            it.expertOnly = false;
            it.favorited = false;
            it.flame = false;
            it.hasVanityEffects = false;
            it.instanced = false;
            it.isAShopItem = false;
            it.master = false;
            it.masterOnly = false;
            it.material = false;
            it.mech = false;
            it.newAndShiny = false;
            it.noMelee = false;
            it.notAmmo = false;
            it.noUseGraphic = false;
            it.noWet = false;
            it.potion = false;
            it.questItem = false;
            it.sentry = false;
            it.shimmered = false;
            it.shootsEveryUse = false;
            it.social = false;
            it.uniqueStack = false;
            it.useTurn = false;
            it.vanity = false;
            it.wornArmor = false;

            it.color = Color.Gray;

            it.knockBack = 0f;
            it.scale = 1f;
            it.shootSpeed = 0f;

            it.axe = 0;
            it.backSlot = 0;
            it.bait = 0;
            it.backSlot = 0;
            it.balloonSlot = 0;
            it.beardSlot = 0;
            it.bodySlot = 0;
            it.buffTime = 0;
            it.buffType = 0;
            it.createTile = -1;
            it.createWall = -1;
            it.crit = 0;
            it.damage = -1;
            it.defense = 0;
            it.dye = 0;
            it.faceSlot = 0;
            it.fishingPole = 0;
            it.frontSlot = 0;
            it.glowMask = -1;
            it.hairDye = -1;
            it.hammer = 0;
            it.headSlot = 0;
            it.healLife = 0;
            it.healMana = 0;
            it.height = 0;
            it.legSlot = 0;
            it.lifeRegen = 0;
            it.makeNPC = -1;
            it.mana = 0;
            it.manaIncrease = 0;
            it.maxStack = 1;
            it.mountType = -1;
            it.neckSlot = 0;
            it.noGrabDelay = 100;
            it.pick = 0;
            it.placeStyle = 0;
            it.prefix = 0;
            it.reuseDelay = 0;
            it.shieldSlot = 0;
            it.shoeSlot = 0;
            it.shoot = ProjectileID.None;
            it.shopSpecialCurrency = -1;
            it.stack = 1;
            it.tileBoost = 0;
            it.tileWand = -1;
            it.useAnimation = 100;
            it.useTime = 100;
            it.waistSlot = 0;
            it.width = 0;
            it.wingSlot = 0;

            it.BestiaryNotes = "A once powerful item, now devoid.";

            it.ammo = AmmoID.None;
            it.holdStyle = ItemHoldStyleID.None;
            it.rare = ItemRarityID.White;
            it.shopCustomPrice = null;
            it.useAmmo = AmmoID.None;
            it.UseSound = null;
            it.useStyle = ItemUseStyleID.None;

            base.C_SetDefaults(it);
        }

        public override void C_ModTooltips(Item it, List<TooltipLine> tt)
        {
            tt.Clear();
            tt.Add(new TooltipLine(Mod, "deprecatedName", $"{it.Name} (Deprecated)"));
            tt.Add(new(Mod, "deprecateedDesc", 
                "This item as been deprecated.\n" +
                "This item serves no function and can be safely discarded."));

            base.C_ModTooltips(it, tt);
        }
    }
}