using UnityEngine;

namespace Works.KWJ._01_Scripts.SO
{
    [CreateAssetMenu(fileName = "FoodSo", menuName = "SO/FoodSo", order = 0)]
    public class FoodSo : ScriptableObject
    {
        public Sprite FoodIcon; 
        
        public string FoodName;

        public int Price;
        
        public int HungerValue;
        
        public GameObject PostObject;
    }
}