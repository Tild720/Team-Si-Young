using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class PlayerMoney : MonoBehaviour
    {
        [field:SerializeField] public int CurrentMoney { get; private set; }

        public void SetMoney(int money)
        {
            CurrentMoney += money;
        }
    }
}