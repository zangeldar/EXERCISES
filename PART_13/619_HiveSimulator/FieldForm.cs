﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _619_HiveSimulator
{
    public partial class FieldForm : Form
    {
        public Renderer Renderer { get; set; }
        public FieldForm()
        {
            InitializeComponent();
        }

        private void FieldForm_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }

        private void FieldForm_Paint(object sender, PaintEventArgs e)
        {
            Renderer.PaintField(e.Graphics);
        }

        private void FieldForm_MouseClick_1(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }        
    }
}
