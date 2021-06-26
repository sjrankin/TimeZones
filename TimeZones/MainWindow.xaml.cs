using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Globalization;
using System.Windows.Threading;
using System.Drawing;

namespace TimeZones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer ClockTimer;

        public MainWindow()
        {
            InitializeComponent();

            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> list = TimeZoneInfo.GetSystemTimeZones();
            for (int i = 0; i < list.Count; i++)
            {
                TimeZoneInfo z = list[i];
                Console.WriteLine(z.Id);
            }

            ClockTimer = new DispatcherTimer(DispatcherPriority.Normal);
            ClockTimer.Tick += ClockTick;
            ClockTimer.Interval = new TimeSpan(0, 0, 1);
            ClockTimer.Start();
            ClockTick(new object(), new EventArgs());
        }

        private bool IsDark(DateTime TimeAtLocation)
        {
            if ((TimeAtLocation.Hour <= 6) || (TimeAtLocation.Hour >= 18))
            {
                return true;
            }
            return false;
        }

        private void ClockTick(object Sender, EventArgs e)
        {
            SolidColorBrush DayText = new SolidColorBrush();
            DayText.Color = Colors.Black;
            SolidColorBrush NightText = new SolidColorBrush();
            NightText.Color = Colors.White;
            SolidColorBrush DayTime = new SolidColorBrush();
            DayTime.Color = Colors.Yellow;
            SolidColorBrush NightTime = new SolidColorBrush();
            NightTime.Color = System.Windows.Media.Color.FromRgb(5, 5, 100);

            DateTime UTC = DateTime.UtcNow;
            System.TimeZoneInfo UTCTZInfo = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            var TZ1Data = GetTZInfo(UTC, UTCTZInfo);
            TZ1.Content = TZ1Data.Item1;
            TZ1Name.Content = TZ1Data.Item2;
            TZ1Date.Content = TZ1Data.Item3;
            if (IsDark(TZ1Data.Item5))
            {
                TZ1.Foreground = NightText;
                TZ1Name.Foreground = NightText;
                TZ1Date.Foreground = NightText;
                Row1.Background = NightTime;
            }
            else
            {
                TZ1.Foreground = DayText;
                TZ1Name.Foreground = DayText;
                TZ1Date.Foreground = DayText;
                Row1.Background = DayTime;
            }

            System.TimeZoneInfo _TZ2 = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var TZ2Data = GetTZInfo(UTC, _TZ2);
            TZ2.Content = TZ2Data.Item1;
            TZ2Name.Content = TZ2Data.Item2;
            TZ2Date.Content = TZ2Data.Item3;
            if (IsDark(TZ2Data.Item5))
            {
                TZ2.Foreground = NightText;
                TZ2Name.Foreground = NightText;
                TZ2Date.Foreground = NightText;
                Row2.Background = NightTime;
            }
            else
            {
                TZ2.Foreground = DayText;
                TZ2Name.Foreground = DayText;
                TZ2Date.Foreground = DayText;
                Row2.Background = DayTime;
            }

            System.TimeZoneInfo _TZ3 = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            var TZ3Data = GetTZInfo(UTC, _TZ3);
            TZ3.Content = TZ3Data.Item1;
            TZ3Name.Content = TZ3Data.Item2;
            TZ3Date.Content = TZ3Data.Item3;
            if (IsDark(TZ3Data.Item5))
            {
                TZ3.Foreground = NightText;
                TZ3Name.Foreground = NightText;
                TZ3Date.Foreground = NightText;
                Row3.Background = NightTime;
            }
            else
            {
                TZ3.Foreground = DayText;
                TZ3Name.Foreground = DayText;
                TZ3Date.Foreground = DayText;
                Row3.Background = DayTime;
            }

            System.TimeZoneInfo _TZ4 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var TZ4Data = GetTZInfo(UTC, _TZ4);
            TZ4.Content = TZ4Data.Item1;
            TZ4Name.Content = TZ4Data.Item2;
            TZ4Date.Content = TZ4Data.Item3;
            if (IsDark(TZ4Data.Item5))
            {
                TZ4.Foreground = NightText;
                TZ4Name.Foreground = NightText;
                TZ4Date.Foreground = NightText;
                Row4.Background = NightTime;
            }
            else
            {
                TZ4.Foreground = DayText;
                TZ4Name.Foreground = DayText;
                TZ4Date.Foreground = DayText;
                Row4.Background = DayTime;
            }
        }

        private (string, string, string, bool, DateTime) GetTZInfo(DateTime Now, TimeZoneInfo TZInfo)
        {
            try
            {
                DateTime ZoneTime = TimeZoneInfo.ConvertTimeFromUtc(Now, TZInfo);
                bool IsDST = TZInfo.IsDaylightSavingTime(ZoneTime);
                string ZoneName = IsDST ? TZInfo.DaylightName : TZInfo.StandardName;
                string TimeString = ZoneTime.ToString("HH:mm:ss");
                string DateString = ZoneTime.ToString("dd MMMM yyyy");
                return (TimeString, ZoneName, DateString, IsDST, ZoneTime);
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the {0} zone.", Name);
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the {0} Time zone has been corrupted.", Name);
            }
            return ("", "", "", false, new DateTime());
        }

        private void HandleClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EditTimeZones(object sender, RoutedEventArgs e)
        {

        }
    }
}
