using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _619_HiveSimulator
{
    [Serializable]
    public class Hive
    {
        [NonSerialized]
        public BeeMessage MessageSender;

        private World world;

        private HiveSettings hiveSettings;
            
        private int beeCount;
        private Dictionary<string, Point> locations;

        public double Honey { get; private set; }

        private void InitializeLocations()
        {
            locations = new Dictionary<string, Point>();
            locations.Add("Entrance", new Point(610, 95));
            locations.Add("Nursery", new Point(70, 140));
            locations.Add("HoneyFactory", new Point(160, 60));
            locations.Add("Exit", new Point(190, 170));
        }

        public Point GetLocation(string location)
        {
            if (locations.Keys.Contains(location))
                return locations[location];
            else
                throw new ArgumentException("Unknown location: " + location);
        }

        public Hive(World world, BeeMessage MessageSender, HiveSettings hiveSettings = null)
        {
            this.MessageSender = MessageSender;
            this.world = world;

            if (hiveSettings == null)
                hiveSettings = new HiveSettings();
            this.hiveSettings = hiveSettings;

            Honey = hiveSettings.InitialHoney;
            InitializeLocations();
            Random random = new Random();
            for (int i = 0; i < hiveSettings.InitialBees; i++)
            {
                AddBee(random);
            }
        }

        public bool AddHoney(double nectar)
        {
            double honeyToAdd = nectar * hiveSettings.NectarHoneyRatio;
            if (honeyToAdd + Honey > hiveSettings.MaximumHoney)
                return false;
            Honey += honeyToAdd;
            return true;
        }
        public bool ConsumeHoney(double amount)
        {
            if (amount > Honey)
                return false;
            Honey -= amount;
            return true;
        }
        private void AddBee(Random random)
        {
            beeCount++;
            int r1 = random.Next(100) - 50;
            int r2 = random.Next(100) - 50;
            Point startPoint = new Point(locations["Nursery"].X + r1,
                                            locations["Nursery"].Y + r2);
            Bee newBee = new Bee(beeCount, startPoint, world, this);
            newBee.MessageSender += this.MessageSender;
            world.Bees.Add(newBee);
        }
        public void Go(Random random)
        {
            if (world.Bees.Count < hiveSettings.MaximumBees          // Если мировой максимум пчел не превышен
                    && Honey > hiveSettings.MinimumHoneyForCreationBees     // Если меда достаточно, то
                    && random.Next(10) == 1)            //  в 10% случаев
                AddBee(random);                         //  создаем пчелу.
        }

        public void ApplySettings(HiveSettings hiveSettings)
        {
            this.hiveSettings = hiveSettings;
        }
    }
}
