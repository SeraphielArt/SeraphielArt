using static SeraphielArt.Pages.Character.CharacterList.Etheria;
using static SeraphielArt.Pages.Character.CharacterList.Huvia;
using static SeraphielArt.Pages.Character.CharacterData;
using Microsoft.AspNetCore.Mvc;

namespace SeraphielArt.Pages.Character
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
        public IActionResult GetCharacterInformation(string call)
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

        public static CharacterData.Character[] AllCharacters { get; } = CharactersList
                                                                         .Select(v => v.Character)
                                                                         .Distinct()
                                                                         .ToArray();

    }


    public static partial class CharacterList
    {
    }
}
