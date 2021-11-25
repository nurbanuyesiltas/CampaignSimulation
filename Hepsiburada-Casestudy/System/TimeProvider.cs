using Hepsiburada_Casestudy.Models;

namespace Hepsiburada_Casestudy.System
{
    public class TimeProvider : ITimeProvider
    {
        private TimeModel model = new TimeModel();

        public void IncreaseTime(int hour)
        {
            model.IncreaseSystemTime(hour);
        }
        public TimeModel GetTimeModel()
        {
            return model;
        }
    }
}
