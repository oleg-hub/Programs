
namespace SmartHome_Beta_
{
    public class LoudSpeakers
    {
        private bool status;
        private int volume;

        public LoudSpeakers(bool status, int volume)
        {
            this.status = status;
            this.volume = volume;
        }

        public void On()
        {
            status = true;
        }

        public void Off()
        {
            status = false;
        }

        public void VolumeUp()
        {
            this.volume++;

            if (volume >= 100)
            {
                volume = 100;
            }
        }

        public void VolumeDown()
        {
            this.volume--;

            if (volume < 0)
            {
                volume = 0;
            }
        }

        public string Info()
        {
            string status;
            if (this.status)
            {
                status = "Колонки включены";
            }
            else
            {
                status = "Колонки выключены";
            }

            return string.Format("Состояние: {0} Громкость: {1}", status, volume);
        }
    }
}
