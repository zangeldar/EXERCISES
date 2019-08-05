using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _619_HiveSimulator
{
    class Renderer
    {
        private World world;
        private HiveForm hiveForm;
        private FieldForm fieldForm;
                
        private List<Flower> deadFlowers = new List<Flower>();

        private List<Bee> retiredBees = new List<Bee>();

        public Renderer(World world, HiveForm hiveForm, FieldForm fieldForm)
        {
            this.world = world;
            this.hiveForm = hiveForm;
            this.fieldForm = fieldForm;
        }

        public void Render()
        {
            DrawBees();
            DrawFlowers();
            RemoveRetiredBeesAndDeadFlowers();            
        }

        public void Reset()
        {
            foreach (PictureBox flower in flowerLookup.Values)
            {
                fieldForm.Controls.Remove(flower);
                flower.Dispose();
            }
            foreach (BeeControl bee in beeLokup.Values)
            {
                hiveForm.Controls.Remove(bee);
                fieldForm.Controls.Remove(bee);
                bee.Dispose();
            }
            flowerLookup.Clear();
            beeLokup.Clear();
        }

        private void DrawFlowers()
        {
            foreach (Flower flower in world.Flowers)
            {
                if (!flowerLookup.ContainsKey(flower))
                {
                    PictureBox flowerControl = new PictureBox()
                    {
                        Width = 45,
                        Height = 55,
                        Image = Properties.Resources.Flower,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = flower.Location
                    };
                    flowerLookup.Add(flower, flowerControl);
                    fieldForm.Controls.Add(flowerControl);
                }
            }

            foreach (Flower flower in flowerLookup.Keys)
            {
                if (!world.Flowers.Contains(flower))
                {
                    PictureBox flowerControlToRemove = flowerLookup[flower];
                    fieldForm.Controls.Remove(flowerControlToRemove);
                    flowerControlToRemove.Dispose();
                    deadFlowers.Add(flower);
                }
            }
        }

        private void DrawBees(){
            BeeControl beeControl;
            foreach (Bee bee in world.Bees){
                beeControl = GetBeeControl(bee);
                if (bee.InsideHive)
                {
                    if (fieldForm.Controls.Contains(beeControl))
                        MoveBeeFromFieldToHive(beeControl);
                }
                else if (hiveForm.Controls.Contains(beeControl))
                    MoveBeeFromHiveToField(beeControl);
                beeControl.Location = bee.Location;  
            }

            foreach (Bee bee in beeLokup.Keys)
            {
                if (!world.Bees.Contains(bee))
                {
                    beeControl = beeLokup[bee];
                    if (fieldForm.Controls.Contains(beeControl))
                        fieldForm.Controls.Remove(beeControl);
                    if (hiveForm.Controls.Contains(beeControl))
                        hiveForm.Controls.Remove(beeControl);
                    beeControl.Dispose();
                    retiredBees.Add(bee);
                }
            }
        }
                
        private BeeControl GetBeeControl(Bee bee)
        {
            //throw new NotImplementedException();
            BeeControl beeControl;
            if (!beeLokup.ContainsKey(bee))
            {
                beeControl = new BeeControl() { Width = 40, Height = 40 };
                beeLokup.Add(bee, beeControl);
                hiveForm.Controls.Add(beeControl);
                beeControl.BringToFront();
            }
            else
                beeControl = beeLokup[bee];
            return beeControl;
        }

        private void MoveBeeFromHiveToField(BeeControl beeControl)
        {
            //throw new NotImplementedException();
            hiveForm.Controls.Remove(beeControl);
            beeControl.Size = new Size(20, 20);
            fieldForm.Controls.Add(beeControl);
            beeControl.BringToFront();
        }

        private void MoveBeeFromFieldToHive(BeeControl beeControl)
        {
            //throw new NotImplementedException();
            fieldForm.Controls.Remove(beeControl);
            beeControl.Size = new Size(40, 40);
            hiveForm.Controls.Add(beeControl);
            beeControl.BringToFront();
        }

        private void RemoveRetiredBeesAndDeadFlowers()
        {
            foreach (Bee bee in retiredBees)
                beeLokup.Remove(bee);
            retiredBees.Clear();
            foreach (Flower flower in deadFlowers)
                flowerLookup.Remove(flower);
            deadFlowers.Clear();
        }

        public static Bitmap ResizeImage(Bitmap picture, int width, int height)
        {
            Bitmap resizedPicture = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedPicture))
            {
                graphics.DrawImage(picture, 0, 0, width, height);
            }
            return resizedPicture;
        }
    }
}
