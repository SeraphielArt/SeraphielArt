using static SeraphielArt.Pages.Character.CharacterData;

namespace SeraphielArt.Pages.Character
{
    public static partial class CharacterList
    {
        public static partial class Huvia
        {
            public class LeilaAspor : CharacterBase
            {
                private static readonly LeilaAspor Self = new();
                public static readonly CharacterVersion[] Human = [new LeilaHuman(Self)];
                public static readonly CharacterVersion[] Dragon = [new LeilaDragon(Self)];
                public static readonly CharacterVersion[] Dragonfly = [new LeilaDragonfly(Self)];
                public static readonly CharacterVersion[] VampireLord = [new LeilaVampireLordYoung(Self), new LeilaVampireLordAdult(Self)];

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
                private static readonly Lucilda Self = new();
                public static readonly CharacterVersion[] DawnStar = [new LucildaDawnStar(Self)];
                public static readonly CharacterVersion[] Angel = [new LucildaAngel(Self)];

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
            public class LeilaHuman(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.HumanSolumanir,
                faction: Faction.FromHuvia,
                strength: 5,
                intelligence: 9,
                mana: 0,
                manaGem: 5,
                manaAscended: 7,
                age: 22,
                height: 172,
                shortDescription: "A skilled mage who just passed her exam",
                altName: "Human"
            )
            { }
            public class LeilaDragon(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.ArtificialHybridian,
                faction: Faction.FromHuvia,
                strength: 14,
                intelligence: 9,
                mana: 9,
                manaGem: 13,
                manaAscended: null,
                age: 23,
                height: 184,
                shortDescription: "A powerful dragon hybridian created by the Sanctuary",
                altName: "Dragon"
            )
            { }
            public class LeilaDragonfly(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.ArtificialHybridian,
                faction: Faction.FromHuvia,
                strength: 10,
                intelligence: 11,
                mana: 0,
                manaGem: 10,
                manaAscended: 14,
                age: 23,
                height: 172,
                shortDescription: "A powerful dragonfly hybridian created by the Sanctuary",
                altName: "Dragonfly"
            )
            { }
            public class LeilaVampireLordYoung(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.Vampire,
                faction: Faction.FromHuvia,
                strength: 10,
                intelligence: 9,
                mana: 6,
                manaGem: 11,
                manaAscended: null,
                age: 26,
                height: 172,
                shortDescription: "A mage turned into vampire lord against her will",
                altName: "Young Vampire Lord"
            )
            { }
            public class LeilaVampireLordAdult(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.Vampire,
                faction: Faction.FromHuvia,
                strength: 13,
                intelligence: 11,
                mana: 13,
                manaGem: 15,
                manaAscended: 16,
                age: 30,
                height: 190,
                shortDescription: "A human who embraced her vampire lord side and found herself",
                altName: "Vampire Lord"
            )
            { }
            public class LucildaDawnStar(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.Angel | Species.ArtificialHybridian,
                faction: Faction.FromHuvia,
                strength: 15,
                intelligence: 6,
                mana: 0,
                manaGem: 15,
                manaAscended: null,
                age: 1200,
                height: 176,
                shortDescription: "A corrupt angel with an insatiable desire for knowledge and souls",
                altName: "Dawn Star"
            )
            { }
            public class LucildaAngel(CharacterBase self) : CharacterVersion(
                character: self,
                species: Species.Angel,
                faction: Faction.FromHuvia,
                strength: 13,
                intelligence: 9,
                mana: 0,
                manaGem: 13,
                manaAscended: null,
                age: 1200,
                height: 170,
                shortDescription: "An angel who discarded her corrupt half",
                altName: "Angel"
            )
            { }
        }
    }
}
