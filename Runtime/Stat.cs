using UnityEngine;

namespace Stats
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private int minLimit;
        [SerializeField] private int maxLimit;
        [SerializeField] private bool hasMaxLimit;
        [SerializeField] private bool hasMinLimit;

        private int _value;
        
        public int Value
        {
            get => _value;
            set
            {
                if (hasMaxLimit && value > maxLimit)
                {
                    _value = maxLimit;
                    return;
                }

                if (hasMinLimit && value < minLimit)
                {
                    _value = minLimit;
                    return;
                }

                _value = value;
            }
        }

        public int MaxLimit
        {
            get => maxLimit;
            set
            {
                maxLimit = value;
                hasMaxLimit = true;
                Value = Value;
            }
        }
        
        public int MinLimit
        {
            get => minLimit;
            set
            {
                minLimit = value;
                hasMinLimit = true;
                Value = Value;
            }
        }

        public void RemoveMaxLimit()
        {
            hasMaxLimit = false;
            maxLimit = 0;
        }
        
        public void RemoveMinLimit()
        {
            hasMinLimit = false;
            minLimit = 0;
        }

        public void SetToMax()
        {
            Value = maxLimit;
        }
        
        public void SetToMin()
        {
            Value = minLimit;
        }
    }
}
