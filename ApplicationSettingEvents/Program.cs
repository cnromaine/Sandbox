using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using ApplicationSettingEvents.Properties;

namespace ApplicationSettingEvents
{
    class Program
    {
        /// <summary>
        /// Application Settings 
        /// from BlackWasp http://www.blackwasp.co.uk/SettingEvents.aspx
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Settings.Default.SettingsLoaded += new SettingsLoadedEventHandler(Default_SettingsLoaded);
            Settings.Default.SettingChanging += new SettingChangingEventHandler(Default_SettingChanging);
            Settings.Default.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Default_PropertyChanged);
            Settings.Default.SettingsSaving += new SettingsSavingEventHandler(Default_SettingsSaving);

            Console.WriteLine("MySetting = {0}", Settings.Default.MySetting);

            Settings.Default.MySetting = "New Value";

            Settings.Default.Save();
        }
        
        static void Default_SettingsLoaded(object sender, SettingsLoadedEventArgs e)
        {
            Console.WriteLine("Settings Loaded");
        }

        static void Default_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            Console.WriteLine("Changing {0} to {1}", e.SettingName, e.NewValue);
            Console.WriteLine("OK?");

            ConsoleKeyInfo confirmation = Console.ReadKey();
            if ( confirmation.Key != ConsoleKey.Y )
            {
                e.Cancel = true;
            }
            Console.WriteLine();
        }

        static void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("Changed {0}", e.PropertyName);
        }

        static void Default_SettingsSaving(object sender, CancelEventArgs e)
        {
            Console.WriteLine("Saving Settings");
            Console.WriteLine("OK?");

            ConsoleKeyInfo confirmation = Console.ReadKey();
            if ( confirmation.Key != ConsoleKey.Y )
            {
                e.Cancel = true;
            }
            Console.WriteLine();
        }
    }
}
