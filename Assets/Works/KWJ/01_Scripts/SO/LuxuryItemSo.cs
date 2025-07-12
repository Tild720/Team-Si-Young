using UnityEngine;

namespace Works.KWJ._01_Scripts.SO
{
    [CreateAssetMenu(fileName = "LuxuryItemSo", menuName = "SO/LuxuryItemSo", order = 0)]
    public class LuxuryItemSo : ScriptableObject
    {
        public Sprite ItemIcon; 
        
        public string ItemName;

        public int Price;

        public GameObject PostObject;
    }
}