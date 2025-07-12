using System;
using Core.Scripts;

namespace Works.KWJ._01_Scripts
{
    public class DayManager : MonoSingleton<DayManager>
    {
        public Action OnNextDayAction;

        public int DayCount { get; private set; } = 1;

        public void DayCounter()
        {
            FadeInOut.Instance.FadeOutIn(true, true);
            OnNextDayAction?.Invoke();
            DayCount += 1;
        }
    }
}