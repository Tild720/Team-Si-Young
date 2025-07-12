using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class FoodPanel : MonoBehaviour
    {
        [SerializeField] private FoodSo _foodSo;

        public void BuyFood()
        {
            if (PlayerManager.Instance.Player.PlayerMoney.CurrentMoney < _foodSo.Price)
            {
                return;
            }
            
            PostManager.Instance.PostInstantiat(_foodSo);
            PlayerManager.Instance.Player.PlayerMoney.SetMoney(-_foodSo.Price);
            PlayerManager.Instance.Player.PlayerHunger.SetHunger(_foodSo.HungerValue);
        }
    }
}