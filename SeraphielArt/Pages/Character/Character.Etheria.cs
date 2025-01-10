using static SeraphielArt.Pages.Character.CharacterData;

namespace SeraphielArt.Pages.Character
{
    public static partial class CharacterList
    {
        public static partial class Etheria
        {
            public class AliceBlessland : CharacterData.Character
            {
                private static readonly AliceBlessland Self = new();
                public static readonly AliceHuman HumanEtherian = new(Self);
                public static readonly AliceVampire Vampire = new(Self);

                public AliceBlessland() : base(
                    name: "Alice Blessland",
                    api: "Alice",
                    description: @$"
A Human girl fearing from the distant world of Etheria, a land where an ancient God had become the basis of the planet lifeforce and give the land the qualities of elemental energy, certain people are capable to harness those energies and use them for different means, Alice is one of those people, leading her journey to become an alchemist, someone who is capable to use both science and magic to produce objects that go beyond the laws of the universe as they are understood.
From losing her only living relative and her home, to traveling around Etheria, to finding out the truth and refine herself to who she is today, Alice is kind woman willing to give her all for those she has a bond with. A hopeless romantic at heart, Alice is easy to fluster, leading her to perhaps being an easy target for someone to take her into a long-term relationship...
")
                { }
            }
            public class EdgarCrowbell : CharacterData.Character
            {
                private static readonly EdgarCrowbell Self = new();
                public static readonly EdgarHomunculus Homunculus = new(Self);
                public static readonly EdgarSerpentLord SerpentLord = new(Self);
                public static readonly EdgarSerpent Serpent = new(Self);
                public static readonly EdgarSeraph Seraph = new(Self);

                public EdgarCrowbell() : base(
                    name: "Edgar Crowbell",
                    api: "Edgar",
                    description: @$"
Edgar is an artificial being created with alchemy and the purpose to kill one of the founding gods of the planet. Though he was freed from his predestined fate of weapon by the combined choices of many, allowing Edgar to live a relatively normal life as a human.
As time went by, he faced many trials and tribulations and eventually found out of the truth behind his origins, Edgar lost his adoptive relatives and thus became much more protective of the ones around him. He is still to this day a quite off but gentle soul, who many would find hard to approach at first, but can easily find reliance on him regardless, Edgar would do his utmost to sustain his old codes and fight for what he thinks is right. Yet, after losing his brother, the only relative he had left, he seemed to want to belong somewhere...
")
                { }
            }
        }

        public static partial class Etheria
        {
            public class AliceHuman(CharacterData.Character self) : CharacterVersion(
                character: self,
                species: Species.HumanEtheria,
                faction: Faction.Etherian,
                strength: 7,
                intelligence: 9,
                age: 24,
                height: 175,
                shortDescription: "A skilled alchemist from another world",
                altName: "Alice"
            )
            { }
            public class AliceVampire(CharacterData.Character self) : CharacterVersion(
                character: self,
                species: Species.HumanEtheria | Species.Vampire,
                faction: Faction.Etherian,
                strength: 9,
                intelligence: 9,
                mana: 3,
                age: 28,
                height: 175,
                shortDescription: "An alchemist turned vampire for her loved one",
                altName: "Vampire"
            )
            { }

            public class EdgarHomunculus(CharacterData.Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria,
                faction: Faction.Etherian,
                strength: 11,
                intelligence: 9,
                age: 29,
                height: 164,
                shortDescription: "A powerful artificial lifeform from another world",
                altName: "Homunculus"
            )
            { }
            public class EdgarSerpentLord(CharacterData.Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria | Species.ArtificialHybridian,
                faction: Faction.Etherian,
                strength: 15,
                intelligence: 5,
                age: 33,
                height: 187,
                shortDescription: "The creation of the love and despair of Olivia",
                altName: "Serpent Lord"
            )
            { }
            public class EdgarSerpent(CharacterData.Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria | Species.ArtificialHybridian,
                faction: Faction.Etherian,
                strength: 13,
                intelligence: 9,
                age: 33,
                height: 164,
                shortDescription: "A powerful serpent who took control of his own fate",
                altName: "Serpent"
            )
            { }
            public class EdgarSeraph(CharacterData.Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria | Species.Seraph,
                faction: Faction.Etherian,
                strength: 11,
                intelligence: 9,
                age: 29,
                height: 164,
                shortDescription: "A powerful being achieved the ultimate ascension level in all of Solumniar",
                altName: "Seraph"
            )
            { }
        }
    }
}
