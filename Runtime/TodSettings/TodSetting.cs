using System;

namespace Bakery
{
    [Serializable]
    public abstract class TodSetting
    {
        public abstract void Record();
        public abstract void Apply();
    }
}
