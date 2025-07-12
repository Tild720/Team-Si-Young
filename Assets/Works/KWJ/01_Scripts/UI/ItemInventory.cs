using System.Collections.Generic;
using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class ItemInventory : MonoBehaviour
    {
        [SerializeField] private List<LuxuryItemSo> TestItems = new List<LuxuryItemSo>();
        
        public Dictionary<string, int> Items = new Dictionary<string, int>();

        private void Start()
        {
            for (int i = 0; i < TestItems.Count; i++)
            {
                Items.Add(TestItems[i].ItemName, 0);
                Items[TestItems[i].ItemName] += 10;
            }
        }

        public void AddItem(LuxuryItemSo item, int count)
        {
            Items[item.ItemName] += count;
        }
        
        public void DecreaseItem(LuxuryItemSo item, int count)
        {
            if(Items[item.ItemName] > 0)
                Items[item.ItemName] -= count;
        }
        
        public bool ItmeCheck(LuxuryItemSo item)
        {
            if (Items.ContainsKey(item.ItemName) && Items[item.ItemName] > 0)
                return true;

            return false;
        }
    }
}