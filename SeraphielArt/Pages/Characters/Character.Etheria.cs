using static SeraphielArt.Pages.Characters.CharacterData;

namespace SeraphielArt.Pages.Characters
{
    public static partial class CharacterList
    {
        public static partial class Etheria
        {
            public class AliceBlessland : Character
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
            public class EdgarCrowbell : Character
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
    }
}
