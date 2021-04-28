using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memo
{
	public partial class EditCaptionDialog : Form
	{
		public EditCaptionDialog()
		{
			InitializeComponent();
		}
		public string Caption
		{
			get { return tbNew.Text.Trim(); }
			set
			{
				tbNew.Text = value;
				tbSrc.Text = value;
			}
		}
	}
}
