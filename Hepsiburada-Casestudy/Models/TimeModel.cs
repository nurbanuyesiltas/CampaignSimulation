namespace Hepsiburada_Casestudy.Models
{
    public class TimeModel
    {
        public int CurrentHour { get; set; }
        public void IncreaseSystemTime(int hour)
        {
            CurrentHour += hour;
        }
    }
}
