using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ModelModel
    {
        public int Id { get; set; }
        public Dictionary<int, string> ThemeDevices { get; set; }
        public byte[] Background { get; set; }
        public byte[] TopBar { get; set; } 
        public byte[] BottomBar { get; set; }
        public byte[] CenterOrbit { get; set; }
        public byte[] NotifyButton { get; set; }
        public byte[] TopButton { get; set; }
        public byte[] LeftButton { get; set; }
        public byte[] RightButton { get; set; }

        public List<byte[]> AllImages;
    }
}