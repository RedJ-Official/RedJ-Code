using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    public partial class MainForm : Form
    {
        private CodeTabPage CurrentTab => (CodeTabPage)tabControl.SelectedTab;
        private IEnumerable<CodeTabPage> AllTabs => tabControl.TabPages.Cast<CodeTabPage>();

        private readonly INI ini;
        //private readonly Preferences preferences;
        private readonly RecentFilesList recentFiles;

        //private readonly PreferencesDialog preferencesDialog;
        private readonly ColorPreferencesDialog colorPreferencesDialog;

        private int zoom = 100;

        private DiffMergeForm? DiffMerge;
        private HtmlDocEditForm? HtmlDocEdit;
        private GuidMakeForm? GuidMakeForm;
        private FileExplorerForm? FileExplorer;
        private TerminalForm? Terminal;

        private Color LineNumberColor;
        private Color BookmarkColor;
        private Color FoldingIndicatorColor;
        private Color CurrentLineColor;
        private Color SelectionColor;
        private Color DocumentMapColor;
        private Color AutocompleteMenuColor;
        private Color BackgroundColor;

        /*
         * Possible Fonts:
         *  - Consolas
         *  - Lucida Console
         *  - Cascadia Code
         */
        private static readonly Font EditorFont = new Font("Consolas", 10, FontStyle.Regular, GraphicsUnit.Point);

        public MainForm(string[] args)
        {
            InitializeComponent();
            menuStrip.Renderer = new ImprovedToolStripSystemRenderer();
            contextMenuStrip.Renderer = new ImprovedToolStripSystemRenderer();
            tabContextMenuStrip.Renderer = new ImprovedToolStripSystemRenderer();

            openFileDialog.Filter = StringTable.OpenFileDialogFilter;
            ini = new INI(StaticINI.GetCurrentPathToINI());
            recentFiles = new RecentFilesList(9);
            //preferencesDialog = new PreferencesDialog();
            colorPreferencesDialog = new ColorPreferencesDialog();

            ReadPreferences();
            ReadRecentFiles();

            foreach (string arg in args)
            {
                NewTab(arg);
            }

            if (tabControl.TabCount == 0)
            {
                NewTab();
            }


        }

        #region Settings

        private void ReadPreferences()
        {
            wordWrapToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "WordWrap", false);
            wordWrapAutoIndentToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "WordWrapAutoIndent", false);
            showLineNumbersToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "ShowLineNumbers", true);
            showFoldingLinesToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "ShowFoldingLines", true);
            showScrollBarsToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "ShowScrollBars", true);
            highlightFoldingIndicatorToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "HighlightFoldingIndicator", true);
            highlightCurrentLineToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "HighlightCurrentLine", true);
            highlightCurrentWordToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "HighlightCurrentWord", true);
            caretVisibleToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "CaretVisible", true);
            caretBlinkingToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "CaretBlinking", true);
            wideCaretToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "WideCaret", false);
            showCaretWhenIncativeToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "ShowCaretWhenInactive", false);
            autoIndentToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "AutoIndent", true);
            autoCompleteBracketsToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "AutoCompleteBrackets", true);
            virtualSpaceToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "VirtualSpace", false);
            allowDropToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "AllowDrop", true);
            showInvisibleCharsToolStripMenuItem.Checked = ini.ReadBoolean("FastColoredTextBox", "ShowInvisibleChars", false);

            documentMapVisibleToolStripMenuItem.Checked = ini.ReadBoolean("DocumentMap", "Visible", true);
            rulerVisibleToolStripMenuItem.Checked = ini.ReadBoolean("Ruler", "Visible", true);
            autocompleteMenuEnabledToolStripMenuItem.Checked = ini.ReadBoolean("AutocompleteMenu", "Enabled", true);
            toolStripVisibleToolStripMenuItem.Checked = ini.ReadBoolean("ToolStrip", "Visible", true);
            statusStripVisibleToolStripMenuItem.Checked = ini.ReadBoolean("StatusStrip", "Visible", true);
            //tabControl.Appearance = (TabAppearance)settings.ReadInt32("TabControl", "Appearance", 0);
            multilineTabsToolStripMenuItem.Checked = ini.ReadBoolean("TabControl", "Multiline", false);
            //tabControl.SizeMode = (TabSizeMode)settings.ReadInt32("TabControl", "SizeMode", 0);
            autoSaveToolStripMenuItem.Checked = ini.ReadBoolean("Misc", "AutoSave", false);

            //Colors
            LineNumberColor = Color.FromArgb(ini.ReadInt32("FastColoredTextBox", "LineNumberColor", ColorTable.LineNumberColor.ToArgb()));
            BookmarkColor = Color.FromArgb(ini.ReadInt32("FastColoredTextBox", "BookmarkColor", ColorTable.BookmarkColor.ToArgb()));
            FoldingIndicatorColor = Color.FromArgb(ini.ReadInt32("FastColoredTextBox", "FoldingIndicatorColor", ColorTable.FoldingIndicatorColor.ToArgb()));
            CurrentLineColor = Color.FromArgb(ini.ReadInt32("FastColoredTextBox", "CurrentLineColor", ColorTable.CurrentLineColor.ToArgb()));
            SelectionColor = Color.FromArgb(ini.ReadInt32("FastColoredTextBox", "SelectionColor", ColorTable.SelectionColor.ToArgb()));
            DocumentMapColor = Color.FromArgb(ini.ReadInt32("DocumentMap", "ForeColor", ColorTable.DocumentMapForeColor.ToArgb()));
            AutocompleteMenuColor = Color.FromArgb(ini.ReadInt32("AutocompleteMenu", "ForeColor", ColorTable.AutocompleteMenuColor.ToArgb()));
            BackgroundColor = Color.FromArgb(ini.ReadInt32("FastColoredTextBox", "BackColor", ColorTable.BackgroundColor.ToArgb()));

            // Font
            //string fontFamilyName = settings.ReadString("Font", "FamilyName", null!);
            //int fontSize = settings.ReadInt("Font", "Size", -1);
            //bool fontBold = settings.ReadBoolean("Font", "Bold", false);
            //bool fontItalic = settings.ReadBoolean("Font", "Italic", false);
            //bool fontUnderline = settings.ReadBoolean("Font", "Underline", false);
            //bool fontStrikout = settings.ReadBoolean("Font", "Strikeout", false);
            //if (fontFamilyName != null && fontSize != -1)
            //{
            //    textFont = Util.GenerateFont(fontFamilyName, fontSize, fontBold, fontItalic, fontUnderline, fontStrikout);
            //}
        }

        private void WritePreferences()
        {
            ini.WriteBoolean("FastColoredTextBox", "WordWrap", wordWrapToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "WordWrapAutoIndent", wordWrapAutoIndentToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "ShowLineNumbers", showLineNumbersToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "ShowFoldingLines", showFoldingLinesToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "ShowScrollBars", showScrollBarsToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "ShowInvisibleChars", showInvisibleCharsToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "HighlightFoldingIndicator", highlightFoldingIndicatorToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "HighlightCurrentLine", highlightCurrentLineToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "HighlightCurrentWord", highlightCurrentWordToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "AutoIndent", autoIndentToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "AutoCompleteBrackets", autoCompleteBracketsToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "VirtualSpace", virtualSpaceToolStripMenuItem.Checked);
            ini.WriteBoolean("FastColoredTextBox", "AllowDrop", allowDropToolStripMenuItem.Checked);
            ini.WriteBoolean("DocumentMap", "Visible", documentMapVisibleToolStripMenuItem.Checked);
            ini.WriteBoolean("Ruler", "Visible", rulerVisibleToolStripMenuItem.Checked);
            ini.WriteBoolean("AutocompleteMenu", "Enabled", autocompleteMenuEnabledToolStripMenuItem.Checked);
            ini.WriteBoolean("ToolStrip", "Visible", toolStripVisibleToolStripMenuItem.Checked);
            ini.WriteBoolean("StatusStrip", "Visible", statusStripVisibleToolStripMenuItem.Checked);
            ini.WriteBoolean("TabControl", "Multiline", multilineTabsToolStripMenuItem.Checked);

            //Colors
            ini.WriteInt32("FastColoredTextBox", "LineNumberColor", LineNumberColor.ToArgb());
            ini.WriteInt32("FastColoredTextBox", "BookmarkColor", BookmarkColor.ToArgb());
            ini.WriteInt32("FastColoredTextBox", "FoldingIndicatorColor", FoldingIndicatorColor.ToArgb());
            ini.WriteInt32("FastColoredTextBox", "CurrentLineColor", CurrentLineColor.ToArgb());
            ini.WriteInt32("FastColoredTextBox", "SelectionColor", SelectionColor.ToArgb());
            ini.WriteInt32("DocumentMap", "ForeColor", DocumentMapColor.ToArgb());
            ini.WriteInt32("AutocompleteMenu", "ForeColor", AutocompleteMenuColor.ToArgb());
            ini.WriteInt32("FastColoredTextBox", "BackColor", BackgroundColor.ToArgb());

            //settings.WriteBoolean("Misc", "AutoSave", autoSaveToolStripMenuItem.Checked);
        }

        #endregion

        #region Recent

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            recentToolStripMenuItem.Enabled = recentFiles.Files.Any();

            reloadToolStripMenuItem.Enabled =
            propertiesToolStripMenuItem.Enabled =
            changeEncodingToolStripMenuItem.Enabled =
            showInExplorerToolStripMenuItem.Enabled =
            copyFilePathToolStripMenuItem.Enabled =
                CurrentTab.FilePath != null;
        }

        private void LoadRecentFiles()
        {
            recentToolStripMenuItem.DropDownItems.Clear();

            for (int i = 0; i < recentFiles.Files.Count; i++)
            {
                ToolStripMenuItem item = new()
                {
                    Text = $"&{i + 1} \"{recentFiles.Files[i]}\""
                };

                item.Click += new EventHandler((sender, e) =>
                {
                    NewTab(item.Text[3..].Trim('"'));
                });

                recentToolStripMenuItem.DropDownItems.Add(item);
            }

            recentToolStripMenuItem.DropDownItems.Add(recentFilesToolStripSeparator);
            recentToolStripMenuItem.DropDownItems.Add(clearRecentListToolStripMenuItem);
        }

        private void ReadRecentFiles()
        {
            for (int i = recentFiles.MaxFiles; i > -1; --i)
            {
                recentFiles.AddFile(ini.ReadString("Recent", i.ToString(), string.Empty));
            }
        }

        private void WriteRecentFiles()
        {
            ini.DeleteSection("Recent");

            for (int i = 0; i < recentFiles.Files.Count; i++)
            {
                ini.WriteString("Recent", i.ToString(), recentFiles.Files[i]);
            }
        }

        private void AddRecentFile(string file)
        {
            recentFiles.AddFile(file);
        }

        private void ClearRecentFiles()
        {
            recentFiles.ClearFiles();
        }

        #endregion

        #region Tabs

        private void NewTab(string? filePath = null, bool readOnly = false)
        {
            CodeTabPage newTab = new CodeTabPage(filePath, readOnly);
            newTab.WordWrap = wordWrapToolStripMenuItem.Checked;
            newTab.WordWrapAutoIndent = wordWrapAutoIndentToolStripMenuItem.Checked;
            newTab.ShowLineNumbers = showLineNumbersToolStripMenuItem.Checked;
            newTab.ShowFoldingLines = showFoldingLinesToolStripMenuItem.Checked;
            newTab.ShowScrollBars = showScrollBarsToolStripMenuItem.Checked;
            newTab.HighlightFoldingIndicator = highlightFoldingIndicatorToolStripMenuItem.Checked;
            newTab.HighlightCurrentLine = highlightCurrentLineToolStripMenuItem.Checked;
            newTab.HighlightCurrentWord = highlightCurrentWordToolStripMenuItem.Checked;
            newTab.ShowInvisibleChars = showInvisibleCharsToolStripMenuItem.Checked;
            newTab.AutoIndent = autoIndentToolStripMenuItem.Checked;
            newTab.AutoCompleteBrackets = autoCompleteBracketsToolStripMenuItem.Checked;
            newTab.VirtualSpace = virtualSpaceToolStripMenuItem.Checked;
            newTab.AllowDragDrop = allowDropToolStripMenuItem.Checked;
            newTab.CaretVisible = caretVisibleToolStripMenuItem.Checked;
            newTab.CaretBlinking = caretBlinkingToolStripMenuItem.Checked;
            newTab.ShowCaretWhenInactive = showCaretWhenIncativeToolStripMenuItem.Checked;
            newTab.WideCaret = wideCaretToolStripMenuItem.Checked;
            newTab.AutoSave = autoSaveToolStripMenuItem.Checked;
            newTab.DocumentMapVisible = documentMapVisibleToolStripMenuItem.Checked;
            newTab.RulerVisible = rulerVisibleToolStripMenuItem.Checked;
            newTab.AutocompleteMenuEnabled = autocompleteMenuEnabledToolStripMenuItem.Checked;
            newTab.LineNumberColor = LineNumberColor;
            newTab.BookmarkColor = BookmarkColor;
            newTab.FoldingIndicatorColor = FoldingIndicatorColor;
            newTab.CurrentLineColor = CurrentLineColor;
            newTab.DocumentMapColor = DocumentMapColor;
            newTab.AutocompleteMenuColor = AutocompleteMenuColor;
            newTab.BackgroundColor = BackgroundColor;
            newTab.SelectionColor = SelectionColor;
            newTab.TextFont = EditorFont; ;
            newTab.Zoom = zoom;
            newTab.CodeChanged += new EventHandler(CodeChanged);
            newTab.ZoomChanged += new EventHandler(ZoomChanged);
            newTab.SetContextMenu(contextMenuStrip);
            newTab.SetAutocompleteMenuImageList(autocompleteImageList);
            if (newTab.FilePath != null)
            {
                AddRecentFile(newTab.FilePath);
                Language lang = Util.GetLanguageFromFileExtension(Path.GetExtension(newTab.FilePath));
                newTab.Language = lang == Language.Custom ? newTab.AutoDetectLanguage(false) : lang;
            }
            tabControl.TabPages.Add(newTab);
            tabControl.SelectedTab = newTab;
            RefreshLanguage();
            CurrentTab.FocusOnTextBox();
        }

        internal bool IsSafeToClose(CodeTabPage tab)
        {
            if (!tab.IsSaved)
            {
                tabControl.SelectedTab = tab;
                return MessageBox.Show(StringTable.CloseUnsavedFileMessageBoxText, tab.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) switch
                {
                    DialogResult.Yes => tab.Save(),
                    DialogResult.No => true,
                    _ => false,
                };
            }
            return true;
        }

        private void CloseTab()
        {
            CloseTab(CurrentTab);
        }

        private void CloseTab(CodeTabPage tab)
        {
            if (tab == null)
            {
                return;
            }

            if (!IsSafeToClose(tab))
            {
                return;
            }

            tabControl.TabPages.Remove(tab);
            tab.Dispose();

            if (tabControl.TabCount == 0)
            {
                NewTab();
            }
        }

        private void MoveTabLeft(TabPage tab)
        {
            int index = tabControl.TabPages.IndexOf(tab);

            if (index == 0 || index == -1)
            {
                return;
            }

            tabControl.TabPages.Remove(tab);
            tabControl.TabPages.Insert(index - 1, tab);
        }

        private void MoveTabRight(TabPage tab)
        {
            int index = tabControl.TabPages.IndexOf(tab);

            if (index == tabControl.TabCount - 1 || index == -1)
            {
                return;
            }

            tabControl.TabPages.Remove(tab);
            tabControl.TabPages.Insert(index + 1, tab);
        }

        #endregion

        #region Language

        internal void RefreshLanguage()
        {
            foreach (ToolStripItem item in languageToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = false;
                }
            }

            if (CurrentTab == null)
            {
                return;
            }

            (CurrentTab.Language switch
            {
                Language.PlainText => plainTextToolStripMenuItem,
                Language.CSharp => csharpToolStripMenuItem,
                Language.HTML => htmlToolStripMenuItem,
                Language.JS => jsToolStripMenuItem,
                Language.JSON => jsonToolStripMenuItem,
                Language.Lua => luaToolStripMenuItem,
                Language.PHP => phpToolStripMenuItem,
                Language.SQLServer => sqlToolStripMenuItem,
                Language.VB => vbToolStripMenuItem,
                Language.XML => xmlToolStripMenuItem,
                Language.MySQL => mySqlToolStripMenuItem,
                Language.Batch => batchToolStripMenuItem,
                Language.Java => javaToolStripMenuItem,
                Language.Python => pythonToolStripMenuItem
            }).CheckState = CheckState.Indeterminate;
        }

        private void RefreshStatusStrip()
        {
            if (statusStripVisibleToolStripMenuItem.Checked && CurrentTab != null)
            {
                charactersCountStatusLabel.Text = CurrentTab.CharCount.ToString();
                linesCountStatusLabel.Text = CurrentTab.LineCount.ToString();
            }
        }

        private void RefreshMenuStrip()
        {
            undoToolStripMenuItem.Enabled =
            redoToolStripMenuItem.Enabled =
            cutToolStripMenuItem.Enabled =
            pasteToolStripMenuItem.Enabled =
            replaceToolStripMenuItem.Enabled =
            linePrefixToolStripMenuItem.Enabled =
            advancedToolStripMenuItem.Enabled =
            caseToolStripMenuItem.Enabled =
            macrosToolStripMenuItem.Enabled =
            insertToolStripMenuItem.Enabled =
            cutToolStripButton.Enabled =
            pasteToolStripButton.Enabled =
            !CurrentTab.ReadOnly;
        }

        private void SetZoomToAll()
        {
            foreach (CodeTabPage tab in AllTabs)
            {
                tab.Zoom = zoom;
            }
        }

        private void CodeChanged(object? sender, EventArgs e)
        {
            RefreshStatusStrip();
        }

        private void ZoomChanged(object? sender, EventArgs e)
        {
            if (sender is not null and CodeTabPage tab)
            {
                zoom = tab.Zoom;
                SetZoomToAll();
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshStatusStrip();
            RefreshLanguage();
            //RefreshMenuStrip();
        }

        #endregion

        #region contextMenu

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool canUndo = CurrentTab.CanUndo;
            bool canRedo = CurrentTab.CanRedo;
            bool canCutCopy = CurrentTab.CanCutCopy;
            bool canPaste = CurrentTab.CanPaste;
            bool canSelectAll = CurrentTab.CanSelectAll;

            undoContextMenuToolStripMenuItem.Visible = canUndo;
            redoContextMenuToolStripMenuItem.Visible = canRedo;
            cutContextMenuToolStripMenuItem.Visible = canCutCopy;
            copyContextMenuToolStripMenuItem.Visible = canCutCopy;
            pasteContextMenuToolStripMenuItem.Visible = canPaste;
            selectAllContextMenuToolStripMenuItem.Visible = canSelectAll;
            contextMenuToolStripSeparator1.Visible = (canUndo || canRedo) && (canCutCopy || canPaste);
            contextMenuToolStripSeparator2.Visible = (canCutCopy || canPaste || canUndo || canRedo) && canSelectAll;

            bool langIsJSON = CurrentTab.Language == Language.JSON;

            newJsonObjectToolStripMenuItem.Visible = langIsJSON;
            newJsonArrayToolStripMenuItem.Visible = langIsJSON;
            newJsonKeyValuePairToolStripMenuItem.Visible = langIsJSON;
            contextMenuToolStripSeparator3.Visible = langIsJSON && (canSelectAll || canCutCopy || canPaste || canUndo || canRedo);

            e.Cancel = !(canUndo || canRedo || canCutCopy || canPaste || canSelectAll || langIsJSON);
        }

        #endregion

        #region tabContextMenu

        private void tabContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            TabPage? tab = GetTabAtMousePos();

            if (tab == null)
            {
                e.Cancel = true;
                return;
            }

            int index = tabControl.TabPages.IndexOf(tab);

            bool canMoveLeft = index > 0;
            bool canMoveRight = index < tabControl.TabCount - 1;

            tabMoveLeftToolStripMenuItem.Visible = canMoveLeft;
            tabMoveRightToolStripMenuItem.Visible = canMoveRight;
            tabContextMenuToolStripSeparator1.Visible = canMoveLeft || canMoveRight;
        }

        private void tabMoveLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveTabLeft(GetTabAtMousePos()!);
        }

        private void tabMoveRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveTabRight(GetTabAtMousePos()!);
        }

        private void tabSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTabAtMousePos()?.Save();
        }

        private void tabCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTab(GetTabAtMousePos()!);
        }

        private CodeTabPage? GetTabAtMousePos()
        {
            Point pt = tabControl.PointToClient(tabContextMenuStrip.PointToScreen(Point.Empty));

            for (int i = 0; i < tabControl.TabCount; i++)
            {
                if (tabControl.GetTabRect(i).Contains(pt))
                {
                    return (CodeTabPage)tabControl.TabPages[i];
                }
            }

            return null;
        }

        #endregion

        #region DragDrop

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

            if (e.Data != null && e.Data.GetFormats().Contains(DataFormats.FileDrop))
            {
                foreach (string file in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    NewTab(file);
                }
            }
        }

        #endregion

        #region OnClosing

        protected override void OnClosing(CancelEventArgs e)
        {
            bool closeOK = true;
            foreach (CodeTabPage tab in AllTabs)
            {
                if (closeOK)
                {
                    closeOK = IsSafeToClose(tab);
                }
                else
                {
                    break;
                }
            }
            if (closeOK)
            {
                WritePreferences();
                WriteRecentFiles();
            }
            e.Cancel = !closeOK;
            base.OnClosed(e);
        }

        #endregion

        // Menu Strip //

        #region File

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTab();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    NewTab(fileName, openFileDialog.ReadOnlyChecked);
                }
                WriteRecentFiles();
            }
        }

        private void recentToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            LoadRecentFiles();
        }

        private void clearRecentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearRecentFiles();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsSafeToClose(CurrentTab))
            {
                CurrentTab.Reload();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTab();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTab.Save())
            {
                AddRecentFile(CurrentTab.FilePath!);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTab.SaveAs())
            {
                AddRecentFile(CurrentTab.FilePath!);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Export();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.PrintRTF();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowProperties();
        }

        private void changeEncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ChangeEncoding();
        }

        private void showInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowInFileExplorer();
        }

        private void copyFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.CopyFilePath();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Edit

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.SelectAll();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowReplaceDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowGoToDialog();
        }

        private void linePrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using LinePrefixDialog dialog = new LinePrefixDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
                if (dialog.Remove)
                    CurrentTab.RemoveLinePrefix(dialog.Prefix);
                else
                    CurrentTab.InsertLinePrefix(dialog.Prefix);
        }

        private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CurrentTab.InsertText(DateTime.Now.ToString());
            CurrentTab.InsertDateTime();
        }

        private void increaseIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.IncreaseIndent();
        }

        private void decreaseIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.DecreaseIndent();
        }

        private void doAutoIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.DoAutoIndent();
        }

        private void toggleCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.CommentSelected();
        }

        private void commentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCommentPrefix();
        }

        private void uncommentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.RemoveCommentPrefix();
        }

        private void moveSelectedLinesUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.MoveSelectedLinesUp();
        }

        private void moveSelectedLinesDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.MoveSelectedLinesDown();
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Expand();
        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Collapse();
        }

        private void expandSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ExpandSelection();
        }

        private void collapseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.CollapseSelection();
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ExpandAll();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.CollapseAll();
        }

        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.UpperCase();
        }

        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.LowerCase();
        }

        private void titleCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.TitleCase();
        }

        private void sentenceCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.SentenceCase();
        }

        private void toInvertedCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InvertCase();
        }

        private void toRandomCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.RandomCase();
        }

        private void createXmlTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertXmlTag(false);
        }

        private void createXmlSingleTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertXmlTag(true);
        }

        private void showAutocompleteMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowAutocompleteMenu();
        }

        private void autoFormatJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.AutoFormatSelection(Language.JSON);
        }

        private void autoFormatXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.AutoFormatSelection(Language.XML);
        }

        private void base64EncodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.EncodeBase64();
        }

        private void base64DecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.DecodeBase64();
        }

        private void urlEncodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.EncodeURL();
        }

        private void urlDecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.DecodeURL();
        }

        private void regexEncodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.EncodeRegex();
        }

        private void regexDecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.DecodeRegex();
        }

        #endregion

        #region Bookmarks

        private void bookmarkLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.BookmarkLine();
        }

        private void unbookmarkLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.UnbookmarkLine();
        }

        private void gotoNextBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.NextBookmark();
        }

        private void gotoPreviousBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.PreviousBookmark();
        }

        private void toggleBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ToggleBookmark();
        }

        private void clearBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ClearBookmarks();
        }

        #endregion

        #region Macros

        private void myMacrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(SelectedTab.FastColoredTextBox.MacrosManager.Macros);
        }

        private void macrosToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            startRecordingToolStripMenuItem.Enabled = !CurrentTab.IsRecordingMacro;
            stopRecordingToolStripMenuItem.Enabled = CurrentTab.IsRecordingMacro;
            executeRecordedMacroToolStripMenuItem.Enabled = CurrentTab.CanExecuteMacro;
            clearMacroToolStripMenuItem.Enabled = CurrentTab.CanExecuteMacro;
        }

        private void toggleMacroRecrodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTab.IsRecordingMacro)
                CurrentTab.StopRecordingMacro();
            else
                CurrentTab.StartRecordingMacro();
        }

        private void startRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.StartRecordingMacro();
        }

        private void stopRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.StopRecordingMacro();
        }

        private void executeRecordedMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ExecuteMacro();
        }

        private void clearMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ClearMacro();
        }

        #endregion

        #region Language

        private void plainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.PlainText;
        }

        private void csharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.CSharp;
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.Batch;
        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.HTML;
        }

        private void javaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.Java;
        }

        private void jsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.JS;
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.JSON;
        }

        private void luaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.Lua;
        }

        private void phpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.PHP;
        }

        private void pythonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.Python;
        }

        private void sqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.SQLServer;
        }

        private void mySqlLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.MySQL;
        }

        private void vbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.VB;
        }

        private void xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.XML;
        }

        private void refreshSyntaxHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.RefreshSyntaxHighlighting();
        }

        private void autoDetectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = CurrentTab.AutoDetectLanguage(true);
        }

        #endregion

        #region View

        private void wordWrapToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.WordWrap = wordWrapToolStripMenuItem.Checked;
            }
        }

        private void wordWrapAutoIndentToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.WordWrapAutoIndent = wordWrapAutoIndentToolStripMenuItem.Checked;
            }
        }

        private void showLineNumbersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.ShowLineNumbers = showLineNumbersToolStripMenuItem.Checked;
            }
        }

        private void showFoldingLinesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.ShowFoldingLines = showFoldingLinesToolStripMenuItem.Checked;
            }
        }

        private void showScrollBarsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.ShowScrollBars = showScrollBarsToolStripMenuItem.Checked;
            }
        }

        private void showInvisibleCharsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.ShowInvisibleChars = showInvisibleCharsToolStripMenuItem.Checked;
            }
        }

        private void highlightFoldingIndicatorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.HighlightFoldingIndicator = highlightFoldingIndicatorToolStripMenuItem.Checked;
            }
        }

        private void highlightCurrentLineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.HighlightCurrentLine = highlightCurrentLineToolStripMenuItem.Checked;
            }
        }

        private void highlightCurrentWordToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.HighlightCurrentWord = highlightCurrentWordToolStripMenuItem.Checked;
            }
        }

        private void caretVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.CaretVisible = caretVisibleToolStripMenuItem.Checked;
            }
        }

        private void caretBlinkingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.CaretBlinking = caretBlinkingToolStripMenuItem.Checked;
            }
        }

        private void wideCaretToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.WideCaret = wideCaretToolStripMenuItem.Checked;
            }
        }

        private void showCaretWhenIncativeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.ShowCaretWhenInactive = showCaretWhenIncativeToolStripMenuItem.Checked;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FontDialog fontDialog = new FontDialog();
            fontDialog.Font = CurrentTab.TextFont;
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (CodeTabPage tabPage in AllTabs)
                {
                    tabPage.TextFont = fontDialog.Font;
                }
            }
        }

        private void autoIndentToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.AutoIndent = autoIndentToolStripMenuItem.Checked;
            }
        }

        private void autoCompleteBracketsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.AutoCompleteBrackets = autoCompleteBracketsToolStripMenuItem.Checked;
            }
        }

        private void virtualSpaceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.VirtualSpace = virtualSpaceToolStripMenuItem.Checked;
            }
        }

        private void allowDropToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.AllowDragDrop = allowDropToolStripMenuItem.Checked;
            }
        }

        private void documentMapVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.DocumentMapVisible = documentMapVisibleToolStripMenuItem.Checked;
            }
        }

        private void rulerVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.RulerVisible = rulerVisibleToolStripMenuItem.Checked;
            }
        }

        private void autocompleteMenuEnabledToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.AutocompleteMenuEnabled = autocompleteMenuEnabledToolStripMenuItem.Checked;
            }
        }

        private void toolStripVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            toolStrip.Visible = toolStripVisibleToolStripMenuItem.Checked;
        }

        private void statusStripVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip.Visible = statusStripVisibleToolStripMenuItem.Checked;
        }

        private void multilineTabsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            tabControl.Multiline = multilineTabsToolStripMenuItem.Checked;
        }

        private void fullscreenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (fullscreenToolStripMenuItem.Checked)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (preferencesDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //}
        }

        private void colorPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorPreferencesDialog.LineNumberColor = LineNumberColor;
            colorPreferencesDialog.BookmarkColor = BookmarkColor;
            colorPreferencesDialog.FoldingIndicatorColor = FoldingIndicatorColor;
            colorPreferencesDialog.CurrentLineColor = CurrentLineColor;
            colorPreferencesDialog.SelectionColor = SelectionColor;
            colorPreferencesDialog.DocumentMapColor = DocumentMapColor;
            colorPreferencesDialog.AutocompleteMenuColor = AutocompleteMenuColor;
            colorPreferencesDialog.BackgroundColor = BackgroundColor;

            if (colorPreferencesDialog.ShowDialog(this) == DialogResult.OK)
            {
                LineNumberColor = colorPreferencesDialog.LineNumberColor;
                BookmarkColor = colorPreferencesDialog.BookmarkColor;
                FoldingIndicatorColor = colorPreferencesDialog.FoldingIndicatorColor;
                CurrentLineColor = colorPreferencesDialog.CurrentLineColor;
                SelectionColor = colorPreferencesDialog.SelectionColor;
                DocumentMapColor = colorPreferencesDialog.DocumentMapColor;
                AutocompleteMenuColor = colorPreferencesDialog.AutocompleteMenuColor;
                BackgroundColor = colorPreferencesDialog.BackgroundColor;

                foreach (CodeTabPage tab in AllTabs)
                {
                    tab.LineNumberColor = LineNumberColor;
                    tab.BookmarkColor = BookmarkColor;
                    tab.FoldingIndicatorColor = FoldingIndicatorColor;
                    tab.CurrentLineColor = CurrentLineColor;
                    tab.SelectionColor = SelectionColor;
                    tab.DocumentMapColor = DocumentMapColor;
                    tab.AutocompleteMenuColor = AutocompleteMenuColor;
                    tab.BackgroundColor = BackgroundColor;
                }
            }
        }

        private void fontToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {
            //    fontToolStripMenuItem1.DropDownItems.Clear();
            //    foreach (FontFamily fontFamily in FontFamily.Families)
            //    {
            //        if (fontFamily.)
            //        {

            //        }
            //        ToolStripMenuItem item = new()
            //        {
            //            Text = fontFamily.Name,
            //        };
            //        item.Click += (sender, e) =>
            //        {
            //            CurrentTab.TextFont = new Font(((ToolStripMenuItem)sender).Text, CurrentTab.TextFont.Size);
            //        };
            //        fontToolStripMenuItem1.DropDownItems.Add(item);
            //    }
        }

        #endregion

        #region Insert

        #region C# Snippets

        private void csMainMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.CSharp_Main, Language.CSharp);
        }

        private void csToStringMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.CSharp_ToString, Language.CSharp);
        }

        private void csEqualsMethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.CSharp_Equals, Language.CSharp); ;
        }

        private void csGetHashCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.CSharp_GetHashCode, Language.CSharp);
        }

        #endregion

        #region Java Snippets

        private void javaMainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.Java_Main, Language.Java);
        }

        private void javaToStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.Java_ToString, Language.Java);
        }

        private void javaEqualsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.Java_Equals, Language.Java);
        }

        private void javaHashCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.Java_HashCode, Language.Java);
        }

        #endregion

        #region VB Snippets

        private void vbMainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.VB_Main, Language.VB);
        }

        private void vbToStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.VB_ToString, Language.VB);
        }

        private void vbEqualsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.VB_Equals, Language.VB);
        }

        private void vbGetHashCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.VB_GetHashCode, Language.VB);
        }

        #endregion

        #region HTML Snippets

        private void html5TemplateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.HTML_V5Document, Language.HTML);
        }

        private void html401TemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.HTML_V4Document, Language.HTML);
        }

        private void htmlXUACompatibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.HTML_XUACompatible, Language.HTML);
        }

        #endregion

        #region XML Snippets

        private void xmlPrologToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(Snippets.XML_Prolog, Language.XML);
        }

        #endregion

        #region JSON Snippets

        private void newJsonObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertNewJSONObject();
        }

        private void newJsonArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertNewJSONArray();
        }

        private void newJsonKeyValuePairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertNewJSONKeyValuePair();
        }

        #endregion

        #endregion

        #region Tools

        private void autoSaveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.AutoSave = autoSaveToolStripMenuItem.Checked;
            }
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNullOrDisposed(Terminal))
            {
                Terminal = new TerminalForm();
            }

            ShowForm(Terminal);
        }

        private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNullOrDisposed(FileExplorer))
            {
                FileExplorer = new FileExplorerForm();
            }

            ShowForm(FileExplorer);

            FileExplorer.AdjustLeft();
        }

        private void diffMergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNullOrDisposed(DiffMerge))
            {
                DiffMerge = new DiffMergeForm();
            }

            ShowForm(DiffMerge);
        }

        private void htmlDocEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNullOrDisposed(HtmlDocEdit))
            {
                HtmlDocEdit = new HtmlDocEditForm();
            }

            ShowForm(HtmlDocEdit);
        }

        private void guidMakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNullOrDisposed(GuidMakeForm))
            {
                GuidMakeForm = new GuidMakeForm();
            }

            ShowForm(GuidMakeForm);
        }

        private bool IsNullOrDisposed([NotNullWhen(false)] Form? form)
        {
            return form == null || form.IsDisposed;
        }

        private void ShowForm(Form form)
        {
            if (form.Visible)
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }

                form.BringToFront();
                form.Activate();
            }
            else
            {
                form.Show(this);
            }
        }

        #endregion

        #region Help

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(StringTable.ResetSettingsMessageBoxText, "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                File.Delete(ini.FilePath);
                ReadPreferences();
                ReadRecentFiles();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        #endregion

        // Image //


    }
}