using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderingApp
{
    public class Basket
    {
        public Dictionary<string, List<FoodOrderedCard>> OrderStructure { get; set; }

        public event Action<object, Dictionary<string, List<FoodOrderedCard>>> OnBasketUpdate;

        public Basket(List<RestaurantCard> rc)
        {
            OrderStructure = new Dictionary<string, List<FoodOrderedCard>>();
            foreach (var rest in rc)
                OrderStructure.Add(rest.Title, new List<FoodOrderedCard>());
            OnBasketUpdate?.Invoke(this, OrderStructure);
        }

        public void AddFood(FoodOrderedCard fc)
        {
            var listOfSimilarCards = from c in OrderStructure[fc.ShopName].OfType<FoodOrderedCard>()
                                     where c.ProductId == fc.ProductId
                                     select c;
            if (listOfSimilarCards.Count() > 0)
                listOfSimilarCards.First().Quantity++;
            else
                OrderStructure[fc.ShopName].Add(fc);
            OnBasketUpdate?.Invoke(this, OrderStructure);
        }

        public void Clear()
        {
            foreach (var key in OrderStructure.Keys)
                OrderStructure[key].Clear();
            OnBasketUpdate?.Invoke(this, OrderStructure);
        }

        public void RemoveFood(FoodOrderedCard fc)
        {
            OrderStructure[fc.ShopName].Remove(fc);
            OnBasketUpdate?.Invoke(this, OrderStructure);
        }
    }
}
