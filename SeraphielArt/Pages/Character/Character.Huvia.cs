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
                    api: "Leila",
                    description: @$"
Leila is a human girl coming from a village remotely north of the Huvia Republic. She had a peaceful life and was raised by loving parents until the age of 16. During her 16th year of life her village was raided by demonic species and burned to the ground, causing the death of every person living there.
Leila was rescued by a Huvia knight patrolling the area, the knight brough her back to the capital saving her life and raised her from that day, supporting her education.
Leila completed school and continued studying mana and magic in college, she tried hard and managed to qualify for the sanctuary challenge, facing her past and completing the trials one after the other and obtaining her own mana gem, she graduated 2 later.
Once graduated Leila decided to go on an adventure in the wilderness on her own...
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
        }
    }
}
