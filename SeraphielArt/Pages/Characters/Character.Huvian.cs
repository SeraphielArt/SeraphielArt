using static SeraphielArt.Pages.Characters.CharacterData;

namespace SeraphielArt.Pages.Characters
{
    public static partial class CharacterList
    {
        public static partial class Huvian
        {
            public class LeilaAspor : Character
            {
                private static readonly LeilaAspor Self = new();
                public static readonly LeilaHuman Human = new(Self);
                public static readonly LeilaDragon Dragon = new(Self);
                public static readonly LeilaDragonfly Dragonfly = new(Self);
                public static readonly LeilaNeoVampireLord NeoVampireLord = new(Self);
                public static readonly LeilaVampireLord VampireLord= new(Self);

                public LeilaAspor() : base(
                    name: "Leila Aspor Faeloria",
                    api: "Leila",
                    description: @$"
Leila is a human girl coming from a village remotely north of the Huvian Republic. She had a peaceful life and was raised by loving parents until the age of 16. During her 16th year of life her village was raided by demonic species and burned to the ground, causing the death of every person living there.
Leila was rescued by a Huvian knight patrolling the area, the knight brough her back to the capital saving her life and raised her from that day, supporting her education.
Leila completed school and continued studying mana and magic in college, she tried hard and managed to qualify for the sanctuary challenge, facing her past and completing the trials one after the other and obtaining her own mana gem, she graduated 2 later.
Once graduated Leila decided to go on an adventure in the wilderness on her own...
"
                )
                { }
            }
        }
    }
}
