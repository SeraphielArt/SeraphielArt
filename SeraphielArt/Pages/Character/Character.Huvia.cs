using static SeraphielArt.Pages.Character.CharacterData;

namespace SeraphielArt.Pages.Character
{
    public static partial class CharacterList
    {
        public static partial class Huvia
        {
            public class LeilaAspor : CharacterBase
            {
                public static readonly LeilaAspor Self = new();
                public static CharacterVersion Human => LeilaHuman;
                public static CharacterVersion Dragon => LeilaDragon;
                public static CharacterVersion Dragonfly => LeilaDragonfly;
                public static CharacterVersion[] VampireLord => LeilaVampireLord;
                public override CharacterVersion[] Versions { get; } =
                [
                    Human,
                    Dragon,
                    Dragonfly,
                    .. VampireLord,
                ];

                private LeilaAspor() : base(
                    name: "Leila Aspor Faeloria",
                    api: APIs.Leila,
                    description: @$"
Leila is a human girl coming from a village remotely north of the Huvia Republic. She had a peaceful life and was raised by loving parents until the age of 16. During her 16th year of life her village was raided by demonic species and burned to the ground, causing the death of every person living there.
<br>Leila was rescued by a Huvia knight patrolling the area, the knight brough her back to the capital saving her life and raised her from that day, supporting her education.
<br>Leila completed school and continued studying mana and magic in college, she tried hard and managed to qualify for the sanctuary challenge, facing her past and completing the trials one after the other and obtaining her own mana gem, she graduated 2 later.
<br>Once graduated Leila decided to go on an adventure in the wilderness on her own...
"
                )
                { }
            }
            public class Lucilda : CharacterBase
            {
                public static readonly Lucilda Self = new();
                public static CharacterVersion DawnStar => LucildaDawnStar;
                public static CharacterVersion Angel => LucildaAngel;
                public override CharacterVersion[] Versions { get; } =
                [
                    DawnStar,
                    Angel,
                ];

                private Lucilda() : base(
                    name: "Lucilda Dawn Star",
                    api: APIs.Lucilda,
                    description: @$"
Lucilda is an angel who worked in the Sanctuary as a means to develop technology which would allow angels to use mana in similar ways to the seraphs. Lucilda's focus was on the biological part, but as tens of years went by inside the Sanctuary, she and the rest of the mean began to lose their sanity.
<br>The lead of this research took all its fruits and abandoned the others to rot in the Sanctuary, closing it behind and turning it into a prison. Lucilda was the first one to find out what had happened.
<br>Lucilda used her own research to construct a corrupt gem, though in her madness she was consumed by this gem and transformed into an entity known as Dawn Star. She murdered the other researchers left and let herself rot in the sanctuary, decaying to time itself.
<br>When humans discovered the sanctuary many years later, they began to use its powers to obtain mana gems, which were constructed by Dawn Star, in exchange Dawn Star would copy the memories of others into her own mind, consuming large amounts of memories and eventually losing herself entirely.
"
                )
                { }
            }
        }
        public static partial class Huvia
        {
            static readonly CharacterVersion LeilaHuman = new(
                Character: LeilaAspor.Self,
                Species: Species.HumanSolumanir,
                Faction: Faction.FromHuvia,
                Strength: 5,
                Intelligence: 9,
                Mana: 0,
                ManaGem: 5,
                ManaAscended: 7,
                Age: 22,
                Height: 172,
                ShortDescription: "A skilled mage who just passed her exam",
                AltName: "Human"
            );
            static readonly CharacterVersion LeilaDragon = new(
                Character: LeilaAspor.Self,
                Species: Species.ArtificialHybridian,
                Faction: Faction.FromHuvia,
                Strength: 14,
                Intelligence: 9,
                Mana: 9,
                ManaGem: 13,
                ManaAscended: null,
                Age: 23,
                Height: 184,
                ShortDescription: "A powerful dragon hybridian created by the Sanctuary",
                AltName: "Dragon"
            );
            static readonly CharacterVersion LeilaDragonfly = new(
                Character: LeilaAspor.Self,
                Species: Species.ArtificialHybridian,
                Faction: Faction.FromHuvia,
                Strength: 10,
                Intelligence: 11,
                Mana: 0,
                ManaGem: 10,
                ManaAscended: 14,
                Age: 23,
                Height: 172,
                ShortDescription: "A powerful dragonfly hybridian created by the Sanctuary",
                AltName: "Dragonfly"
            );
            static readonly CharacterVersion[] LeilaVampireLord = 
            [
                new(
                    Character: LeilaAspor.Self,
                    Species: Species.Vampire,
                    Faction: Faction.FromHuvia,
                    Strength: 10,
                    Intelligence: 9,
                    Mana: 6,
                    ManaGem: 11,
                    ManaAscended: null,
                    Age: 26,
                    Height: 172,
                    ShortDescription: "A mage turned into vampire lord against her will",
                    AltName: "Vampire Lord"
                ),
                new(
                    Character: LeilaAspor.Self,
                    Species: Species.Vampire,
                    Faction: Faction.FromHuvia,
                    Strength: 13,
                    Intelligence: 11,
                    Mana: 13,
                    ManaGem: 15,
                    ManaAscended: 16,
                    Age: 30,
                    Height: 190,
                    ShortDescription: "A human who embraced her vampire lord side and found herself",
                    AltName: "Vampire Lord"
                ),
            ];

            static readonly CharacterVersion LucildaDawnStar = new(
                Character: Lucilda.Self,
                Species: Species.Angel | Species.ArtificialHybridian,
                Faction: Faction.FromHuvia,
                Strength: 15,
                Intelligence: 6,
                Mana: 0,
                ManaGem: 15,
                ManaAscended: null,
                Age: 1200,
                Height: 176,
                ShortDescription: "A corrupt angel with an insatiable desire for knowledge and souls",
                AltName: "Dawn Star"
            );
            static readonly CharacterVersion LucildaAngel = new(
                Character: Lucilda.Self,
                Species: Species.Angel,
                Faction: Faction.FromHuvia,
                Strength: 13,
                Intelligence: 9,
                Mana: 0,
                ManaGem: 13,
                ManaAscended: null,
                Age: 1200,
                Height: 170,
                ShortDescription: "An angel who discarded her corrupt half",
                AltName: "Angel"
            );
        }
    }
}
