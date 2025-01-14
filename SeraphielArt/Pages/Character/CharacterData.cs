using System.Text;

namespace SeraphielArt.Pages.Character
{
    public static class CharacterData
    {
        /// <summary>
        /// Existing species which the characters can be a combination of.
        /// </summary>
        [Flags]
        public enum Species
        {
            None = 0,
            HumanSolumanir = 1 << 0,
            HumanEtheria = HumanSolumanir << 1,
            HomunculusEtheria = HumanEtheria << 1,
            ElfHuvian = HomunculusEtheria << 1,
            ElfVaxalif = ElfHuvian << 1,
            FoxHuvian = ElfVaxalif << 1,
            FoxVaxalif = FoxHuvian << 1,
            FoxTu = FoxVaxalif << 1,
            WolfHuvian = FoxTu << 1,
            WolfVaxalif = WolfHuvian << 1,
            ArtificialHybridian = WolfVaxalif << 1,
            Merfolk = ArtificialHybridian << 1,
            Siren = Merfolk << 1,
            Angel = Siren << 1,
            Seraph = Angel << 1,
            Vampire = Seraph << 1,
            Werewolf = Vampire << 1,
            Werefox = Werewolf << 1,
            Lich = Werefox << 1,
            Nereid = Lich << 1,
            Dryad = Nereid << 1
        }

        /// <summary>
        /// String names for each existing species
        /// </summary>
        private static Dictionary<Species, string> SpeciesNames { get; } = new()
        {
            {Species.HumanSolumanir, "Human"},
            {Species.HumanEtheria, "Etherian Human"},
            {Species.HomunculusEtheria, "Etherian Homunculus"},
            {Species.ElfHuvian, "Huvia Elf"},
            {Species.ElfVaxalif, "Vaxalif Elf"},
            {Species.FoxHuvian, "Huvia Fox Hybridian"},
            {Species.FoxVaxalif, "Vaxalif Fox Hybridian"},
            {Species.FoxTu, "Tu Fox Hybridian"},
            {Species.WolfHuvian, "Huvia Wolf Hybridian"},
            {Species.WolfVaxalif, "Vaxalif Wolf Hybridian"},
            {Species.ArtificialHybridian, "Artificial Hybridian"},
            {Species.Merfolk, "Merfolk"},
            {Species.Siren, "Siren"},
            {Species.Angel, "Angel"},
            {Species.Seraph, "Seraph"},
            {Species.Vampire, "Vampire"},
            {Species.Werewolf, "Werewolf"},
            {Species.Werefox, "Werefox"},
            {Species.Lich, "Lich"},
            {Species.Nereid, "Nereid"},
            {Species.Dryad, "Dryad"},
        };

        /// <summary>
        /// Description for each existing species
        /// </summary>
        private static Dictionary<Species, string> SpeciesDescriptions { get; } = new()
        {
            {Species.HumanSolumanir, ""},
            {Species.HumanEtheria, ""},
            {Species.HomunculusEtheria, ""},
            {Species.ElfHuvian, ""},
            {Species.ElfVaxalif, ""},
            {Species.FoxHuvian, ""},
            {Species.FoxVaxalif, ""},
            {Species.FoxTu, ""},
            {Species.WolfHuvian, ""},
            {Species.WolfVaxalif, ""},
            {Species.ArtificialHybridian, ""},
            {Species.Merfolk, ""},
            {Species.Siren, ""},
            {Species.Angel, ""},
            {Species.Seraph, ""},
            {Species.Vampire, ""},
            {Species.Werewolf, ""},
            {Species.Werefox, ""},
            {Species.Lich, ""},
            {Species.Nereid, ""},
            {Species.Dryad, ""},
        };

        /// <summary>
        /// Obtain the name in string format for a character's species, can be multiple species
        /// </summary>
        /// <param name="species">Character species to evaluate</param>
        /// <returns>Combined descriptions of each species. One per line.</returns>
        public static string GetSpeciesName(Species species)
        {
            List<string> name = [];

            foreach (KeyValuePair<Species, string> spec in SpeciesNames)
            {
                if ((species & spec.Key) == spec.Key)
                {
                    name.Add(spec.Value);
                }
            }

            return string.Join("|", name);
        }

