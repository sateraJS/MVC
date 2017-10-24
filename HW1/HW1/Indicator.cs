using System;

namespace HW1
{
    public class Indicator
    {
        private DateTime _startTime;
        private DateTime _endTime;
        public void Start()
        {
            _startTime = DateTime.Now;
        }

        public void End()
        {
            _endTime = DateTime.Now;
        }
        public int Time()
        {
            return _endTime.Subtract(_startTime).Milliseconds;
        }
    }
}
