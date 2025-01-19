using static SeraphielArt.Pages.Character.CharacterData;

namespace SeraphielArt.Pages.Character
{
    public static partial class CharacterList
    {
        public static partial class Etheria
        {
            public class AliceBlessland : CharacterBase
            {
                public static readonly AliceBlessland Self = new();
                public static CharacterVersion HumanEtherian => AliceHuman;
                public static CharacterVersion Vampire => AliceVampire;
                public override CharacterVersion[] Versions { get; } = 
                [
                    HumanEtherian,
                    Vampire,
                ];

                public AliceBlessland() : base(
                    name: "Alice Blessland",
                    api: APIs.Alice,
                    description: @$"
A Human girl fearing from the distant world of Etheria, a land where an ancient God had become the basis of the planet lifeforce and give the land the qualities of elemental energy, certain people are capable to harness those energies and use them for different means, Alice is one of those people, leading her journey to become an alchemist, someone who is capable to use both science and magic to produce objects that go beyond the laws of the universe as they are understood.
<br>From losing her only living relative and her home, to traveling around Etheria, to finding out the truth and refine herself to who she is today, Alice is kind woman willing to give her all for those she has a bond with. A hopeless romantic at heart, Alice is easy to fluster, leading her to perhaps being an easy target for someone to take her into a long-term relationship...
")
                { }
            }
            public class EdgarCrowbell : CharacterBase
            {
                public static readonly EdgarCrowbell Self = new();
                public static CharacterVersion Homunculus => EdgarHomunculus;
                public static CharacterVersion SerpentLord => EdgarSerpentLord;
                public static CharacterVersion Serpent => EdgarSerpent;
                public static CharacterVersion Seraph => EdgarSeraph;
                public override CharacterVersion[] Versions { get; } =
                [
                    Homunculus,
                    SerpentLord,
                    Serpent,
                    Seraph,
                ];

                public EdgarCrowbell() : base(
                    name: "Edgar Crowbell",
                    api: APIs.Edgar,
                    description: @$"
Edgar is an artificial being created with alchemy and the purpose to kill one of the founding gods of the planet. Though he was freed from his predestined fate of weapon by the combined choices of many, allowing Edgar to live a relatively normal life as a human.
<br>As time went by, he faced many trials and tribulations and eventually found out of the truth behind his origins, Edgar lost his adoptive relatives and thus became much more protective of the ones around him. He is still to this day a quite off but gentle soul, who many would find hard to approach at first, but can easily find reliance on him regardless, Edgar would do his utmost to sustain his old codes and fight for what he thinks is right. Yet, after losing his brother, the only relative he had left, he seemed to want to belong somewhere...
")
                { }
            }
        }

        public static partial class Etheria
        {
            static CharacterVersion AliceHuman { get; } = new(
                Character: AliceBlessland.Self,
                Species: Species.HumanEtheria,
                Faction: Faction.Etherian,
                Strength: 7,
                Intelligence: 9,
                Age: 24,
                Height: 175,
                ShortDescription: "A skilled alchemist from another world",
                AltName: "Alice"
            );
            static CharacterVersion AliceVampire { get; } = new(
                Character: AliceBlessland.Self,
                Species: Species.HumanEtheria | Species.Vampire,
                Faction: Faction.Etherian,
                Strength: 9,
                Intelligence: 9,
                Mana: 3,
                Age: 28,
                Height: 175,
                ShortDescription: "An alchemist turned vampire for her loved one",
                AltName: "Vampire"
            );

            static CharacterVersion EdgarHomunculus { get; } = new(
                Character: EdgarCrowbell.Self,
                Species: Species.HomunculusEtheria,
                Faction: Faction.Etherian,
                Strength: 11,
                Intelligence: 9,
                Age: 29,
                Height: 164,
                ShortDescription: "A powerful artificial lifeform from another world",
                AltName: "Homunculus"
            );
            static CharacterVersion EdgarSerpentLord { get; } = new(
                Character: EdgarCrowbell.Self,
                Species: Species.HomunculusEtheria | Species.ArtificialHybridian,
                Faction: Faction.Etherian,
                Strength: 15,
                Intelligence: 5,
                Age: 33,
                Height: 187,
                ShortDescription: "The creation of the love and despair of Olivia",
                AltName: "Serpent Lord"
            );
            static CharacterVersion EdgarSerpent { get; } = new(
                Character: EdgarCrowbell.Self,
                Species: Species.HomunculusEtheria | Species.ArtificialHybridian,
                Faction: Faction.Etherian,
                Strength: 13,
                Intelligence: 9,
                Age: 33,
                Height: 164,
                ShortDescription: "A powerful serpent who took control of his own fate",
                AltName: "Serpent"
            );
            static CharacterVersion EdgarSeraph { get; } = new(
                Character: EdgarCrowbell.Self,
                Species: Species.HomunculusEtheria | Species.Seraph,
                Faction: Faction.Etherian,
                Strength: 11,
                Intelligence: 9,
                Age: 29,
                Height: 164,
                ShortDescription: "A powerful being achieved the ultimate ascension level in all of Solumniar",
                AltName: "Seraph"
            );
        }
    }
}
