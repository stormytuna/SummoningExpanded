using SummoningExpanded.Prefixes;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace SummoningExpanded.Common.GlobalItems {
    public class PrefixGlobalItem : GlobalItem {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.MinionOrSentryWeapon();

        public float SummonTagDamageMult { get; set; } = 1f;

        public override void OnCreate(Item item, ItemCreationContext context) {
            SummonTagDamageMult = 1f;
        }

        public override GlobalItem Clone(Item from, Item to) {
            var clone = (PrefixGlobalItem)base.Clone(from, to);
            clone.SummonTagDamageMult = SummonTagDamageMult;
            return clone;
        }

        private static int[] prefixes = new int[] {
            // Universals
            /*PrefixID.Keen,
            PrefixID.Superior,
            PrefixID.Forceful,
            PrefixID.Broken,
            PrefixID.Damaged,
            PrefixID.Shoddy,
            PrefixID.Hurtful,
            PrefixID.Strong,
            PrefixID.Unpleasant,
            PrefixID.Weak,
            PrefixID.Ruthless,
            PrefixID.Godly,
            PrefixID.Demonic,
            PrefixID.Zealous,
            // Common
            PrefixID.Quick,
            PrefixID.Deadly,
            PrefixID.Agile,
            PrefixID.Nimble,
            PrefixID.Murderous,
            PrefixID.Slow,
            PrefixID.Sluggish,
            PrefixID.Lazy,
            PrefixID.Annoying,
            PrefixID.Nasty,*/
            // Modded
            ModContent.PrefixType<Appalling>(),
            ModContent.PrefixType<Cherished>(),
            ModContent.PrefixType<Crude>(),
            ModContent.PrefixType<Divine>(),
            ModContent.PrefixType<Enigmatic>(),
            ModContent.PrefixType<Exalted>(),
            ModContent.PrefixType<Hefty>(),
            ModContent.PrefixType<Magnificent>(),
            ModContent.PrefixType<Occult>(),
            ModContent.PrefixType<Otherworldly>(),
            ModContent.PrefixType<Strange>(),
            ModContent.PrefixType<Torpid>()
        };

        public override int ChoosePrefix(Item item, UnifiedRandom rand) {
            int chosenPrefix = rand.Next(0, prefixes.Length);
            return prefixes[chosenPrefix];
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (SummonTagDamageMult != 1f) {
                var tooltip = tooltips.FindLast(tip => tip.Name.StartsWith("Prefix"));
                int index = tooltip.Name == "PrefixKnockback" ? tooltips.IndexOf(tooltip) : tooltips.IndexOf(tooltip) + 1;
                int summonTagDamage = (int)MathF.Abs((1f - SummonTagDamageMult) * 100f);
                string plusOrMinus = SummonTagDamageMult < 1f ? "-" : "+";
                TooltipLine newLine = new(Mod, "PrefixSummonTagBonus", $"{plusOrMinus}{summonTagDamage}% summon tag damage");
                newLine.IsModifier = true;
                newLine.IsModifierBad = SummonTagDamageMult < 1f;
                tooltips.Insert(index, newLine);
            }
        }

        public override void SaveData(Item item, TagCompound tag) {
            tag["summonTagDamageMult"] = SummonTagDamageMult;
        }

        public override void LoadData(Item item, TagCompound tag) {
            SummonTagDamageMult = tag.GetFloat("summonTagDamageMult");
        }
    }
}
