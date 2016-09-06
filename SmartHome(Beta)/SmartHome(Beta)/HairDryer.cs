using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_Beta_
{
    public class HairDryer
    {
        private bool state;
        private Power power;

        public HairDryer(bool state, Power mode)
        {
            this.state = state;
            this.power = mode;
        }

        public void On()
        {
            state = true;
        }

        public void Off()
        {
            state = false;
        }

        public void SetColdWind()
        {
            power = Power.Cold;
        }

        public void SetHotWind()
        {
            power = Power.Min;
        }

        public void SetVeryHotWind()
        {
            power = Power.Max;
        }

        public string Info()
        {
            string state;
            if (this.state)
            {
                state = "фен включен";
            }
            else
            {
                state = "фен выключен";
            }

            string mode;
            if (this.power == Power.Cold)
            {
                mode = "поток холодного воздуха";
            }
            else if (this.power == Power.Min)
            {
                mode = "поток теплого воздуха";
            }
            else
            {
                mode = "поток горячего воздуха";
            }

            return "Состояние: " + state + ", Статус: " + mode;
        }
        public enum Power
        {
            Cold,
            Min,
            Max
        }

    }
}