        /// <summary>
        /// Obtain a description for a character's species, can be multiple species
        /// </summary>
        /// <param name="species">Character species to evaluate</param>
        /// <returns>Combined descriptions of each species. One per line.</returns>
        public static string GetSpeciesDescription(Species species)
        {
            List<string> description = [];

            foreach (KeyValuePair<Species, string> spec in SpeciesDescriptions)
            {
                if ((species & spec.Key) == spec.Key)
                {
                    description.Add(spec.Value);
                }
            }

            return string.Join("|", description);
        }

        /// <summary>
        /// Existing factions within the world of Solumanir
        /// </summary>
        [Flags]
        public enum Faction
        {
            None = 0,
            Etherian = 1 << 0,
            FromHuvia = Etherian << 1,
            FromVaxalif = FromHuvia << 1,
            FromTu = FromVaxalif << 1,
            FromHeaven = FromTu << 1,
            ChuchMember = FromHeaven << 1,
            FromOutside = ChuchMember << 1,
        }

        /// <summary>
        /// String names for each existing species
        /// </summary>
        private static Dictionary<Faction, string> FactionNames { get; } = new()
        {
            {Faction.Etherian, "Etherian" },
            {Faction.FromHuvia, "From Huvia"},
            {Faction.FromVaxalif, "From Vaxaliv"},
            {Faction.FromTu, "From Tu"},
            {Faction.FromHeaven, "From Heaven"},
            {Faction.ChuchMember, "Church members"},
            {Faction.FromOutside, "Others"},
        };
        
        /// <summary>
        /// Obtain the name in string format for a character's species, can be multiple species
        /// </summary>
        /// <param name="species">Character species to evaluate</param>
        /// <returns>Combined descriptions of each species. One per line.</returns>
        public static string GetFactionName(Faction species)
        {
            List<string> name = [];

            foreach (KeyValuePair<Faction, string> spec in FactionNames)
            {
                if ((species & spec.Key) == spec.Key)
                {
                    name.Add(spec.Value);
                }
            }

            return string.Join("|", name);
        }

        /// <summary>
        /// Absract object containing information pertaining a character.
        /// </summary>
        /// <param name="name">Character name</param>
        /// <param name="name">Character api call path</param>
        /// <param name="description">Character general description</param>
        public abstract class CharacterBase(string name, string api, string description = "")
        {
            public string Name { get; } = name;
            public string Api { get; } = api;
            public string Description { get; } = description.Trim();
        }

        /// <summary>
        /// Unique version of a character in a certain point of their life
        /// </summary>
        /// <param name="character">Character this version is based on</param>
        /// <param name="species">Species of the character</param>
        /// <param name="faction">Factions the character is part of</param>
        /// <param name="strength">Character strenght stat</param>
        /// <param name="intelligence">Character intelligence stat</param>
        /// <param name="age">Character age</param>
        /// <param name="height">Character height</param>
        /// <param name="shortDescription">Character description tied to this version</param>
        /// <param name="altName">Alternative name (if given)</param>
        /// <param name="mana">Character mana stat</param>
        /// <param name="manaGem">Character mana gem stat</param>
        /// <param name="manaAscended">Character ascended mana gem stat</param>
        public abstract class CharacterVersion(
            CharacterBase character,
            Species species,
            Faction faction,
            int strength,
            int intelligence,
            int age,
            int height,
            string shortDescription,
            string altName,
            int? mana = null,
            int? manaGem = null,
            int? manaAscended = null)
        {
            public CharacterBase Character { get; } = character;
            public Species Species { get; } = species;
            public Faction Faction { get; } = faction;
            public string? AltName { get; } = altName;
            public int Strength { get; } = strength;
            public int Intelligence { get; } = intelligence;
            public int?[] Mana { get; } = [mana, manaGem, manaAscended];
            public int Age { get; } = age;
            public int Height { get; } = height;
            public string? ShortDescription { get; } = shortDescription;
        }
    }
}
