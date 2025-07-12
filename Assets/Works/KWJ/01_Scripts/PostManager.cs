using Core.Scripts;
using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts
{
    public class PostManager : MonoSingleton<PostManager>
    {
        [SerializeField] private Transform _postPoint;

        public void PostInstantiat(LuxuryItemSo luxuryItemSo)
        {
            Instantiate(luxuryItemSo.PostObject,  _postPoint.position, Quaternion.identity);
        }
        
        public void PostInstantiat(FoodSo foodSo)
        {
            Instantiate(foodSo.PostObject, _postPoint.position, Quaternion.identity);
        }
    }
}