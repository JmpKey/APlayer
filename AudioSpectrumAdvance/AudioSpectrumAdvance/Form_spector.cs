using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioSpectrumAdvance
{
    public partial class Form_spector : Form
    {
        public Form_spector()
        {
            InitializeComponent();

            analyzer = new Analyzer(pB_left, pB_right, spectrum_elem, cB_spectrum, chart_spectrum);

            analyzer.enable = true;
            analyzer.display_enable = true;
            timer_spector.Enabled = true;
        }
        Analyzer analyzer;
    }
}