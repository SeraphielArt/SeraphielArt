using static SeraphielArt.Pages.Character.CharacterList.Etheria;
using static SeraphielArt.Pages.Character.CharacterList.Huvia;
using static SeraphielArt.Pages.Character.CharacterData;
using Microsoft.AspNetCore.Mvc;

namespace SeraphielArt.Pages.Character
{
    [Route("Character")]
    public class CharacterAPI : Controller
    {
        public static CharacterBase[] CharactersList { get; } = [
            AliceBlessland.Self,
            //EdgarCrowbell.Self,

            LeilaAspor.Self,
            //Lucilda.Self,
        ];

        [HttpGet("{call}")]
        public IActionResult GetCharacterInformation(string call)
        {
            CharacterBase? matchingCharacter = CharactersList.FirstOrDefault(c => c.Api == call);
            if (matchingCharacter != null)
            {
                return View("CharacterVersion", matchingCharacter);
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }


    public static partial class CharacterList
    {
        private static class APIs
        {
            public const string Alice = "Alice";
            public const string Edgar = "Edgar";
            public const string Leila = "Leila";
            public const string Lucilda = "Lucilda";
        }
    }
}
