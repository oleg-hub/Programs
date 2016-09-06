
namespace SmartHome_Beta_
{
    public class Heating
    {
        private bool status;
        private HeatParams heatParams;

        public Heating(bool status, HeatParams mode)
        {
            this.status = status;
            this.heatParams = mode;
        }

        public void On()
        {
            status = true;
        }

        public void Off()
        {
            status = false;
        }

        public void SetHeatInKitchen()
        {
            heatParams = HeatParams.Kithenheater;
        }

        public void SetHeatInBedroom()
        {
            heatParams = HeatParams.Bedroomheater;
        }

        public void SetHeatInHallway()
        {
            heatParams = HeatParams.Hallwayheater;
        }

        public void SetHeatInBathroom()
        {
            heatParams = HeatParams.Bathroomheater;
        }

        public void SetHeatInLivingRoom()
        {
            heatParams = HeatParams.LivingRoomheater;
        }
        public void SetAllHeater()
        {
            heatParams = HeatParams.AllHeater;
        }

        public string Info()
        {
            string status;
            if (this.status)
            {
                status = "обогрев включен";
            }
            else
            {
                status = "обогрев выключен";
            }

            string mode;
            if (this.heatParams == HeatParams.Kithenheater)
            {
                mode = "Обогрев кухни";
            }
            else if (this.heatParams == HeatParams.Bedroomheater)
            {
                mode = "Обогрев спальни";
            }
            else if (this.heatParams == HeatParams.Hallwayheater)
            {
                mode = "Обогрев в коридоре";
            }
            else if (this.heatParams == HeatParams.Bathroomheater)
            {
                mode = "Обогрев в ванне";
            }
            else if (this.heatParams == HeatParams.LivingRoomheater)
            {
                mode = "Обогрев гостинной";  
            }
            else
            {
                mode = "Обогрев во всех комнатах";
            }

            return "Состояние: " + status + ", Статус: " + mode;
        }

        public enum HeatParams
        {
            Kithenheater,
            Bedroomheater,
            Hallwayheater,
            Bathroomheater,
            LivingRoomheater,
            AllHeater

        }
    }
}

