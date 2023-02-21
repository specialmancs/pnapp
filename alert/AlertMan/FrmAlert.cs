using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlertMan
{
    public partial class FrmAlert : Form
    {
        private string icd; // field
        public string Icd   // property
        {
            get { return icd; }
            set { icd = value; }
        }
        public string User   // property
        {
            get { return icd; }
            set { icd = value; }
        }
        public FrmAlert()
        {
            InitializeComponent();
        }
    }
}
