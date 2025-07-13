using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Works.KWJ._01_Scripts
{
    public class PlayerHunger : MonoBehaviour
    {
        [field:SerializeField] public int CurrentHunger { get; private set; }
        
        [SerializeField] private int hungerValue;
        [SerializeField] private float waitHungerTime;

        [SerializeField] private int maxHunger = 100;

        private bool _isWaitHungerTime;

        private void Awake()
        {
            CurrentHunger = maxHunger;
        }

        private void Update()
        {
            if (_isWaitHungerTime == false)
                StartCoroutine(WaitDecreaseHunger());
            
            if(CurrentHunger <= 0)
                SceneManager.LoadScene("Tild");
        }

        public void SetHunger(int hunger)
        {
            CurrentHunger += hunger;
            
            if (maxHunger < CurrentHunger)
            {
                CurrentHunger = maxHunger;
            }
        }

        public IEnumerator WaitDecreaseHunger()
        {
            _isWaitHungerTime = true;
            
            yield return new WaitForSeconds(waitHungerTime);

            CurrentHunger -= hungerValue;
            
            _isWaitHungerTime = false;
        }
    }
}