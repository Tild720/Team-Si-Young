using System.Collections;
using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class Hunger : MonoBehaviour
    {

        [SerializeField] private int hungerValue;
        [SerializeField] private float waitHungerTime;

        [SerializeField] private int maxHunger = 100;
        private int _currentHunger;
        
        private bool _isWaitHungerTime;

        private void Awake()
        {
            _currentHunger = maxHunger;
        }

        private void Update()
        {
            if (_isWaitHungerTime == false)
                StartCoroutine(WaitDecreaseHunger());
        }

        public void SetHunger(int hunger)
        {
            _currentHunger += hunger;
            
            if (maxHunger > _currentHunger)
            {
                _currentHunger = maxHunger;
            }
        }

        public IEnumerator WaitDecreaseHunger()
        {
            _isWaitHungerTime = true;
            
            yield return new WaitForSeconds(waitHungerTime);

            _currentHunger -= hungerValue;
            
            _isWaitHungerTime = false;
        }
    }
}