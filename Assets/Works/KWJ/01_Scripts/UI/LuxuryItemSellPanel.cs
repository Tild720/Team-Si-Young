using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class LuxuryItemSellPanel : MonoBehaviour
    {
        [SerializeField] private LuxuryItemSo _luxuryItemSo;

        public void SellLuxuryItem()
        {
            if (PlayerManager.Instance.Player.ItemInventory.ItmeCheck(_luxuryItemSo) == false)
            {
                return;
            }

            PostManager.Instance.PostInstantiat(_luxuryItemSo);
            PlayerManager.Instance.Player.ItemInventory.DecreaseItem(_luxuryItemSo, 1);
            PlayerManager.Instance.Player.PlayerMoney.SetMoney(_luxuryItemSo.Price);
        }
    }
}