using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _619_HiveSimulator
{
    public delegate void ApplySettings(Settings newSettings);
    [Serializable]
    public class Settings
    {
        public int FrameInterval { get; set; }

        public HiveSettings HiveSettings { get; set; }
        public WorldSettings WorldSettings { get; set; }

        public Settings(int frameInterval = 50,
            WorldSettings worldSettings = null,
            HiveSettings hiveSettings = null)
        {
            FrameInterval = frameInterval;

            if (worldSettings == null)
                worldSettings = new WorldSettings();
            WorldSettings = worldSettings;

            if (hiveSettings == null)
                hiveSettings = new HiveSettings();
            HiveSettings = hiveSettings;
        }

        
    }
    
    [Serializable]
    public class HiveSettings
    {
        const int initialBeesDef = 6;//6
        const double initialHoneyDef = 3.2;

        const double nectarHoneyRatioDef = 0.25;
        const double minimumHoneyForCreationBeesDef = 4.0;

        const double maximumHoneyDef = 15.0;
        const int maximumBeesDef = 8;//8


        public int InitialBees { get; set; }
        public double InitialHoney { get; set; }
        public double NectarHoneyRatio { get; set; }
        public double MinimumHoneyForCreationBees { get; set; }        
        public double MaximumHoney { get; set; }
        public int MaximumBees { get; set; }

        public HiveSettings(int initialBees = initialBeesDef,
            double initialHoney = initialHoneyDef,
            double nectarHoneyRatio = nectarHoneyRatioDef,
            double minimumHoneyForCreationBees = minimumHoneyForCreationBeesDef,
            double maximumHoney = maximumHoneyDef,
            int maximumBees = maximumBeesDef)
        {
            InitialBees = initialBees;
            InitialHoney = initialHoney;
            NectarHoneyRatio = nectarHoneyRatio;
            MinimumHoneyForCreationBees = minimumHoneyForCreationBees;
            MaximumBees = maximumBees;
            MaximumHoney = maximumHoney;
        }
    }

    [Serializable]
    public class WorldSettings
    {
        const double nectarHarvestedPerNewFlowerDef = 50.0;
        public double NectarHarvestedPerNewFlower { get; set; }
        
        public WorldSettings(double nectarHarvestedPerNewFlower = nectarHarvestedPerNewFlowerDef)
        {
            NectarHarvestedPerNewFlower = nectarHarvestedPerNewFlower;
        }
    }

    
}
