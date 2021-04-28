using BRY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Memo
{
	public class MemoEdit : Control
	{
		private TextBox m_tb = new TextBox();
		private const uint IMF_DUALFONT = 0x80;
		private const uint WM_USER = 0x0400;
		private const uint EM_SETLANGOPTIONS = WM_USER + 120;
		private const uint EM_GETLANGOPTIONS = WM_USER + 121;
		[System.Runtime.InteropServices.DllImport("USER32.dll")]
		private static extern uint SendMessage(System.IntPtr hWnd, uint msg, uint wParam, uint lParam);
	

		public string Doc
		{
			get { return m_tb.Text; }
			set { m_tb.Text = value; }
		}

		private bool refFlag = false;
		// ******************************************
		public MemoEdit()
		{
			m_tb.Multiline = true;
			m_tb.Font = new Font("源ノ角ゴシック Code JP R", 12f);
			m_tb.TextChanged += MemoEdit_TextChanged;
			m_tb.ForeColor = Color.White;
			m_tb.BackColor = Color.FromArgb(32,32,32);
			m_tb.BorderStyle = BorderStyle.None;
			m_tb.ScrollBars = ScrollBars.Both;
			m_tb.Location = new Point(15, 5);
			m_tb.Size = new Size(this.ClientSize.Width - 30, this.ClientSize.Height - 10);

			this.Controls.Add(m_tb);
			this.BackColor = m_tb.BackColor;
			this.ForeColor = m_tb.ForeColor;
			this.SizeChanged += MemoEdit_SizeChanged;

			uint lParam;
			lParam = SendMessage(this.Handle, EM_GETLANGOPTIONS, 0, 0);
			lParam &= ~IMF_DUALFONT;
			SendMessage(this.Handle, EM_SETLANGOPTIONS, 0, lParam);
			//this.Enabled = false;

			m_tb.LostFocus += M_tb_LostFocus;
			m_tb.GotFocus += M_tb_GotFocus;
			m_tb.VisibleChanged += M_tb_VisibleChanged;
		}

		private void M_tb_VisibleChanged(object sender, EventArgs e)
		{

		}

		private void M_tb_GotFocus(object sender, EventArgs e)
		{
			if (SelectionLength>0)
			{
				m_tb.Select(SelectionStart, SelectionLength);
			}
		}

		private int SelectionStart = 0;
		private int SelectionLength = 0;

		private void M_tb_LostFocus(object sender, EventArgs e)
		{
			SelectionStart = m_tb.SelectionStart;
			SelectionLength = m_tb.SelectionLength;
		}

		private void MemoEdit_SizeChanged(object sender, EventArgs e)
		{
			m_tb.Location = new Point(15, 5);
			m_tb.Size = new Size(this.ClientSize.Width - 15, this.ClientSize.Height - 10);
		}

		// ******************************************
		private void MemoEdit_TextChanged(object sender, EventArgs e)
		{
			if (refFlag) return;
		}
		// ******************************************
		protected override void InitLayout()
		{
			base.InitLayout();
		}
		// ******************************************
		public string DefSaveDir(string pp = "")
		{
			if (pp != "")
			{
				string p = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				pp = Path.Combine(p, "MemoEdit");
			}
			if (Directory.Exists(pp)==false)
			{
				Directory.CreateDirectory(pp);
			}
			return pp;
		}
		// ******************************************
		public bool Save(string p)
		{
			bool ret = false;
			if (p == "") return ret;
			try
			{
				if (File.Exists(p)) File.Delete(p);
				File.WriteAllText(p, this.Text, Encoding.GetEncoding("utf-8"));
				ret = File.Exists(p);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ************************************************************************
		public bool Load(string p = "")
		{
			bool ret = false;
			if (p == "") return ret;

			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
					this.Text = str;
					ret = true;
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ******************************************
		public void ClearText()
		{
			this.m_tb.Text = "";
		}
		public override Color BackColor
		{
			get { return base.BackColor; }
			set
			{
				m_tb.BackColor = value;
				base.BackColor = value;
			}
		}
		public string SelectedText
		{
			get { return m_tb.SelectedText; }
		}
		public Font TextFont
		{
			get { return m_tb.Font; }
			set
			{
				m_tb.Font = value;
				this.Font = value;
			}
		}
		public void CopyFrom()
		{
			if (m_tb.SelectionLength==0)
			{
				Clipboard.SetText(m_tb.Text);
			}
			else
			{
				m_tb.Copy();
			}
		}
		public void PasteTo()
		{

			m_tb.Paste();

		}
	}
}
