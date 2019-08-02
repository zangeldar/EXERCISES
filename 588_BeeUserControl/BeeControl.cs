﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _588_BeeUserControl
{
    public partial class BeeControl : UserControl
    {
        int cell = 0;
        public BeeControl()
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            cell++;
            switch (cell)
            {
                case 1: BackgroundImage = Properties.Resources.Bee_animation_1; break;
                case 2: BackgroundImage = Properties.Resources.Bee_animation_2; break;
                case 3: BackgroundImage = Properties.Resources.Bee_animation_3; break;
                case 4: BackgroundImage = Properties.Resources.Bee_animation_4; break;
                case 5: BackgroundImage = Properties.Resources.Bee_animation_3; break;
                default: BackgroundImage = Properties.Resources.Bee_animation_2;
                    cell = 0; break;
            }
        }
    }
}
