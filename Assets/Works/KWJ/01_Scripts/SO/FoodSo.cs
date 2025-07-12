using UnityEngine;

namespace Works.KWJ._01_Scripts.SO
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class FoodSo : ScriptableObject
    {
        public Sprite FoodIcon; 
        
        public string FoodName;

        [TextArea] public string Explanation;

        public int HungerValue;
    }
}