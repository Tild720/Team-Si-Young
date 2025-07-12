using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class LuxuryItemSellPanel : MonoBehaviour
    {
        [SerializeField] private LuxuryItemSo _luxuryItemSo;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _itemText;
        [SerializeField] private TextMeshProUGUI _itemPrice;

        private void Awake()
        {
            _itemIcon.sprite = _luxuryItemSo.ItemIcon;
            _itemText.text = _luxuryItemSo.ItemName;
            _itemPrice.text = _luxuryItemSo.Price + "$";
        }

        public void SellLuxuryItem()
        {
            if (PlayerManager.Instance.Player.ItemInventory.ItmeCheck(_luxuryItemSo) == false)
            {
                return;
            }

            PlayerManager.Instance.Player.ItemInventory.DecreaseItem(_luxuryItemSo, 1);
            PlayerManager.Instance.Player.PlayerMoney.SetMoney(_luxuryItemSo.Price);
        }
    }
}