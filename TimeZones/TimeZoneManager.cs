using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TimeZones
{
    class TimeZoneManager
    {
        TimeZoneManager()
        {
            //TimeZoneData = LoadTimeZoneData();
        }

//        ObservableCollection<TimeZone> LoadTimeZoneData()
//        {
//            return ObservableCollection<TimeZone>();
//        }

        public ObservableCollection<TimeZone> TimeZoneData { get; set; }
    }

    class TimeZone
    {
        public string ID { get; set; }
        public bool Enabled { get; set; }
    }
}

