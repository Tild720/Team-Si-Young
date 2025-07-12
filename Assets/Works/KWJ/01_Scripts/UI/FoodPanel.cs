using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class FoodPanel : MonoBehaviour
    {
        [SerializeField] private FoodSo _foodSo;
        [SerializeField] private Image _foodIcon;
        [SerializeField] private TextMeshProUGUI _foodText;
        [SerializeField] private TextMeshProUGUI _foodPrice;

        private void Awake()
        {
            _foodIcon.sprite = _foodSo.FoodIcon;
            _foodText.text = _foodSo.FoodName;
            _foodPrice.text = _foodSo.Price + "$";
        }

        public void BuyFood()
        {
            if (PlayerManager.Instance.Player.PlayerMoney.CurrentMoney < _foodSo.Price)
            {
                return;
            }
            
            PlayerManager.Instance.Player.PlayerMoney.SetMoney(-_foodSo.Price);
            PlayerManager.Instance.Player.PlayerHunger.SetHunger(_foodSo.HungerValue);
        }
    }
}