using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Diagnostics; // to use debug log ;)

using System.Collections; // YGE : to use lists



namespace EQ_Parser
{
    public partial class Form1 : Form
    {
        private bool SettingsLoaded;
        private string LogName;
        private long LastFileSize;

        private ArrayList SpellBarCollection; // YGE :  Will hold all your current Spellbars

        public Form1()
        {

            LastFileSize = 0;
            SettingsLoaded = false;
            LogName = "";

            SpellBarCollection = new ArrayList(); // YGE : creates my list

            SettingsFile();
            InitializeComponent();
        }

        public void SettingsFile()
        {
            //TextReader tr = new StreamReader("config.dat");
            try
            {
                StreamReader s = File.OpenText("config.dat");
                string read = null;
                while ((read = s.ReadLine()) != null)
                {
                    if (read.StartsWith("eqlog"))
                    {
                        SettingsLoaded = true;
                        LogName = read.Substring(6);
                        Debug.WriteLine("LogName : " + LogName);
                    }

                }
            }
            catch
            {
                SettingsLoaded = false;
            }
        
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();

            SpellBarCollection.Clear(); // YGE : clears the spellbar list ;)

            int iMax = rand.Next(5, 15);

            // YGE : creating iMax random bars
            for (int i = 0; i < iMax; ++i)
            {
                // YGE: Creates a SpellBar ref, fills it and display it
                spellbar SpellBar1 = new spellbar();
                SpellBar1.Location = new Point(10, 10 + i * 36);
                SpellBar1.spellDuration = rand.Next(10, 90);
                SpellBar1.spellName = "Spell " + i;
                SpellBar1.EnableBox();

                SpellBar1.TimeIsUpEvent += SpellBarTimeIsUp; // YGE: this is an event that i added in Spellbar.cs

                panel1.Controls.Add(SpellBar1); // YGE : That s just to display my component

                SpellBarCollection.Add(SpellBar1);  // YGE : add the spellbar reference to my List.
            }


            // add Watchers to the file, function will be called everytime the specified file is changed, created or deleted ... blabla
            System.IO.FileSystemWatcher _watcher = new System.IO.FileSystemWatcher("c:\\", "eqlog.txt");
            FileSystemEventHandler handler = new FileSystemEventHandler(watcher_Changed);
            _watcher.Changed += handler;
            _watcher.Created += handler;
            _watcher.Deleted += handler;
            // Without setting EnableRaisingEvents nothing happens
            _watcher.EnableRaisingEvents = true;
       
        }

        public void SpellBarTimeIsUp(object sender, SpellBarEventArgs e)
        {
            // YGE : Ok, called when a bar reaches 0 !!
            Debug.WriteLine(e.spellName +" bar reached 0");

            // YGE : now, i parse my ArrayList to find and remove that spellbar
            // can do it with a while, for or an iterator

            int NumToKill = -1;
            for (int i = 0; i < SpellBarCollection.Count; ++i)
            {
                spellbar SpellBarRef = (spellbar)SpellBarCollection[i]; // cast my ArrayListMember to a SpellBar

                if (SpellBarRef.spellName == e.spellName) // YGE : i got the spell name that reaches 0 from the event, could probably pass a SpellBar Reference too, or cast the "sender" object
                {
                    NumToKill = i;
                }
            }

            // YGE : found it, i stop displaying it, and kill it
            if (NumToKill > 0)
            {
                spellbar SpellBarToKill = (spellbar)SpellBarCollection[NumToKill];
                panel1.Controls.Remove(SpellBarToKill); // YGE : Remove it from the panel
                SpellBarCollection.RemoveAt(NumToKill); // YGE : Remove it from my list
                // the garbage collector will remove the unused spellbar from memory automatically, as long as it s not referenced anywhere anymore

                // YGE : now, i fill the blanks in the display
                for (int i = 0; i < SpellBarCollection.Count; ++i)
                {
                    spellbar SpellBarRef = (spellbar)SpellBarCollection[i];

                    SpellBarRef.Location = new Point(10, 10 + i * 36);
                }
            }

        }

        public void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string _fileName = e.FullPath;
            string newFileLines = "";

            // first, open the file with the lowest rights possible : no modif, read only .. so EQ still has priority on that file ( it should be locked by EQ anyway ) 
            using (FileStream stream = File.Open(_fileName, 
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                // check if there was an update since last time i read it
                if (stream.Length > LastFileSize)
                {
                    // there was, so i m positionning myself at the last read pos, and read the rest of the strings
                    stream.Position = LastFileSize;
                    LastFileSize = stream.Length;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        newFileLines = reader.ReadToEnd();
                    }
                    
                    // there, you get the new lines, just do whatever you want with it... add it to a buffer, treat it .. etc ;)
                    Debug.Write(newFileLines);
                }
            }
        }       

    }
}