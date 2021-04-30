
namespace Memo
{
	partial class MemoForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.FileCMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.ImportCMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportCMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.encodeUTF8CMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.encodeShftJISCMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitCMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.btnEdit = new System.Windows.Forms.ToolStripDropDownButton();
			this.BtnEditCaption = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSelectionToCaption = new System.Windows.Forms.ToolStripMenuItem();
			this.btnFontSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCopy = new System.Windows.Forms.ToolStripButton();
			this.btnPaste = new System.Windows.Forms.ToolStripButton();
			this.btnMemos = new System.Windows.Forms.ToolStripDropDownButton();
			this.memoCMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
			this.memoEditList1 = new Memo.MemoEditList();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileCMenu,
            this.btnEdit,
            this.btnCopy,
            this.btnPaste,
            this.btnMemos});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(853, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// FileCMenu
			// 
			this.FileCMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FileCMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportCMenu,
            this.ExportCMenu,
            this.encodeUTF8CMenu,
            this.encodeShftJISCMenu,
            this.QuitCMenu});
			this.FileCMenu.Image = ((System.Drawing.Image)(resources.GetObject("FileCMenu.Image")));
			this.FileCMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FileCMenu.Name = "FileCMenu";
			this.FileCMenu.Size = new System.Drawing.Size(38, 22);
			this.FileCMenu.Text = "File";
			// 
			// ImportCMenu
			// 
			this.ImportCMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ImportCMenu.ForeColor = System.Drawing.Color.White;
			this.ImportCMenu.Name = "ImportCMenu";
			this.ImportCMenu.Size = new System.Drawing.Size(147, 22);
			this.ImportCMenu.Text = "Import";
			this.ImportCMenu.Click += new System.EventHandler(this.ImportCMenu_Click);
			// 
			// ExportCMenu
			// 
			this.ExportCMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ExportCMenu.ForeColor = System.Drawing.Color.White;
			this.ExportCMenu.Name = "ExportCMenu";
			this.ExportCMenu.Size = new System.Drawing.Size(147, 22);
			this.ExportCMenu.Text = "Export";
			this.ExportCMenu.Click += new System.EventHandler(this.ExportCMenu_Click);
			// 
			// encodeUTF8CMenu
			// 
			this.encodeUTF8CMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.encodeUTF8CMenu.Checked = true;
			this.encodeUTF8CMenu.CheckState = System.Windows.Forms.CheckState.Checked;
			this.encodeUTF8CMenu.ForeColor = System.Drawing.Color.White;
			this.encodeUTF8CMenu.Name = "encodeUTF8CMenu";
			this.encodeUTF8CMenu.Size = new System.Drawing.Size(147, 22);
			this.encodeUTF8CMenu.Text = "EncodeUTF8";
			this.encodeUTF8CMenu.Click += new System.EventHandler(this.encodeShftJISCMenu_Click);
			// 
			// encodeShftJISCMenu
			// 
			this.encodeShftJISCMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.encodeShftJISCMenu.ForeColor = System.Drawing.Color.White;
			this.encodeShftJISCMenu.Name = "encodeShftJISCMenu";
			this.encodeShftJISCMenu.Size = new System.Drawing.Size(147, 22);
			this.encodeShftJISCMenu.Text = "EncodeShftJIS";
			this.encodeShftJISCMenu.Click += new System.EventHandler(this.encodeShftJISCMenu_Click);
			// 
			// QuitCMenu
			// 
			this.QuitCMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.QuitCMenu.ForeColor = System.Drawing.Color.White;
			this.QuitCMenu.Name = "QuitCMenu";
			this.QuitCMenu.Size = new System.Drawing.Size(147, 22);
			this.QuitCMenu.Text = "Quit";
			this.QuitCMenu.Click += new System.EventHandler(this.QuitCMenu_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear,
            this.BtnEditCaption,
            this.btnSelectionToCaption,
            this.btnFontSettings});
			this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
			this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(40, 22);
			this.btnEdit.Text = "Edit";
			// 
			// BtnEditCaption
			// 
			this.BtnEditCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.BtnEditCaption.ForeColor = System.Drawing.Color.White;
			this.BtnEditCaption.Name = "BtnEditCaption";
			this.BtnEditCaption.Size = new System.Drawing.Size(180, 22);
			this.BtnEditCaption.Text = "EditCaption";
			this.BtnEditCaption.Click += new System.EventHandler(this.editCaptionToolStripMenuItem_Click);
			// 
			// btnSelectionToCaption
			// 
			this.btnSelectionToCaption.BackColor = System.Drawing.Color.Black;
			this.btnSelectionToCaption.ForeColor = System.Drawing.Color.White;
			this.btnSelectionToCaption.Name = "btnSelectionToCaption";
			this.btnSelectionToCaption.Size = new System.Drawing.Size(180, 22);
			this.btnSelectionToCaption.Text = "SelectionToCaption";
			// 
			// btnFontSettings
			// 
			this.btnFontSettings.BackColor = System.Drawing.Color.Black;
			this.btnFontSettings.ForeColor = System.Drawing.Color.White;
			this.btnFontSettings.Name = "btnFontSettings";
			this.btnFontSettings.Size = new System.Drawing.Size(180, 22);
			this.btnFontSettings.Text = "FontSettings";
			// 
			// btnCopy
			// 
			this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
			this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(38, 22);
			this.btnCopy.Text = "Copy";
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnPaste
			// 
			this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
			this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPaste.Name = "btnPaste";
			this.btnPaste.Size = new System.Drawing.Size(39, 22);
			this.btnPaste.Text = "Paste";
			this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
			// 
			// btnMemos
			// 
			this.btnMemos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnMemos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoCMenu});
			this.btnMemos.Image = ((System.Drawing.Image)(resources.GetObject("btnMemos.Image")));
			this.btnMemos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMemos.Name = "btnMemos";
			this.btnMemos.Size = new System.Drawing.Size(59, 22);
			this.btnMemos.Text = "Memos";
			// 
			// memoCMenu
			// 
			this.memoCMenu.BackColor = System.Drawing.Color.Black;
			this.memoCMenu.ForeColor = System.Drawing.Color.White;
			this.memoCMenu.Name = "memoCMenu";
			this.memoCMenu.Size = new System.Drawing.Size(108, 22);
			this.memoCMenu.Text = "Memo";
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnClear.ForeColor = System.Drawing.Color.White;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(180, 22);
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// memoEditList1
			// 
			this.memoEditList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.memoEditList1.BackColor = System.Drawing.Color.Black;
			this.memoEditList1.BackColorAll = System.Drawing.Color.Black;
			this.memoEditList1.CurrentCaption = "0";
			this.memoEditList1.CurrentDoc = "";
			this.memoEditList1.Font = new System.Drawing.Font("源ノ角ゴシック Code JP R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.memoEditList1.Location = new System.Drawing.Point(0, 28);
			this.memoEditList1.Name = "memoEditList1";
			this.memoEditList1.SelectedMemoIndex = 0;
			this.memoEditList1.Size = new System.Drawing.Size(853, 436);
			this.memoEditList1.TabIndex = 0;
			this.memoEditList1.TextFont = new System.Drawing.Font("源ノ角ゴシック Code JP R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			// 
			// MemoForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(853, 464);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.memoEditList1);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "MemoForm";
			this.ShowIcon = false;
			this.Text = "Memo";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
		private MemoEditList memoEditList1;
		private System.Windows.Forms.ToolStripButton btnCopy;
		private System.Windows.Forms.ToolStripButton btnPaste;
		private System.Windows.Forms.ToolStripDropDownButton btnEdit;
		private System.Windows.Forms.ToolStripMenuItem btnSelectionToCaption;
		private System.Windows.Forms.ToolStripMenuItem btnFontSettings;
		private System.Windows.Forms.ToolStripDropDownButton btnMemos;
		private System.Windows.Forms.ToolStripMenuItem memoCMenu;
		private System.Windows.Forms.ToolStripMenuItem BtnEditCaption;
		private System.Windows.Forms.ToolStripDropDownButton FileCMenu;
		private System.Windows.Forms.ToolStripMenuItem ImportCMenu;
		private System.Windows.Forms.ToolStripMenuItem ExportCMenu;
		private System.Windows.Forms.ToolStripMenuItem QuitCMenu;
		private System.Windows.Forms.ToolStripMenuItem encodeShftJISCMenu;
		private System.Windows.Forms.ToolStripMenuItem encodeUTF8CMenu;
		private System.Windows.Forms.ToolStripMenuItem btnClear;
	}
}

