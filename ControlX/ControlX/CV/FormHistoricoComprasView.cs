﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlX.CV
{
    public partial class FormHistoricoComprasView : Form
    {
        public FormHistoricoComprasView()
        {
            InitializeComponent();
        }

        private void btVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txValor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
