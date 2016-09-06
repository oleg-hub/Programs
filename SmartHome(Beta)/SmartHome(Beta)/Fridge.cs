
namespace SmartHome_Beta_
{
    class Fridge
    {
        public Powering mode;
        public bool state;


        public void On()
        {
            state = true;
        }
        public void Off()
        {
            state = false;
        }


        public void LowFridge()
        {
            mode = Powering.Low;
        }
        public void MedFridge()
        {
            mode = Powering.Med;
        }
        public void HighFridge()
        {
            mode = Powering.High;
        }



        public string Info()
        {
            string mode = "";
            string state;
            if (this.state)
            {
                state = "Холодильник включен";
            }
            else
            {
                state = "Холодильник выключен";
            }

            if (this.mode == Powering.Low)
            {
                mode = "Слабая заморозка ";
            }
            else if (this.mode == Powering.Med)
            {
                mode = "Средняя заморозка";
            }
            else if (this.mode == Powering.High)
            {
                mode = "Сильная заморозка";
            }


            return "Состояние: " + state + " Уровень заморозки: " + mode;
        }
    }
    enum Powering
    {
        Low,
        Med,
        High
    }
}


