using static SeraphielArt.Pages.Characters.CharacterData;
using Microsoft.AspNetCore.Html;

namespace SeraphielArt.Pages.Characters
{
    public class CharacterUI
    {
        public static IHtmlContent GetPage(CharacterVersion[] characterVersion)
        {
            HtmlContentBuilder builder = new();

            foreach (var character in characterVersion)
            {
                builder.AppendHtmlLine(character.AltName ?? $"{character.Character.Name} - {GetSpeciesName(character.Species)}");
                builder.AppendHtmlLine(character.ShortDescription ?? "AAA");
            }
            return builder;
        }
    }
}
