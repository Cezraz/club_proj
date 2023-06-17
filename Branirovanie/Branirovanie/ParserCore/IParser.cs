using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace Branirovanie.ParserCore
{
    public interface IParser<T> where T : class
    {
        Dictionary<string, string> ParseSections(IDocument document);
        T ParseFood(IDocument document);
    }
}
