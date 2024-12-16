using static SeraphielArt.Pages.Characters.CharacterData;
using static SeraphielArt.Pages.Characters.CharacterList.Huvian;
using static SeraphielArt.Pages.Characters.CharacterList.Etheria;
using Microsoft.AspNetCore.Mvc;

namespace SeraphielArt.Pages.Characters
{
    [Route("Character")]
    public class CharacterAPI : Controller
    {
        public static CharacterVersion[] CharactersList { get; } = [
            AliceBlessland.HumanEtherian,
            AliceBlessland.Vampire,

            EdgarCrowbell.Homunculus,
            EdgarCrowbell.SerpentLord,
            EdgarCrowbell.Serpent,
            EdgarCrowbell.Seraph,

            LeilaAspor.Human,
            LeilaAspor.Dragon,
            LeilaAspor.Dragonfly,
            LeilaAspor.NeoVampireLord,
            LeilaAspor.VampireLord,
        ];

        [HttpGet("{call}")]
        public IActionResult GetCharacter(string call)
        {
            CharacterVersion[] matchingCharacters = CharactersList.Where(v => v.Character.Api == call).ToArray();

            if (matchingCharacters.Length > 0)
            {
                return View("CharacterVersion", matchingCharacters);
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }


    public static partial class CharacterList
    {
        public static partial class Etheria
        {
            public class AliceHuman(Character self) : CharacterVersion(
                character: self,
                species: Species.HumanEtheria,
                faction: Faction.None,
                strength: 7,
                intelligence: 9,
                age: 24,
                height: 175,
                shortDescription: "A skilled alchemist from another world"
            )
            { }
            public class AliceVampire(Character self) : CharacterVersion(
                character: self,
                species: Species.HumanEtheria | Species.Vampire,
                faction: Faction.None,
                strength: 9,
                intelligence: 9,
                mana: 3,
                age: 28,
                height: 175,
                shortDescription: "An alchemist turned vampire for her loved one"
            )
            { }
            public class EdgarHomunculus(Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria,
                faction: Faction.None,
                strength: 11,
                intelligence: 9,
                age: 29,
                height: 164,
                shortDescription: "A powerful artificial lifeform from another world"
            )
            { }
            public class EdgarSerpentLord(Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria | Species.ArtificialHybridian,
                faction: Faction.None,
                strength: 15,
                intelligence: 5,
                age: 33,
                height: 187,
                shortDescription: "The creation of the love and despair of Olivia"
            )
            { }
            public class EdgarSerpent(Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria | Species.ArtificialHybridian,
                faction: Faction.None,
                strength: 13,
                intelligence: 9,
                age: 33,
                height: 164,
                shortDescription: "A powerful serpent who took control of his own fate"
            )
            { }
            public class EdgarSeraph(Character self) : CharacterVersion(
                character: self,
                species: Species.HomunculusEtheria | Species.Seraph,
                faction: Faction.None,
                strength: 11,
                intelligence: 9,
                age: 29,
                height: 164,
                shortDescription: "A powerful being achieved the ultimate ascension level in all of Solumniar"
            )
            { }
        }
        public static partial class Huvian
        {
            public class LeilaHuman(Character self) : CharacterVersion(
                character: self,
                species: Species.HumanSolumanir,
                faction: Faction.None,
                strength: 5,
                intelligence: 9,
                mana: 0,
                manaGem: 5,
                manaAscended: 7,
                age: 22,
                height: 172,
                shortDescription: "A skilled mage who just passed her exam"
            )
            { }
            public class LeilaDragon(Character self) : CharacterVersion(
                character: self,
                species: Species.ArtificialHybridian,
                faction: Faction.None,
                strength: 14,
                intelligence: 9,
                mana: 9,
                manaGem: 13,
                manaAscended: null,
                age: 23,
                height: 184,
                shortDescription: "A powerful dragon hybridian created by the Sanctuary"
            )
            { }
            public class LeilaDragonfly(Character self) : CharacterVersion(
                character: self,
                species: Species.ArtificialHybridian,
                faction: Faction.None,
                strength: 10,
                intelligence: 11,
                mana: 0,
                manaGem: 10,
                manaAscended: 14,
                age: 23,
                height: 172,
                shortDescription: "A powerful dragonfly hybridian created by the Sanctuary"
            )
            { }
            public class LeilaNeoVampireLord(Character self) : CharacterVersion(
                character: self,
                species: Species.Vampire,
                faction: Faction.None,
                strength: 10,
                intelligence: 9,
                mana: 6,
                manaGem: 11,
                manaAscended: null,
                age: 26,
                height: 172,
                shortDescription: "A mage turned into vampire lord against her will"
            )
            { }
            public class LeilaVampireLord(Character self) : CharacterVersion(
                character: self,
                species: Species.Vampire,
                faction: Faction.None,
                strength: 13,
                intelligence: 11,
                mana: 13,
                manaGem: 15,
                manaAscended: 16,
                age: 30,
                height: 190,
                shortDescription: "A human who embraced her vampire lord side and found herself"
            )
            { }
        }
    }
}
