using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace FoodOrderingApp.ParserCore
{
    public interface IParser<T> where T : class
    {
        Dictionary<string, string> ParseSections(IDocument document);
        T ParseFood(IDocument document);
    }
}
