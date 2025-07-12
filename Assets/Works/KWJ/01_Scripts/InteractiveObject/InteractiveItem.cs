using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.InteractiveObject
{
    public class InteractiveItem : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] private LuxuryItemSo luxuryItemSo;
        public void Interact()
        {
            PlayerManager.Instance.Player.ItemInventory.AddItem(luxuryItemSo, 1);
            Destroy(gameObject);
        }
    }
}