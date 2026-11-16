using System;
using UnityEngine;

namespace Bakery
{
    public static class TOD
    {
        public static class Events
        {
            public static Action<DateTime> OnTimeChanged = delegate { };

            public static Action OnDayChanged = delegate { };
            public static Action<int> OnHourTicked = (numHours) => { };
            public static Action OnMorning = delegate { };
            public static Action OnEvening = delegate { };
            public static Action OnNight = delegate { };

            public static Action SpeedChanged = delegate { };

            public static Action<Season, PeriodOfDay, Weather> OnChanged = delegate { };
        }

        public static Func<IToDManager> Manager = UnregisterManager;

        public static Func<IToDController> Controller = UnregisterController;

        private static IToDManager CachedDummyManager = null;
        private static IToDController CachedDummyController = null;

        public static IToDController UnregisterController()
        {
            CachedDummyController ??= new DummyController();
            Controller = () => CachedDummyController;
            return CachedDummyController;
        }

        public static IToDManager UnregisterManager()
        {
            CachedDummyManager ??= new DummyManager();
            Manager = () => CachedDummyManager;
            return CachedDummyManager;
        }

        internal class DummyManager : IToDManager
        {
            public bool IsFastTime() => false;

            public bool IsTimeBetween(int startHour, int endHour) => false;

            public void SetFastTimeModifier(int modifier) { }

            public void SetHour(int hour) { }

            public void SetToFastTime() { }

            public void SetToNormalTime() { }

            public void SkipAheadHours(int numHours) { }

            public void StopTimeOfDay() { }

            public CustomYieldInstruction WaitForHours(int hours) => null;
        }

        internal class DummyController : IToDController
        {
            public void Set(Season season, PeriodOfDay periodOfDay, Weather weather) { }
        }
    }
}
