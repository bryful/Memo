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


namespace Memo
{
	public class MemoEditList : Control
	{
		private int m_MemoCount = 30;
		List<MemoEdit> m_memos = new List<MemoEdit>();
		private TabControl m_tc = new TabControl();
		//private Label m_lb = new Label();

		public int SelectedMemoIndex
		{
			get { return m_tc.SelectedIndex; }
			set {m_tc.SelectedIndex = value;}
		}

		public MemoEditList()
		{
			m_tc.SizeMode = TabSizeMode.Normal;
			m_tc.Appearance = TabAppearance.Normal;
			m_tc.ShowToolTips = true;
			ChkSize();
			this.Controls.Add(m_tc);

			for (int i=0; i<m_MemoCount;i++) Add();
			SetBackColorAll(Color.Black);

			m_tc.SelectedIndexChanged += M_tc_SelectedIndexChanged;
			this.Resize += MemoEditList_Resize;
		}

		private void MemoEditList_Resize(object sender, EventArgs e)
		{
			ChkSize();
		}

		public void ChkSize()
		{

			m_tc.Location = new Point(0, 0);
			m_tc.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
		}

		private void M_tc_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_tc.SelectedIndex>=0)
			{
				m_memos[m_tc.SelectedIndex].Focus();
			}
		}

		protected override void InitLayout()
		{
			base.InitLayout();
		}
		public void ClearAll()
		{
			if (m_memos.Count>0)
			{
				for (int i = 0; i < m_memos.Count; i++) m_memos[i].Doc = "";
			}
		}
		public void Add()
		{
			int cnt = m_tc.TabCount;
			m_tc.TabPages.Add(string.Format("{0}", cnt));
			MemoEdit me = new MemoEdit();
			me.Location = new Point(0, 0);
			me.Size = m_tc.TabPages[cnt].ClientSize;


			m_memos.Add(me);
			m_tc.TabPages[cnt].Controls.Add(me);
			m_tc.TabPages[cnt].ToolTipText = m_tc.TabPages[cnt].Text;
			m_tc.TabPages[cnt].SizeChanged += MemoEditList_SizeChanged;
		}



		private void MemoEditList_SizeChanged(object sender, EventArgs e)
		{
			TabPage tp = (TabPage)sender;
			if( tp.Controls.Count==1)
			{
				tp.Controls[0].Location = new Point(0, 0);
				tp.Controls[0].Size = tp.ClientSize;
			}
		}

		public void SetBackColorAll(Color c)
		{
			this.BackColor = c;
			if (m_tc.TabCount>0)
			{
				for (int i=0; i< m_tc.TabCount;i++)
				{
					m_tc.TabPages[i].BackColor = c;
				}
			}
			if(m_memos.Count>0)
			{
				for (int i = 0; i < m_memos.Count; i++)
				{
					m_memos[i].BackColor = c;
				}
			}
			this.Invalidate();
		}
		public  Color BackColorAll
		{
			get { return this.BackColor; }
			set
			{
				SetBackColorAll(value);
			}
		}
		public string DocToJson()
		{
			string ret = "";
			Dictionary<string, object> obj = new Dictionary<string, object>();
			obj.Add("Count", (object)m_memos.Count);

			string[] sa = new string[m_memos.Count];
			for ( int i=0; i< m_memos.Count;i++)
			{
				sa[i] = m_memos[i].Doc;
			}
			obj.Add("Memos", (object)sa);

			string[] sa2 = new string[m_tc.TabCount];
			for (int i = 0; i < m_tc.TabCount; i++)
			{
				sa2[i] = m_tc.TabPages[i].Text;
			}
			obj.Add("Captions", (object)sa2);

			string[] sa3 = new string[m_memos.Count];
			for (int i = 0; i < m_memos.Count; i++)
			{
				sa3[i] = m_memos[i].FileName;
			}
			obj.Add("FileNames", (object)sa3);


			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				WriteIndented = true
			};
			ret = JsonSerializer.Serialize(obj, options);
			return ret;
		}
		public bool JsonToDoc(string js)
		{
			bool ret = false;
			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};
			try
			{
				ClearAll();
				Dictionary<string, object> obj = new Dictionary<string, object>();
				obj = JsonSerializer.Deserialize<Dictionary<string, object>>(js, options);
				string key = "Count";
				int cnt = 0;
				if (obj.ContainsKey(key))
				{
					var si = (object)obj[key];

					try
					{
						if ((si is double) || (si is int))
						{
							cnt = (int)si;
						}
						else
						{
							JsonElement je = (JsonElement)si;
							if (je.ValueKind == JsonValueKind.Number)
							{
								cnt = je.GetInt32();
							}
						}
					}
					catch
					{
						ret = false;
					}
				}
				key = "Memos";
				if (obj.ContainsKey(key))
				{
					var so = (object)obj[key];
					string[] mm = new string[0];
					if (so != null)
					{
						try
						{

							if (so is string[])
							{
								mm = (string[])so;
							}
							else
							{
								JsonElement je = (JsonElement)so;
								if (je.ValueKind == JsonValueKind.Array)
								{
									List<string> da = new List<string>();
									foreach (var vv in je.EnumerateArray())
									{
										if (vv.ValueKind == JsonValueKind.String)
										{
											da.Add(vv.GetString());
										}
									}
									mm = da.ToArray();
								}

								if ((mm.Length == cnt))
								{
									int cnt2 = cnt;
									if (cnt2 > m_memos.Count) cnt2 = m_memos.Count;

									for (int i = 0; i < cnt2; i++) m_memos[i].Doc = mm[i];
									ret = true;
								}
							}
						}
						catch
						{
							ret = false;
						}
					}

				}
				key = "Captions";
				if (obj.ContainsKey(key))
				{
					var so = (object)obj[key];
					string[] mm = new string[0];
					if (so != null)
					{
						try
						{

							if (so is string[])
							{
								mm = (string[])so;
							}
							else
							{
								JsonElement je = (JsonElement)so;
								if (je.ValueKind == JsonValueKind.Array)
								{
									List<string> da = new List<string>();
									foreach (var vv in je.EnumerateArray())
									{
										if (vv.ValueKind == JsonValueKind.String)
										{
											da.Add(vv.GetString());
										}
									}
									mm = da.ToArray();
								}

								if ((mm.Length == cnt))
								{
									int cnt2 = cnt;
									if (cnt2 > m_tc.TabCount) cnt2 = m_tc.TabCount;

									for (int i = 0; i < cnt2; i++)
									{
										m_tc.TabPages[i].Text = mm[i];
										m_tc.TabPages[i].ToolTipText = mm[i];
									}
									ret = true;
								}
							}
						}
						catch
						{
							ret = false;
						}
					}


				}
				key = "FileNames";
				if (obj.ContainsKey(key))
				{
					var so = (object)obj[key];
					string[] mm = new string[0];
					if (so != null)
					{
						try
						{

							if (so is string[])
							{
								mm = (string[])so;
							}
							else
							{
								JsonElement je = (JsonElement)so;
								if (je.ValueKind == JsonValueKind.Array)
								{
									List<string> da = new List<string>();
									foreach (var vv in je.EnumerateArray())
									{
										if (vv.ValueKind == JsonValueKind.String)
										{
											da.Add(vv.GetString());
										}
									}
									mm = da.ToArray();
								}

								if ((mm.Length == cnt))
								{
									int cnt2 = cnt;
									if (cnt2 > m_memos.Count) cnt2 = m_memos.Count;

									for (int i = 0; i < cnt2; i++)
									{
										m_memos[i].FileName = mm[i];
									}
									ret = true;
								}
							}
						}
						catch
						{
							ret = false;
						}
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool SaveAll(string p)
		{
			bool ret = false;
			if (p == "") return ret;
			try
			{
				if (File.Exists(p)) File.Delete(p);
				File.WriteAllText(p, DocToJson(), Encoding.GetEncoding("utf-8"));
				ret = File.Exists(p);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool LoadAll(string p)
		{
			bool ret = false;
			if (p == "") return ret;

			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
					if (str != "")
					{
						ret = JsonToDoc(str);
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public void SelectionToCaption()
		{
			int idx = SelectedMemoIndex;
			if (idx < 0) return;

			string cap = m_memos[idx].SelectedText.Trim();
			if (cap == "") return;
			if (cap.Length > 100) cap = cap.Substring(0, 100).Trim();
			m_tc.TabPages[idx].Text = cap;
			m_tc.TabPages[idx].ToolTipText = cap;
		}
		public Font TextFont
		{
			get { return this.Font; }
			set
			{
				this.Font = value;
				m_tc.Font = new Font(value.FontFamily, value.Size *3/4);
				if (m_memos.Count>0)
				{
					for (int i = 0; i < m_memos.Count; i++) m_memos[i].TextFont = value;
				}
			}
		}
		public void ShowFontDialog()
		{
			FontDialog dlg = new FontDialog();
			try
			{
				dlg.Font = TextFont;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					TextFont = dlg.Font;
				}
			}
			finally
			{
				dlg.Dispose();
			}
		}
		public string[] Captions
		{
			get
			{
				string[] ret = new string[m_tc.TabCount];
				for (int i=0; i< m_tc.TabCount; i++)
				{
					if (m_memos[i].Doc != "")
					{
						ret[i] = m_tc.TabPages[i].Text;
					}
					else
					{
						ret[i] = "";
					}
				}
				return ret;
			}
		}
		public string CurrentCaption
		{
			get {
					if (SelectedMemoIndex >= 0)
					{
						return m_tc.TabPages[SelectedMemoIndex].Text;
					}
					else
					{
						return "";
					}
				}
			set {
				if (SelectedMemoIndex >= 0) {
					m_tc.TabPages[SelectedMemoIndex].Text = value;
				}
			}
		}
		public string CurrentDoc
		{
			get
			{
				if (SelectedMemoIndex >= 0)
				{
					return m_memos[SelectedMemoIndex].Doc;
				}
				else
				{
					return "";
				}
			}
			set
			{
				if (SelectedMemoIndex >= 0)
				{
					m_memos[SelectedMemoIndex].Doc = value;
				}
			}
		}
		public string CurrentFileName
		{
			get
			{
				if (SelectedMemoIndex >= 0)
				{
					return m_memos[SelectedMemoIndex].FileName;
				}
				else
				{
					return "";
				}
			}
			set
			{
				if (SelectedMemoIndex >= 0)
				{
					m_memos[SelectedMemoIndex].FileName = value;
				}
			}
		}
		public void CopyFrom()
		{
			if (SelectedMemoIndex >= 0)
			{
				m_memos[SelectedMemoIndex].CopyFrom();
			}
		}
		public void CutFrom()
		{
			if (SelectedMemoIndex >= 0)
			{
				m_memos[SelectedMemoIndex].CutFrom();
			}
		}
		public void PasteTo()
		{
			if (SelectedMemoIndex >= 0)
			{
					m_memos[SelectedMemoIndex].PasteTo();
			}
		}
		public void ShowCapDialg()
		{
			int idx = SelectedMemoIndex;
			if (idx < 0) return;
			EditCaptionDialog dlg = new EditCaptionDialog();
			try
			{
				dlg.Caption = CurrentCaption;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					CurrentCaption = dlg.Caption;
				}
			}
			finally
			{
				dlg.Dispose();
			}


		}
		public bool Import(string p,Encoding enc)
		{
			bool ret = false;
			if (SelectedMemoIndex < 0) return ret;

			if (File.Exists(p) == false) return ret;

			try
			{
				if (File.Exists(p) == true)
				{
					//Encoding.GetEncoding("utf-8")
					string str = File.ReadAllText(p, enc);
					if (str !="")
					{
						m_memos[SelectedMemoIndex].Doc = str;
						m_tc.TabPages[SelectedMemoIndex].Text = Path.GetFileNameWithoutExtension(p);
						m_memos[SelectedMemoIndex].FileName = p;
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ***************************************************************
		public bool Export(string p, Encoding enc)
		{
			bool ret = false;
			if (SelectedMemoIndex < 0) return ret;
			string str = m_memos[SelectedMemoIndex].Doc;
			try
			{
				if (File.Exists(p)) File.Delete(p);
				File.WriteAllText(p, str, enc);
				ret = File.Exists(p);
				if(ret)
				{
					m_memos[SelectedMemoIndex].FileName = p;
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ***************************************************************
		public bool ImportDialog(Encoding enc)
		{
			bool ret = false;
			OpenFileDialog dlg = new OpenFileDialog();
			try
			{
				if (CurrentFileName!="")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(CurrentFileName);
					dlg.FileName = Path.GetFileName(CurrentFileName);
				}
				if(dlg.ShowDialog()==DialogResult.OK)
				{
					ret = Import(dlg.FileName, enc);
				}

			}
			finally
			{
				dlg.Dispose();
			}
			return ret;
		}
		// ***************************************************************
		public bool ExportDialog(Encoding enc)
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			try
			{
				if (CurrentFileName != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(CurrentFileName);
					dlg.FileName = Path.GetFileName(CurrentFileName);
				}
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = Export(dlg.FileName, enc);
				}

			}
			finally
			{
				dlg.Dispose();
			}
			return ret;
		}
		// ***************************************************************
		public void ClearPage()
		{
			int idx = SelectedMemoIndex;
			if (idx < 0) return;
			m_memos[idx].Doc = "";
			m_tc.TabPages[idx].Text = string.Format("{0}", idx);
		}
	}
}
