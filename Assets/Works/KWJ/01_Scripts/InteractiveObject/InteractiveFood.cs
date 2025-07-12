using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.InteractiveObject
{
    public class InteractiveFood : MonoBehaviour, IInteractiveObject
    {
        private int count;
        public void Interact()
        {
            if (count == 0)
            {
                transform.position = PlayerManager.Instance.Player.ComputerPoint.position;
                count += 1;
            }
            else
            {
                count += 1;
                PlayerManager.Instance.Player.PlayerHunger.SetHunger(5);
            }

            if (count == 10)
            {
                Destroy(gameObject);
            }
        }
    }
}