using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_Beta_
{
    public class TV
    {
        private const int MinChannelIndex = 0;
        private bool _status;
        private int _currentChannelIndex;
        private int _maxChannelIndex;
        private List<string> _channelList;



        public TV(List<string> channelList)
            : this(false, 0, channelList)
        {
        }

        public TV(bool status, int currentChannelIndex, List<string> channelList = null)
        {
            this._status = status;
            this._channelList = channelList == null ? this.GetDefaultChannelList(null) : this.GetDefaultChannelList(channelList);
            this._maxChannelIndex = _channelList.Count - 1;
            this._currentChannelIndex = currentChannelIndex;
        }

        public void SetTvStatus(bool status)
        {
            this._status = status;
        }


        public List<string> GetDefaultChannelList(List<string> additionalChannels)
        {
            List<string> defaultChannelList = new List<string>
            {
                "inter",
                "2+2",
                "stb",
                "discovery",
                "tnt",
                "explorer",
                "news"
            };


            if (additionalChannels != null)
            {
                defaultChannelList.AddRange(additionalChannels);
            }

            return defaultChannelList;
        }


        public void NextChannel()
        {
            this._currentChannelIndex++;

            if (this._currentChannelIndex > this._maxChannelIndex)
            {
                this._currentChannelIndex = MinChannelIndex;
            }
        }

        public void PreviousChannel()
        {
            this._currentChannelIndex--;

            if (this._currentChannelIndex < MinChannelIndex)
            {
                this._currentChannelIndex = this._maxChannelIndex;
            }
        }

        public void SetChannel(int numberOfChannel)
        {
            if (numberOfChannel > this._maxChannelIndex || numberOfChannel < MinChannelIndex)
            {
                return;
            }

            this._currentChannelIndex = numberOfChannel;
        }

        public string GetInfo()
        {
            string state = "TV is " + (this._status ? "on" : "off");

            string currentChannel = this._channelList[_currentChannelIndex];

            string channelList = string.Join("\n ", _channelList.ToArray());


            return string.Format("Состояние: {0}, Канал: {1} \n Список:\n {2}", state, currentChannel, channelList);
        }
    }
}
