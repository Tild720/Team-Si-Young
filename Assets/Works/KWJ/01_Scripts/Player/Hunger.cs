using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class Hunger : MonoBehaviour
    {
        public int MaxHunger;
        public int CurrentHunger;
        
        private void OnEnable()
        {
            DayManager.Instance.OnNextDayAction += DecreaseHunger;
        }

        private void OnDisable()
        {
            DayManager.Instance.OnNextDayAction -= DecreaseHunger;
        }

        private void DecreaseHunger()
        {
            SetHunger(-10);
        }
        
        public void SetHunger(int hunger)
        {
                        
            CurrentHunger += hunger;
            
            if (MaxHunger > CurrentHunger)
            {
                CurrentHunger = MaxHunger;
            }
        }
    }
}