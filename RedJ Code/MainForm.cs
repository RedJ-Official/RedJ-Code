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

        private readonly Settings settings;
        private readonly RecentFilesList recentFiles;

        private Dictionary<Snippet, string> snippets = new()
        {
            { Snippet.CSharp_Main               , "public static void Main(string[] args)\n{\n\n}"},
            { Snippet.CSharp_ToString           , "public override string ToString()\n{\nreturn base.ToString();\n}" },
            { Snippet.CSharp_Equals             , "public override bool Equals(object? obj)\n{\nreturn base.Equals(obj);\n}" },
            { Snippet.CSharp_GetHashCode        , "public override int GetHashCode()\n{\nreturn base.GetHashCode();\n}" },

            { Snippet.VB_Main                   , "Sub Main(args As String())\n\nEnd Sub"},
            { Snippet.VB_ToString               , "Public Overrides Function Equals(obj As Object) As Boolean\nReturn MyBase.Equals(obj)\nEnd Function" },
            { Snippet.VB_Equals                 , "Public Overrides Function GetHashCode() As Integer\nReturn MyBase.GetHashCode()\nEnd Function" },
            { Snippet.VB_GetHashCode            , "Public Overrides Function ToString() As String\nReturn MyBase.ToString()\nEnd Function" },

            { Snippet.HTML_Document             , "<!DOCTYPE html>\n<html>\n<head>\n<meta charset=\"UTF-8\">\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1.0\">\n<title>YOUR WEBSITE TITLE</title>\n</head>\n<body>\nYOUR WEBSITE CONTENT\n</body>\n</html>" },
            { Snippet.HTML_Doctype              , "<!DOCTYPE html>" },
            { Snippet.HTML_Doctype401           , "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">" },
            { Snippet.HTML_Doctype32            , "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 3.2 Final//EN\">" },
            { Snippet.HTML_Doctype2             , "<!DOCTYPE html PUBLIC \"-//IETF//DTD HTML 2.0//EN\">" },
            { Snippet.HTML_XUACompatible        , "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" },

            { Snippet.XML_Prolog                , "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" },
        };

        private DiffMergeForm? DiffMerge;
        private HtmlDocEditForm? HtmlDocEdit;

        //private Font textFont;

        public MainForm(string[] args)
        {
            InitializeComponent();

            menuStrip.Renderer = new ImprovedToolStripSystemRenderer();
            openFileDialog.Filter = StringTable.OpenFileDialogFilter;
            settings = new Settings(Settings.GetSettingsFilePath(Application.ExecutablePath));
            recentFiles = new RecentFilesList(9);

            ReadSettings();
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

        private void ReadSettings()
        {
            wordWrapToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "WordWrap", false);
            wordWrapAutoIndentToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "WordWrapAutoIndent", false);
            showLineNumbersToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "ShowLineNumbers", true);
            showFoldingLinesToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "ShowFoldingLines", true);
            showScrollBarsToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "ShowScrollBars", true);
            highlightCurrentLineToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "CurrentLineColor", true);
            highlightCurrentWordToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "CurrentWordColor", true);
            caretVisibleToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "CaretVisible", true);
            caretBlinkingToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "CaretBlinking", true);
            wideCaretToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "WideCaret", false);
            showCaretWhenIncativeToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "ShowCaretWhenInactive", false);
            autoIndentToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "AutoIndent", true);
            autoCompleteBracketsToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "AutoCompleteBrackets", true);
            virtualSpaceToolStripMenuItem.Checked = settings.ReadBool("FastColoredTextBox", "VirtualSpace", false);
            documentMapVisibleToolStripMenuItem.Checked = settings.ReadBool("DocumentMap", "Visible", true);
            rulerVisibleToolStripMenuItem.Checked = settings.ReadBool("Ruler", "Visible", true);
            autocompleteMenuEnabledToolStripMenuItem.Checked = settings.ReadBool("AutocompleteMenu", "Enabled", true);
            toolStripVisibleToolStripMenuItem.Checked = settings.ReadBool("ToolStrip", "Visible", true);
            statusStripVisibleToolStripMenuItem.Checked = settings.ReadBool("StatusStrip", "Visible", true);
            multilineTabsToolStripMenuItem.Checked = settings.ReadBool("TabControl", "Multiline", false);
            autoSaveToolStripMenuItem.Checked = settings.ReadBool("Misc", "AutoSave", false);
            // Font
            //string fontFamilyName = settings.ReadString("Font", "FamilyName", null!);
            //int fontSize = settings.ReadInt("Font", "Size", -1);
            //bool fontBold = settings.ReadBool("Font", "Bold", false);
            //bool fontItalic = settings.ReadBool("Font", "Italic", false);
            //bool fontUnderline = settings.ReadBool("Font", "Underline", false);
            //bool fontStrikout = settings.ReadBool("Font", "Strikeout", false);
            //if (fontFamilyName != null && fontSize != -1)
            //{
            //    textFont = Util.GenerateFont(fontFamilyName, fontSize, fontBold, fontItalic, fontUnderline, fontStrikout);
            //}
        }

        private void WriteSettings()
        {
            settings.WriteBool("FastColoredTextBox", "WordWrap", wordWrapToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "WordWrapAutoIndent", wordWrapAutoIndentToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "ShowLineNumbers", showLineNumbersToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "ShowFoldingLines", showFoldingLinesToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "ShowScrollBars", showScrollBarsToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "CurrentLineColor", highlightCurrentLineToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "CurrentWordColor", highlightCurrentWordToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "CaretVisible", caretVisibleToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "CaretBlinking", caretBlinkingToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "WideCaret", wideCaretToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "ShowCaretWhenInactive", showCaretWhenIncativeToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "AutoIndent", autoIndentToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "AutoCompleteBrackets", autoCompleteBracketsToolStripMenuItem.Checked);
            settings.WriteBool("FastColoredTextBox", "VirtualSpace", virtualSpaceToolStripMenuItem.Checked);
            settings.WriteBool("DocumentMap", "Visible", documentMapVisibleToolStripMenuItem.Checked);
            settings.WriteBool("Ruler", "Visible", rulerVisibleToolStripMenuItem.Checked);
            settings.WriteBool("AutocompleteMenu", "Enabled", autocompleteMenuEnabledToolStripMenuItem.Checked);
            settings.WriteBool("ToolStrip", "Visible", toolStripVisibleToolStripMenuItem.Checked);
            settings.WriteBool("StatusStrip", "Visible", statusStripVisibleToolStripMenuItem.Checked);
            settings.WriteBool("TabControl", "Multiline", multilineTabsToolStripMenuItem.Checked);

            //settings.WriteBool("Misc", "AutoSave", autoSaveToolStripMenuItem.Checked);
        }

        #endregion

        #region Recent

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            recentToolStripMenuItem.Enabled = recentFiles.Files.Any();

            reloadToolStripMenuItem.Enabled =
            propertiesToolStripMenuItem.Enabled =
            showInExplorerToolStripMenuItem.Enabled =
            copyFilePathToolStripMenuItem.Enabled =
                CurrentTab.FilePath != null;
        }

        private void LoadRecentFiles()
        {
            recentToolStripMenuItem.DropDownItems.Clear();

            for (int i = 0; i < recentFiles.Files.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();

                item.Text = $"&{i + 1} \"{recentFiles.Files[i]}\"";
                item.Click += new EventHandler((sender, e) =>
                {
                    NewTab(item.Text[3..]);
                });

                recentToolStripMenuItem.DropDownItems.Add(item);
            }

            recentToolStripMenuItem.DropDownItems.Add(recentFilesToolStripSeparator);
            recentToolStripMenuItem.DropDownItems.Add(clearRecentListToolStripMenuItem);
        }

        private void ReadRecentFiles()
        {
            for (int i = 1; i <= recentFiles.MaxFiles; i++)
            {
                recentFiles.AddFile(settings.ReadString("Recent", i.ToString(), string.Empty));
            }
        }

        private void WriteRecentFiles()
        {
            settings.DeleteSection("Recent");

            for (int i = 0; i < recentFiles.Files.Count; i++)
            {
                settings.WriteString("Recent", (i + 1).ToString(), recentFiles.Files[i]);
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

        private void NewTab()
        {
            NewTab(null);
        }

        private void NewTab(string? filePath)
        {
            CodeTabPage tabPage = new CodeTabPage(filePath);
            tabPage.WordWrap = wordWrapToolStripMenuItem.Checked;
            tabPage.WordWrapAutoIndent = wordWrapAutoIndentToolStripMenuItem.Checked;
            tabPage.ShowLineNumbers = showLineNumbersToolStripMenuItem.Checked;
            tabPage.ShowFoldingLines = showFoldingLinesToolStripMenuItem.Checked;
            tabPage.ShowScrollBars = showScrollBarsToolStripMenuItem.Checked;
            tabPage.HighlightCurrentLine = highlightCurrentLineToolStripMenuItem.Checked;
            tabPage.HighlightCurrentWord = highlightCurrentWordToolStripMenuItem.Checked;
            tabPage.AutoIndent = autoIndentToolStripMenuItem.Checked;
            tabPage.AutoCompleteBrackets = autoCompleteBracketsToolStripMenuItem.Checked;
            tabPage.VirtualSpace = virtualSpaceToolStripMenuItem.Checked;
            tabPage.CaretVisible = caretVisibleToolStripMenuItem.Checked;
            tabPage.CaretBlinking = caretBlinkingToolStripMenuItem.Checked;
            tabPage.ShowCaretWhenInactive = showCaretWhenIncativeToolStripMenuItem.Checked;
            tabPage.WideCaret = wideCaretToolStripMenuItem.Checked;
            tabPage.AutoSave = autoSaveToolStripMenuItem.Checked;
            tabPage.DocumentMapVisible = documentMapVisibleToolStripMenuItem.Checked;
            tabPage.RulerVisible = rulerVisibleToolStripMenuItem.Checked;
            tabPage.AutocompleteMenuEnabled = autocompleteMenuEnabledToolStripMenuItem.Checked;
            tabPage.TextFont = new Font("Consolas", 10, FontStyle.Regular, GraphicsUnit.Point);
            tabPage.CodeChanged += new EventHandler(CodeChanged);
            tabPage.SetContextMenu(contextMenuStrip);
            if (tabPage.FilePath != null)
            {
                AddRecentFile(tabPage.FilePath);
                tabPage.Language = Util.GetLanguageFromFileExtension(Path.GetExtension(tabPage.FilePath));
            }
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
            RefreshLanguage();
            CurrentTab.FocusOnTextBox();
        }

        private bool IsSafeToClose(CodeTabPage tab)
        {
            if (!tab.IsSaved)
            {
                tab.Select();
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

        private void RefreshLanguage()
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

            switch (CurrentTab.Language)
            {
                case Language.PlainText:
                    plainTextToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.CSharp:
                    csharpToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.HTML:
                    htmlToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.JS:
                    jsToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.JSON:
                    jsonToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.Lua:
                    luaToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.PHP:
                    phpToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.SQL:
                    sqlToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.VB:
                    vbToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
                case Language.XML:
                    xmlToolStripMenuItem.CheckState = CheckState.Indeterminate;
                    break;
            }
        }

        private void RefreshStatusStrip()
        {
            if (statusStripVisibleToolStripMenuItem.Checked && CurrentTab != null)
            {
                charactersCountStatusLabel.Text = CurrentTab.CharCount.ToString();
                linesCountStatusLabel.Text = CurrentTab.LineCount.ToString();
            }
        }

        private void CodeChanged(object? sender, EventArgs e)
        {
            RefreshStatusStrip();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshStatusStrip();
            RefreshLanguage();
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

            e.Cancel = !(canUndo || canRedo || canCutCopy || canPaste || canSelectAll);
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
                WriteSettings();
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
                    NewTab(fileName);
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

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.PrintPreview();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.PageSetupRTF();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.ShowProperties();
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

        private void autoFormatSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.AutoFormatSelection();
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

        private void startRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.StartRecoringMacro();
        }

        private void stopRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.StopRecoringMacro();
        }

        #endregion

        #region View

        private void plainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.PlainText;
            RefreshLanguage();
        }

        private void csharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.CSharp;
            RefreshLanguage();
        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.HTML;
            RefreshLanguage();
        }

        private void jsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.JS;
            RefreshLanguage();
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.JSON;
            RefreshLanguage();
        }

        private void luaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.Lua;
            RefreshLanguage();
        }

        private void phpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.PHP;
            RefreshLanguage();
        }

        private void sqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.SQL;
            RefreshLanguage();
        }

        private void vbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.VB;
            RefreshLanguage();
        }

        private void xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.Language = Language.XML;
            RefreshLanguage();
        }

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

        private void refreshSyntaxHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.RefreshSyntaxHighlighting();
        }

        private void autoDetectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.AutoDetectLanguage();
        }

        #endregion

        #region Insert

        private void csMainMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.CSharp_Main], Language.CSharp);
        }

        private void csToStringMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.CSharp_ToString], Language.CSharp);
        }

        private void csEqualsMethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.CSharp_Equals], Language.CSharp); ;
        }

        private void getHashCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.CSharp_GetHashCode], Language.CSharp);
        }

        private void vbMainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.VB_Main], Language.VB);
        }

        private void vbToStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.VB_ToString], Language.VB);
        }

        private void vbEqualsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.VB_Equals], Language.VB);
        }

        private void vbGetHashCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.VB_GetHashCode], Language.VB);
        }

        private void html5TemplateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.HTML_Document], Language.HTML);
        }

        private void html5DoctypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.HTML_Doctype], Language.HTML);
        }

        private void html401DoctypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.HTML_Doctype401], Language.HTML);
        }

        private void html32DoctypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.HTML_Doctype32], Language.HTML);
        }

        private void html2DoctypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.HTML_Doctype2], Language.HTML);
        }

        private void htmlXUACompatibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.HTML_XUACompatible], Language.HTML);
        }

        private void xmlPrologToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertCodeSnippet(snippets[Snippet.XML_Prolog], Language.XML);
        }

        private void linePrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using LinePrefixDialog dialog = new LinePrefixDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.Remove)
                {
                    CurrentTab.RemoveLinePrefix(dialog.Prefix);
                }
                else
                {
                    CurrentTab.InsertLinePrefix(dialog.Prefix);
                }
            }
        }

        private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTab.InsertText(DateTime.Now.ToString());
        }

        #endregion

        #region Tools

        private void autoSaveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CodeTabPage tabPage in AllTabs)
            {
                tabPage.AutoSave = autoSaveToolStripMenuItem.Checked;
            }
        }

        private void diffMergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToolNeedsInstantiating(DiffMerge))
            {
                DiffMerge = new DiffMergeForm();
            }

            ShowTool(DiffMerge);
        }

        private void htmlDocEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToolNeedsInstantiating(HtmlDocEdit))
            {
                HtmlDocEdit = new HtmlDocEditForm();
            }

            ShowTool(HtmlDocEdit);
        }

        private bool ToolNeedsInstantiating([NotNullWhen(false)] Form? tool)
        {
            return tool == null || tool.IsDisposed;
        }

        private void ShowTool(Form tool)
        {
            if (tool.Visible)
            {
                tool.MakeAppear();
            }
            else
            {
                tool.Show(this);
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
                File.Delete(settings.FilePath);
                ReadSettings();
                ReadRecentFiles();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        #endregion
    }
}