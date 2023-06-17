using AngleSharp.Dom;
//using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace Branirovanie.ParserCore.Presto
{
    class PrestoParser : IParser<List<FoodSource>>
    {
        public List<FoodSource> ParseFood(IDocument document)
        {
            var list = new List<FoodSource>();
            var items = document.QuerySelectorAll("div.item-wrap");
            foreach (var item in items)
            {
                var food = new FoodSource();
                string imageOnLoadText = item.QuerySelector("img").GetAttribute("onload").Substring(53).Replace("';", "");
                food.ImageUrl = imageOnLoadText;
                food.FoodName = item.QuerySelector(".text").TextContent.Replace("<b>", "").Replace("</b>", "").Trim();
                food.Price = item.QuerySelectorAll("div.price")[0].TextContent;
                food.Description = item.QuerySelector(".hide-info").TextContent.Trim();
                food.ShopName = "Престо";
                food.ProductId = item.QuerySelector(".item__take").GetAttribute("data-product-id");
                list.Add(food);
            }
            return list;
        }

        public Dictionary<string, string> ParseSections(IDocument document)
        {
            var items = document.QuerySelectorAll("a.button");
            var result = new Dictionary<string, string>();

            foreach (var item in items)
            {
                result.Add(item.GetAttribute("data-ref"), item.TextContent);
            }
            result.Remove("za-bally");
            return result;
        }
    }
}
