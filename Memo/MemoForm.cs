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
using System.Text.Encodings.Web;
using System.Text.Encodings;

/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace Memo
{
	public partial class MemoForm : Form
	{
		NavBar m_navBar = new NavBar();
		ToolStripMenuItem[] m_MemeMenu = new ToolStripMenuItem[30];
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MemoForm()
		{
			InitializeComponent();
			memoCMenu.Visible = false;
			NavBarSetup();


			for (int i = 0; i < m_MemeMenu.Length; i++)
			{
				m_MemeMenu[i] = new ToolStripMenuItem();
				m_MemeMenu[i].DisplayStyle = ToolStripItemDisplayStyle.Text;
				m_MemeMenu[i].Click += MemoForm_Click;
				m_MemeMenu[i].Tag = (object)i;
				m_MemeMenu[i].ForeColor = Color.White;
				m_MemeMenu[i].Visible = false;
				btnMemos.DropDownItems.Add(m_MemeMenu[i]);
			}
			BackColors = Color.FromArgb(60, 60, 60);

			encodeUTF8CMenu.Tag = "UTF-8";
			encodeShftJISCMenu.Tag = "ShiftJIS";

			btnSelectionToCaption.Click += BtnSelectionToCaption_Click;
			btnFontSettings.Click += BtnFontSettings_Click;
			btnMemos.Click += BtnMemos_Click;
		}
		public Color BackColors
		{
			get { return memoEditList1.BackColorAll; }
			set
			{
				toolStrip1.BackColor = value;
				btnCopy.BackColor = value;
				btnPaste.BackColor = value;
				btnEdit.BackColor = value;
				btnMemos.BackColor = value;
				btnFontSettings.BackColor = value;
				btnSelectionToCaption.BackColor = value;
				BtnEditCaption.BackColor = value;
				memoEditList1.SetBackColorAll(value);
				for (int i = 0; i < m_MemeMenu.Length; i++)
				{
					m_MemeMenu[i].BackColor = value;
				}
				toolStrip1.BackColor = value;
				FileCMenu.BackColor = value;
				ImportCMenu.BackColor = value;
				ExportCMenu.BackColor = value;
				QuitCMenu.BackColor = value;
				encodeShftJISCMenu.BackColor = value;
				encodeUTF8CMenu.BackColor = value;
			}
		}

		private void BtnMemos_Click(object sender, EventArgs e)
		{
			ShowMemoMenu();
		}

		private void MemoForm_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem btn = (ToolStripMenuItem)sender;
			int idx = (int)(btn.Tag);
			if (idx>=0)
			{
				memoEditList1.SelectedMemoIndex = idx;
			}
		}

		private void BtnFontSettings_Click(object sender, EventArgs e)
		{
			memoEditList1.ShowFontDialog();
		}

		private void BtnSelectionToCaption_Click(object sender, EventArgs e)
		{
			memoEditList1.SelectionToCaption();
		}

		private void NavBarSetup()
		{
			m_navBar.Form = this;
			m_navBar.SizeSet();
			m_navBar.LocSet();
			m_navBar.Show();

		}

		/// <summary>
		/// コントロールの初期化はこっちでやる
		/// </summary>
		protected override void InitLayout()
		{
			base.InitLayout();

		}

		//-------------------------------------------------------------
		/// <summary>
		/// フォーム作成時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			PrefFile pref = new PrefFile();
			if (pref.Load())
			{
				Size sz;
				if (pref.GetSize("Size", out sz)) this.Size = sz;
				Point p;
				if (pref.GetPoint("Point", out p)) this.Location = p;
				double v = -1;
				if (pref.GetNum("index", out v)) if (v>=0)memoEditList1.SelectedMemoIndex = (int)v;
				string s = ""; double f = 14;
				if (pref.GetStr("font", out s)&&pref.GetNum("fontsize",out f))
				{
					memoEditList1.TextFont = new Font(s, (float)f);
				}
				bool b = true;
				if (pref.GetBool("IsEncodeUTF-8", out b))
				{
					encodeUTF8CMenu.Checked = b;
					encodeShftJISCMenu.Checked = ! b;
				}

			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			string pp = Path.Combine(pref.PrefFolder,  "Memos.json");

			if (File.Exists(pp))
			{
				memoEditList1.LoadAll(pp);
			}


		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォームが閉じられた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			PrefFile pref = new PrefFile();
			pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);
			pref.SetNum("index", memoEditList1.SelectedMemoIndex);
			pref.SetStr("font", memoEditList1.TextFont.Name);
			pref.SetNum("fontsize", memoEditList1.TextFont.Size);
			pref.SetBool("IsEncodeUTF-8", encodeUTF8CMenu.Checked);
			pref.Save();
			string pp = Path.Combine(pref.PrefFolder, "Memos.json");
			memoEditList1.SaveAll(pp);

		}
		//-------------------------------------------------------------
		/// <summary>
		/// ドラッグ＆ドロップの準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		public Encoding IOEncoding
		{
			get
			{
				if (encodeUTF8CMenu.Checked)
				{
					return Encoding.GetEncoding("utf-8");
				}
				else
				{
					return Encoding.GetEncoding("shift-jis");
				}
			}
		}

		/// <summary>
		/// ドラッグ＆ドロップの本体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ダミー関数
		/// </summary>
		/// <param name="cmd"></param>
		public void GetCommand(string[] cmd)
		{
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					if (memoEditList1.Import(s, IOEncoding))
					{
						break;
					}
				}
			}
		}

		public void ShowMemoMenu()
		{
			string[] caps = memoEditList1.Captions;

			int cnt = caps.Length;
			if (cnt > m_MemeMenu.Length) cnt = m_MemeMenu.Length;

			this.SuspendLayout();
			for ( int i=0; i<cnt;i++)
			{
				m_MemeMenu[i].Visible = (caps[i] != "");
				m_MemeMenu[i].Text = caps[i];
			}
			this.ResumeLayout();

		}

		private void editCaptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			memoEditList1.ShowCapDialg();
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			memoEditList1.CopyFrom();
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			memoEditList1.PasteTo();
		}

		private void encodeShftJISCMenu_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem mi = (ToolStripMenuItem)sender;
			string nm = (string)mi.Tag;
			bool b = (nm == "UTF-8");
			encodeUTF8CMenu.Checked = b;
			encodeShftJISCMenu.Checked = !b;
		}

		private void QuitCMenu_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ImportCMenu_Click(object sender, EventArgs e)
		{
			memoEditList1.ImportDialog(IOEncoding);
		}

		private void ExportCMenu_Click(object sender, EventArgs e)
		{
			memoEditList1.ExportDialog(IOEncoding);
		}
	}
}
