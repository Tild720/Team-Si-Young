using UnityEngine;

namespace Works.KWJ._01_Scripts.SO
{
    public class LuxuryItemSo : MonoBehaviour
    {
        public Sprite ItemIcon; 
        
        public string ItemName;

        [TextArea] public string Explanation;
        
        public int Price;
    }
}