using UnityEngine;

namespace Bakery
{
    public interface IToDManager
    {
        void SkipAheadHours(int numHours);

        void SetToFastTime();
        void SetToNormalTime();

        bool IsTimeBetween(int startHour, int endHour);

        void SetFastTimeModifier(int modifier);
        void StopTimeOfDay();

        CustomYieldInstruction WaitForHours(int hours);

        bool IsFastTime();
        void SetHour(int hour);
    }
}
