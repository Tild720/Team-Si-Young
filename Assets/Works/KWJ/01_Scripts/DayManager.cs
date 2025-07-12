using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class DayManager : MonoBehaviour
    {
        private int _dayCount = 1;

        public void DayCount()
        {
            FadeInOut.Instance.FadeOutIn(true, true);
            _dayCount += 1;
        }
    }
}