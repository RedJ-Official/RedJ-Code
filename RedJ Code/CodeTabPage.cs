using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    internal class CodeTabPage : TabPage 
    {
        private Form ParentForm => FindForm();

        private readonly FastColoredTextBox FastColoredTextBox;
        private readonly DocumentMap DocumentMap;
        private readonly Ruler Ruler;
        private readonly AutocompleteMenu AutocompleteMenu;
        
        private List<SnippetAutocompleteItem> AutocompleteItems;

        private readonly MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));
        
        public string? FilePath { get; private set; }
        public bool IsSaved { get; set; }
        
        public bool AutoSave { get; set; }

        public string SelectedText => FastColoredTextBox.SelectedText;
        public int SelectionLength => FastColoredTextBox.SelectionLength;

        public bool CanUndo => FastColoredTextBox.UndoEnabled;
        public bool CanRedo => FastColoredTextBox.RedoEnabled;
        public bool CanCutCopy => FastColoredTextBox.SelectionLength > 0;
        public bool CanPaste => Clipboard.ContainsText();
        public bool CanSelectAll => FastColoredTextBox.TextLength > 0;

        public Language Language
        {
            get { return FastColoredTextBox.Language; }
            set {
                FastColoredTextBox.Language = value;
                RefreshSyntaxHighlighting();
            }
        }
        public bool WordWrap
        {
            get { return FastColoredTextBox.WordWrap; }
            set { FastColoredTextBox.WordWrap = value; }
        }
        public bool WordWrapAutoIndent
        {
            get { return FastColoredTextBox.WordWrapAutoIndent; }
            set { 
                FastColoredTextBox.WordWrapAutoIndent = value;
                if (FastColoredTextBox.WordWrap)
                {
                    FastColoredTextBox.WordWrap = false;
                    FastColoredTextBox.WordWrap = true;
                }
            }
        }
        public bool ShowLineNumbers
        {
            get { return FastColoredTextBox.ShowLineNumbers; }
            set { FastColoredTextBox.ShowLineNumbers = value; }
        }
        public bool ShowFoldingLines
        {
            get { return FastColoredTextBox.ShowFoldingLines; }
            set { FastColoredTextBox.ShowFoldingLines = value; }
        }
        public bool ShowScrollBars
        {
            get { return FastColoredTextBox.ShowScrollBars; }
            set { FastColoredTextBox.ShowScrollBars = value; }
        }
        public bool CaretVisible
        {
            get { return FastColoredTextBox.CaretVisible; }
            set { FastColoredTextBox.CaretVisible = value; }
        }
        public bool CaretBlinking
        {
            get { return FastColoredTextBox.CaretBlinking; }
            set { 
                FastColoredTextBox.CaretBlinking = value;
                if (FastColoredTextBox.CaretVisible)
                {
                    FastColoredTextBox.CaretVisible = false;
                    FastColoredTextBox.Update();
                    FastColoredTextBox.CaretVisible = true;
                }
            }
        }
        public bool WideCaret
        {
            get { return FastColoredTextBox.WideCaret; }
            set { FastColoredTextBox.WideCaret = value; }
        }
        public bool ShowCaretWhenInactive
        {
            get { return FastColoredTextBox.ShowCaretWhenInactive; }
            set { FastColoredTextBox.ShowCaretWhenInactive = value; }
        }
        public bool AutoIndent
        {
            get { return FastColoredTextBox.AutoIndent; }
            set { FastColoredTextBox.AutoIndent = value; }
        }
        public bool AutoCompleteBrackets
        {
            get { return FastColoredTextBox.AutoCompleteBrackets; }
            set { FastColoredTextBox.AutoCompleteBrackets = value; }
        }
        public bool VirtualSpace
        {
            get { return FastColoredTextBox.VirtualSpace; }
            set { FastColoredTextBox.VirtualSpace = value; }
        }
        public bool HighlightCurrentLine
        {
            get { return FastColoredTextBox.CurrentLineColor != Color.Transparent; }
            set { FastColoredTextBox.CurrentLineColor = value ? Color.LightBlue : Color.Transparent; }
        }
        public bool HighlightCurrentWord
        {
            get;
            set;
        }
        public Font TextFont
        {
            get { return FastColoredTextBox.Font; }
            set { FastColoredTextBox.Font = value; }
        }
        public bool DocumentMapVisible
        {
            get { return DocumentMap.Visible; }
            set { DocumentMap.Visible = value; }
        }
        public bool RulerVisible
        {
            get { return Ruler.Visible; }
            set { Ruler.Visible = value; }
        }
        public bool AutocompleteMenuEnabled
        {
            get { return AutocompleteMenu.MenuEnabled; }
            set { AutocompleteMenu.MenuEnabled = value; }
        }

        public int CharCount => FastColoredTextBox.TextLength;
        public int LineCount => FastColoredTextBox.LinesCount;

        public int CurrentRow => FastColoredTextBox.Selection.Start.iLine;
        public int CurrentColumn => FastColoredTextBox.Selection.Start.iChar;

        public event EventHandler? CodeChanged;

        public CodeTabPage() : this(null)
        {
        }

        public CodeTabPage(string? filePath) : base()
        {
            FilePath = filePath;
            IsSaved  = true;

            FastColoredTextBox = new FastColoredTextBox(); 
            FastColoredTextBox.Dock = DockStyle.Fill;
            FastColoredTextBox.Hotkeys = StringTable.FastColoredTextBoxHotkeys;
            FastColoredTextBox.LeftPadding = 32;
            FastColoredTextBox.BookmarkColor = Color.Blue;
            FastColoredTextBox.Language = Language.PlainText;
            FastColoredTextBox.TextChanged += new EventHandler<TextChangedEventArgs>(fastColoredTextBox_TextChanged);
            FastColoredTextBox.SelectionChanged += new EventHandler(fastColoredTextBox_SelectionChanged);
            FastColoredTextBox.SelectionChangedDelayed += new EventHandler(fastColoredTextBox_SelectionChangedDelayed);
            
            DocumentMap = new DocumentMap();
            DocumentMap.Dock = DockStyle.Right;
            DocumentMap.Width = 200;
            DocumentMap.ForeColor = Color.Blue;
            DocumentMap.ScrollbarVisible = true;
            DocumentMap.Target = FastColoredTextBox;

            Ruler = new Ruler();
            Ruler.Dock = DockStyle.Top;
            Ruler.Target = FastColoredTextBox;

            AutocompleteMenu = new AutocompleteMenu(FastColoredTextBox);
            AutocompleteMenu.AutoClose = true;
            AutocompleteMenu.AllowTabKey = true;
            AutocompleteMenu.MinFragmentLength = 1;
            AutocompleteMenu.AppearInterval = 1000;
            AutocompleteMenu.SelectedColor = Color.CornflowerBlue;
            AutocompleteMenu.Font = FastColoredTextBox.Font;
            AutocompleteMenu.SearchPattern = @"[<?\w]"; 
            InitAutocompleteItems();
            AutocompleteMenu.Items.SetAutocompleteItems(AutocompleteItems);
            
            Controls.Add(FastColoredTextBox);
            Controls.Add(Ruler);
            Controls.Add(DocumentMap);

            RefreshSyntaxHighlighting();
            
            if (FilePath != null)
            {
                FastColoredTextBox.OpenFile(FilePath);
            }

            IsSaved = true;
            RefreshText();
        }

        private void InitAutocompleteItems()
        {
            AutocompleteItems = new()
            {
                NewAutocompleteItem("true"          , Language.CSharp, Language.JS),
                NewAutocompleteItem("false"         , Language.CSharp, Language.JS),
                NewAutocompleteItem("null"          , Language.CSharp, Language.JS),
                NewAutocompleteItem("undefined"     , Language.JS),
                NewAutocompleteItem("this"          , Language.CSharp, Language.JS),
                NewAutocompleteItem("base"          , Language.CSharp),

                NewAutocompleteItem("bool"          , Language.CSharp),
                NewAutocompleteItem("byte"          , Language.CSharp),
                NewAutocompleteItem("char"          , Language.CSharp),
                NewAutocompleteItem("decimal"       , Language.CSharp),
                NewAutocompleteItem("double"        , Language.CSharp),
                NewAutocompleteItem("float"         , Language.CSharp),
                NewAutocompleteItem("long"          , Language.CSharp),
                NewAutocompleteItem("object"        , Language.CSharp),
                NewAutocompleteItem("sbyte"         , Language.CSharp),
                NewAutocompleteItem("short"         , Language.CSharp),
                NewAutocompleteItem("string"        , Language.CSharp),
                NewAutocompleteItem("uint"          , Language.CSharp),
                NewAutocompleteItem("ulong"         , Language.CSharp),
                NewAutocompleteItem("ushort"        , Language.CSharp),
                NewAutocompleteItem("var"           , Language.CSharp, Language.JS),
                NewAutocompleteItem("let"           , Language.JS),
                NewAutocompleteItem("const"         , Language.JS),
                NewAutocompleteItem("function"      , "function ^()\n{\n\n}"                    , Language.JS),

                NewAutocompleteItem("if"            , "if (^)\n{\n\n}"                          , Language.CSharp, Language.JS),
                NewAutocompleteItem("if else"       , "if (^)\n{\n\n}\nelse\n{\n\n}"            , Language.CSharp, Language.JS),
                NewAutocompleteItem("else"          , "else\n{\n^\n}"                           , Language.CSharp, Language.JS),
                NewAutocompleteItem("else if"       , "else if (^)\n{\n\n}"                     , Language.CSharp, Language.JS),
                NewAutocompleteItem("for"           , "for (int i = 0; i < ^; i++)\n{\n\n}"     , Language.CSharp),
                NewAutocompleteItem("for"           , "for (let i = 0; i < ^; i++)\n{\n\n}"     , Language.JS),
                NewAutocompleteItem("for in"        , "for (const item in ^)\n{\n\n}"           , Language.JS),
                NewAutocompleteItem("for of"        , "for (const item of ^)\n{\n\n}"           , Language.JS),
                NewAutocompleteItem("foreach"       , "foreach (var item in ^)\n{\n\n}"         , Language.CSharp),
                NewAutocompleteItem("while"         , "while (^)\n{\n\n}"                       , Language.CSharp, Language.JS),
                NewAutocompleteItem("do while"      , "do\n{\n\n} while (^);"                   , Language.CSharp, Language.JS),
                NewAutocompleteItem("switch"        , "switch (^)\n{\ndefault:\nbreak;\n}"      , Language.CSharp, Language.JS),
                NewAutocompleteItem("try catch"     , "try\n{\n\n}\ncatch (^)\n{\n\n}"          , Language.CSharp, Language.JS),
                NewAutocompleteItem("try finally"   , "try\n{\n\n}\nfinally\n{\n\n}"            , Language.CSharp, Language.JS),
                NewAutocompleteItem("catch"         , "catch (^)\n{\n\n}"                       , Language.CSharp, Language.JS),
                NewAutocompleteItem("finally"       , "finally\n{\n^\n}"                        , Language.CSharp, Language.JS),

                NewAutocompleteItem("unsafe"        , "unsafe\n{\n^\n}"                         , Language.CSharp),
                NewAutocompleteItem("unchecked"     , "unchecked\n{\n^\n}"                      , Language.CSharp),
                NewAutocompleteItem("checked"       , "checked\n{\n^\n}"                        , Language.CSharp),

                NewAutocompleteItem("return "       , "return ^;"                               , Language.CSharp, Language.JS),
                NewAutocompleteItem("throw "        , "throw ^;"                                , Language.CSharp, Language.JS),
                NewAutocompleteItem("break"         , "break;"                                  , Language.CSharp, Language.JS),
                NewAutocompleteItem("continue"      , "continue;"                               , Language.CSharp, Language.JS),

                NewAutocompleteItem("<!-->"         , "<!-- ^ -->"                              , Language.HTML),
                NewAutocompleteItem("<!DOCTYPE>"    , "<!DOCTYPE html>"                         , Language.HTML),
                NewAutocompleteItem("<a>"           , "<a href=\"^\"></a>"                      , Language.HTML),
                NewAutocompleteItem("<abbr>"        , "<abbr title=\"^\"></abbr>"               , Language.HTML),
                NewAutocompleteItem("<acronym>"     , "<acronym title=\"^\"></acronym>"         , Language.HTML),
                NewAutocompleteItem("<applet>"      , "<applet>^</applet>"                      , Language.HTML),
                NewAutocompleteItem("<article>"     , "<article>^</article>"                    , Language.HTML),
                NewAutocompleteItem("<audio>"       , "<audio controls=\"controls\">\n<source src=\"^\" type=\"\" />\n</audio>", Language.HTML),
                NewAutocompleteItem("<b>"           , "<b>^</b>"                                , Language.HTML),
                NewAutocompleteItem("<big>"         , "<big>^</big>"                            , Language.HTML),
                NewAutocompleteItem("<blockquote>"  , "<blockquote>^</blockquote>"              , Language.HTML),
                NewAutocompleteItem("<body>"        , "<body>\n^\n</body>"                      , Language.HTML),
                NewAutocompleteItem("<br>"          , "<br />"                                  , Language.HTML),
                NewAutocompleteItem("<button>"      , "<button>^</button>"                      , Language.HTML),
                NewAutocompleteItem("<canvas>"      , "<canvas>^</canvas>"                      , Language.HTML),
                NewAutocompleteItem("<center>"      , "<center>^</center>"                      , Language.HTML),
                NewAutocompleteItem("<cite>"        , "<cite>^</cite>"                          , Language.HTML),
                NewAutocompleteItem("<code>"        , "<code>^</code>"                          , Language.HTML),
                NewAutocompleteItem("<col>"         , "<col>^</col>"                            , Language.HTML),
                NewAutocompleteItem("<colgroup>"    , "<colgroup>\n^\n</colgroup>"              , Language.HTML),
                NewAutocompleteItem("<dd>"          , "<dd>^</dd>"                              , Language.HTML),
                NewAutocompleteItem("<del>"         , "<del>^</del>"                            , Language.HTML),
                NewAutocompleteItem("<dfn>"         , "<dfn title=\"^\"></dfn>"                 , Language.HTML),
                NewAutocompleteItem("<dialog>"      , "<dialog>^</dialog>"                      , Language.HTML),
                NewAutocompleteItem("<dir>"         , "<dir>\n^\n</dir>"                        , Language.HTML),
                NewAutocompleteItem("<div>"         , "<div>\n^\n</div>"                        , Language.HTML),
                NewAutocompleteItem("<dl>"          , "<dl>^</dl>"                              , Language.HTML),
                NewAutocompleteItem("<dt>"          , "<dt>^</dt>"                              , Language.HTML),
                NewAutocompleteItem("<em>"          , "<em>^</em>"                              , Language.HTML),
                NewAutocompleteItem("<embed>"       , "<embed src=\"^\" type=\"\" />"           , Language.HTML),
                NewAutocompleteItem("<fieldset>"    , "<fieldset>\n^\n</fieldset>"              , Language.HTML),
                NewAutocompleteItem("<figure>"      , "<figure>\n<img src=\"^\" alt=\"\" />\n<figcaption></figcaption>\n</figure>", Language.HTML),
                NewAutocompleteItem("<figcaption>"  , "<figcaption>^</figcaption>"              , Language.HTML),
                NewAutocompleteItem("<form>"        , "<form>\n^\n</form>"                      , Language.HTML),
                NewAutocompleteItem("<font>"        , "<font ^></font>"                         , Language.HTML),
                NewAutocompleteItem("<footer>"      , "<footer>\n^\n</footer>"                  , Language.HTML),
                NewAutocompleteItem("<frame>"       , "<frame src=\"^\"></frame>"               , Language.HTML),
                NewAutocompleteItem("<frameset>"    , "<frameset>^</frameset>"                  , Language.HTML),
                NewAutocompleteItem("<h1>"          , "<h1>^</h1>"                              , Language.HTML),
                NewAutocompleteItem("<h2>"          , "<h1>^</h2>"                              , Language.HTML),
                NewAutocompleteItem("<h3>"          , "<h1>^</h3>"                              , Language.HTML),
                NewAutocompleteItem("<h4>"          , "<h1>^</h4>"                              , Language.HTML),
                NewAutocompleteItem("<h5>"          , "<h1>^</h5>"                              , Language.HTML),
                NewAutocompleteItem("<h6>"          , "<h1>^</h6>"                              , Language.HTML),
                NewAutocompleteItem("<head>"        , "<head>\n^\n</head>"                      , Language.HTML),
                NewAutocompleteItem("<header>"      , "<header>\n^\n</header>"                  , Language.HTML),
                NewAutocompleteItem("<hgroup>"      , "<hgroup>\n^\n</hgroup>"                  , Language.HTML),
                NewAutocompleteItem("<hr>"          , "<hr />"                                  , Language.HTML),
                NewAutocompleteItem("<html>"        , "<html>\n^\n</html>"                      , Language.HTML),
                NewAutocompleteItem("<i>"           , "<i>^</i>"                                , Language.HTML),
                NewAutocompleteItem("<iframe>"      , "<iframe src=\"^\"></iframe>"             , Language.HTML),
                NewAutocompleteItem("<img>"         , "<img src=\"^\" alt=\"\" />"              , Language.HTML),
                NewAutocompleteItem("<ins>"         , "<ins>^</ins>"                            , Language.HTML),
                NewAutocompleteItem("<input>"       , "<input type=\"^\" />"                    , Language.HTML),
                NewAutocompleteItem("<kbd>"         , "<kbd>^</kbd>"                            , Language.HTML),
                NewAutocompleteItem("<label>"       , "<label for=\"^\"></label>"               , Language.HTML),
                NewAutocompleteItem("<legend>"      , "<legend>^</legend>"                      , Language.HTML),
                NewAutocompleteItem("<li>"          , "<li>^</li>"                              , Language.HTML),
                NewAutocompleteItem("<link>"        , "<link href=\"^\" rel=\"\" type=\"\">"    , Language.HTML),
                NewAutocompleteItem("<main>"        , "<main>\n^\n</main>"                      , Language.HTML),
                NewAutocompleteItem("<mark>"        , "<mark>^</mark>"                          , Language.HTML),
                NewAutocompleteItem("<marquee>"     , "<marquee>^</marquee>"                    , Language.HTML),
                NewAutocompleteItem("<menu>"        , "<menu>\n^\n</menu>"                      , Language.HTML),
                NewAutocompleteItem("<meta>"        , "<meta ^ />"                              , Language.HTML),
                NewAutocompleteItem("<meter>"       , "<meter value=\"^\" min=\"\" max=\"\" low=\"\" optimum=\"\" high=\"\"></meter>", Language.HTML),
                NewAutocompleteItem("<nav>"         , "<nav>\n^\n</nav>"                        , Language.HTML),
                NewAutocompleteItem("<nobr>"        , "<nobr>^</nobr>"                          , Language.HTML),
                NewAutocompleteItem("<noembed>"     , "<noémbed>^</noembed>"                    , Language.HTML),
                NewAutocompleteItem("<noframes>"    , "<noframes>^</noframes>"                  , Language.HTML),
                NewAutocompleteItem("<noscript>"    , "<noscript>^</noscript>"                  , Language.HTML),
                NewAutocompleteItem("<object>"      , "<object>^</object>"                      , Language.HTML),
                NewAutocompleteItem("<ol>"          , "<ol>\n^\n</ol>"                          , Language.HTML),
                NewAutocompleteItem("<optgroup>"    , "<optgroup label=\"^\"></optgroup>"       , Language.HTML),
                NewAutocompleteItem("<option>"      , "<option value=\"^\"></option>"           , Language.HTML),
                NewAutocompleteItem("<output>"      , "<output for=\"^\"></output>"             , Language.HTML),
                NewAutocompleteItem("<p>"           , "<p>^</p>"                                , Language.HTML),
                NewAutocompleteItem("<param>"       , "<param name=\"^\" value=\"\" />"         , Language.HTML),
                NewAutocompleteItem("<picture>"     , "<picture>\n<source srcset=\"^\" media=\"\" />\n<img src=\"\" alt=\"\" />\n</picture>", Language.HTML),
                NewAutocompleteItem("<plaintext>"   , "<plaintext>\n^"                          , Language.HTML),
                NewAutocompleteItem("<pre>"         , "<pre>^</pre>"                            , Language.HTML),
                NewAutocompleteItem("<progress>"    , "<progress value=\"^\" max=\"\"></progress>", Language.HTML),
                NewAutocompleteItem("<q>"           , "<q cite=\"^\"></q>"                      , Language.HTML),
                NewAutocompleteItem("<s>"           , "<s>^</s>"                                , Language.HTML),
                NewAutocompleteItem("<script>"      , "<script>^</script>"                      , Language.HTML),
                NewAutocompleteItem("<select>"      , "<select>\n^\n</select>"                  , Language.HTML),
                NewAutocompleteItem("<source>"      , "<source src=\"^\" type=\"\" />"          , Language.HTML),
                NewAutocompleteItem("<span>"        , "<span>^</span>"                          , Language.HTML),
                NewAutocompleteItem("<strike>"      , "<strike>^</strike>"                      , Language.HTML),
                NewAutocompleteItem("<strong>"      , "<strong>^</strong>"                      , Language.HTML),
                NewAutocompleteItem("<style>"       , "<style>^</style>"                        , Language.HTML),
                NewAutocompleteItem("<sub>"         , "<sub>^</sub>"                            , Language.HTML),
                NewAutocompleteItem("<sup>"         , "<sup>^</sup>"                            , Language.HTML),
                NewAutocompleteItem("<svg>"         , "<svg>^</svg>"                            , Language.HTML),
                NewAutocompleteItem("<table>"       , "<table>\n^\n</table>"                    , Language.HTML),
                NewAutocompleteItem("<tbody>"       , "<tbody>\n^\n</tbody>"                    , Language.HTML),
                NewAutocompleteItem("<td>"          , "<td>^</td>"                              , Language.HTML),
                NewAutocompleteItem("<textarea>"    , "<textarea>^</textarea>"                  , Language.HTML),
                NewAutocompleteItem("<tfoot>"       , "<tfoot>\n^\n</tfoot>"                    , Language.HTML),
                NewAutocompleteItem("<th>"          , "<th>^</th>"                              , Language.HTML),
                NewAutocompleteItem("<thead>"       , "<thead>\n^\n</thead>"                    , Language.HTML),
                NewAutocompleteItem("<title>"       , "<title>^</title>"                        , Language.HTML),
                NewAutocompleteItem("<tr>"          , "<tr>^</tr>"                              , Language.HTML),
                NewAutocompleteItem("<tt>"          , "<tt>^</tt>"                              , Language.HTML),
                NewAutocompleteItem("<u>"           , "<u>^</u>"                                , Language.HTML),
                NewAutocompleteItem("<ul>"          , "<ul>\n^\n</ul>"                          , Language.HTML),
                NewAutocompleteItem("<var>"         , "<var>^</var>"                            , Language.HTML),
                NewAutocompleteItem("<viedo>"       , "<video controls=\"controls\">\n<source src=\"^\" type=\"\" />\n</video>", Language.HTML),
                
            };
        }

        private SnippetAutocompleteItem NewAutocompleteItem(string name, string snippet, params Language[] languages) => new SnippetAutocompleteItem(FastColoredTextBox, name, snippet, languages);
        private SnippetAutocompleteItem NewAutocompleteItem(string snippet, params Language[] languages) => NewAutocompleteItem(snippet, snippet, languages);

        protected virtual void OnCodeChanged()
        {
            CodeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void fastColoredTextBox_TextChanged(object? sender, TextChangedEventArgs e)
        {
            IsSaved = false;
            RefreshText();
            OnCodeChanged();
            if (AutoSave && FilePath != null)
            {
                Save();
            }
        }

        private void fastColoredTextBox_SelectionChangedDelayed(object? sender, EventArgs e)
        {
            FastColoredTextBox./*Visible*/Range.ClearStyle(SameWordsStyle);

            if (!HighlightCurrentWord || !FastColoredTextBox.Selection.IsEmpty)
            {
                return; //user selected diapason
            }

            //get fragment around caret
            var fragment = FastColoredTextBox.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
            {
                return;
            }

            //highlight same words
            var ranges = FastColoredTextBox./*Visible*/Range.GetRanges($@"\b{text}\b").ToArray();
            foreach (var r in ranges)
            {
                r.SetStyle(SameWordsStyle);
            }
        }

        private void fastColoredTextBox_SelectionChanged(object? sender, EventArgs e)
        {
            OnCodeChanged();
        }

        public void SetContextMenu(ContextMenuStrip contextMenu)
        {
            FastColoredTextBox.ContextMenuStrip = contextMenu;
        }

        public void SetAutocompleteMenuImageList(ImageList imageList)
        {
            AutocompleteMenu.ImageList = imageList;
        }

        private void RefreshText()
        {
            string text = Path.GetFileName(FilePath) ?? "new";
            if (!IsSaved)
            {
                text += "*";
            }
            if (!Equals(text, Text))
            {
                Text = text;
            }
        }

        public void FocusOnTextBox()
        {
            FastColoredTextBox.Select();
            FastColoredTextBox.Focus();
        }

        public void RefreshSyntaxHighlighting()
        {
            FastColoredTextBox.Range.ClearStyle(StyleIndex.All);
            FastColoredTextBox.SyntaxHighlighter.HighlightSyntax(FastColoredTextBox.Language, FastColoredTextBox.Range);
        }

        public void AutoDetectLanguage()
        {
            Language = DoAutoDetectLanguage();
        }

        private Language DoAutoDetectLanguage()
        {
            string? line1 = FastColoredTextBox.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).FirstOrDefault()?.Trim();

            if (line1 == null)
            {
                MessageBox.Show(ParentForm, StringTable.FailedToAutoDetectMessageBoxText, ParentForm.Text);
                return Language.PlainText;
            }

            if (line1.StartsWith("<!"))
            {
                return Language.HTML;
            }
            else if (line1.StartsWith("<?"))
            {
                return Language.XML;
            }
            else if (line1.StartsWith("using") || line1.StartsWith("namespace") || line1.Contains("class") || line1.StartsWith("#region"))
            {
                return Language.CSharp;
            }
            else if (line1.StartsWith("Imports") || line1.Contains("Class"))
            {
                return Language.VB;
            }
            else if (line1.StartsWith("use", StringComparison.InvariantCultureIgnoreCase))
            {
                return Language.SQL;
            }
            else if (line1.StartsWith("{"))
            {
                return Language.JSON;
            }
            else
            {
                MessageBox.Show(ParentForm, StringTable.FailedToAutoDetectMessageBoxText, ParentForm.Text);
                return Language.PlainText;
            }
        }

        public bool Save()
        {
            if (FilePath == null)
            {
                return SaveAs();
            }
            else
            {
                FastColoredTextBox.SaveToFile(FilePath, Encoding.UTF8);
                IsSaved = true;
                RefreshText();
                return true;
            }
        }

        public bool SaveAs()
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = StringTable.SaveFileDialogTitle;
            saveFileDialog.Filter = StringTable.SaveFileDialogFilter;
            saveFileDialog.FilterIndex = Util.GetFilterIndexFromLangauge(FastColoredTextBox.Language);
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                FilePath = saveFileDialog.FileName;
                FastColoredTextBox.SaveToFile(FilePath, Encoding.UTF8);
                IsSaved = true;
                RefreshText();
                return true;
            }
            return false;
        }

        public void Export()
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = StringTable.ExportFileDialogTitle;
            saveFileDialog.Filter = StringTable.ExportFileDialogFilter;
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        File.WriteAllText(saveFileDialog.FileName, FastColoredTextBox.Rtf);
                        break;
                    case 2:
                        File.WriteAllText(saveFileDialog.FileName, FastColoredTextBox.Html);
                        break;
                }
            }
        }

        public void Reload()
        {
            if (FilePath != null)
            {
                FastColoredTextBox.OpenFile(FilePath);
                IsSaved = true;
                RefreshText();
            }
        }

        public void Print()
        {
            PrintDialogSettings settings = new PrintDialogSettings();
            settings.ShowPrintDialog = true;
            settings.ShowPrintPreviewDialog = false;
            settings.ShowPageSetupDialog = false;
            FastColoredTextBox.Print(settings);
        }

        public void PrintPreview()
        {
            PrintDialogSettings settings = new PrintDialogSettings();
            settings.ShowPrintDialog = false;
            settings.ShowPrintPreviewDialog = true;
            settings.ShowPageSetupDialog = false;
            FastColoredTextBox.Print(settings);
        }

        public void PageSetup()
        {
            PrintDialogSettings settings = new PrintDialogSettings();
            settings.ShowPrintDialog = false;
            settings.ShowPrintPreviewDialog = false;
            settings.ShowPageSetupDialog = true;
            FastColoredTextBox.Print(settings);
        }

        public void PrintRTF()
        {
            RichTextPrinter.PrintRTF(FastColoredTextBox.Rtf);
        }

        public void PageSetupRTF()
        {
            
        }

        public void ShowProperties()
        {
            if (FilePath != null)
            {
                ShellProperties.ShowPropertiesDialog(FilePath);
            }
        }

        public void ShowInFileExplorer()
        {
            Util.StartProcess("explorer.exe", $"/select, \"{FilePath}\"");
        }

        public void CopyFilePath()
        {
            if (FilePath != null)
            {
                Clipboard.SetText(FilePath);
            }
        }

        public void Undo()
        {
            FastColoredTextBox.Undo();
        }

        public void Redo()
        {
            FastColoredTextBox.Redo();
        }

        public void Cut()
        {
            FastColoredTextBox.Cut();
        }

        public void Copy()
        {
            FastColoredTextBox.Copy();
        }

        public void Paste()
        {
            FastColoredTextBox.Paste();
        }

        public void SelectAll()
        {
            FastColoredTextBox.SelectAll();
        }

        public void ShowFindDialog()
        {
            FastColoredTextBox.ShowFindDialog();

            if (FastColoredTextBox.findForm != null)
            {
                FastColoredTextBox.findForm.MinimizeBox = false;
                FastColoredTextBox.findForm.MaximizeBox = false;
                FastColoredTextBox.findForm.TopMost = false;
                FastColoredTextBox.findForm.Owner = FastColoredTextBox.ParentForm;
                FastColoredTextBox.findForm.Text = "Find";
                FastColoredTextBox.findForm.Controls["label1"].Text = "F&ind:";
                FastColoredTextBox.findForm.Controls["cbMatchCase"].Text = "Match &Case";
                FastColoredTextBox.findForm.Controls["cbWholeWord"].Text = "Match &Whole Word";
                FastColoredTextBox.findForm.Controls["cbRegex"].Text = "Reg&Ex";
                FastColoredTextBox.findForm.Controls["btFindNext"].Text = "&Find Next";
                FastColoredTextBox.findForm.Controls["btClose"].Text = "Cancel";
            }
        }

        public void ShowReplaceDialog()
        {
            FastColoredTextBox.ShowReplaceDialog();

            if (FastColoredTextBox.replaceForm != null)
            {
                FastColoredTextBox.replaceForm.MinimizeBox = false;
                FastColoredTextBox.replaceForm.MaximizeBox = false;
                FastColoredTextBox.replaceForm.TopMost = false;
                FastColoredTextBox.replaceForm.Owner = FastColoredTextBox.ParentForm;
                FastColoredTextBox.replaceForm.Text = "Find and Replace";
                FastColoredTextBox.replaceForm.Controls["label1"].Text = "F&ind:";
                FastColoredTextBox.replaceForm.Controls["label2"].Text = "Re&place:";
                FastColoredTextBox.replaceForm.Controls["cbMatchCase"].Text = "Match &Case";
                FastColoredTextBox.replaceForm.Controls["cbWholeWord"].Text = "Match &Whole Word";
                FastColoredTextBox.replaceForm.Controls["cbRegex"].Text = "Reg&Ex";
                FastColoredTextBox.replaceForm.Controls["btFindNext"].Text = "&Find Next";
                FastColoredTextBox.replaceForm.Controls["btReplace"].Text = "&Replace";
                FastColoredTextBox.replaceForm.Controls["btReplaceAll"].Text = "Replace &All";
                FastColoredTextBox.replaceForm.Controls["btClose"].Text = "Cancel";
            }
        }

        public void ShowGoToDialog()
        {
            FastColoredTextBox.ShowGoToDialog();
        }

        public void IncreaseIndent()
        {
            FastColoredTextBox.IncreaseIndent();
        }

        public void DecreaseIndent()
        {
            FastColoredTextBox.DecreaseIndent();
        }

        public void DoAutoIndent()
        {
            FastColoredTextBox.DoAutoIndent();
        }

        public void CommentSelected()
        {
            FastColoredTextBox.CommentSelected();
        }

        public void InsertCommentPrefix()
        {
            if (FastColoredTextBox.Language == Language.HTML || FastColoredTextBox.Language == Language.XML)
            {
                InsertAndSelectText($"<!-- {FastColoredTextBox.SelectedText} -->");
            }
            else if (FastColoredTextBox.CommentPrefix != null)
            {
                FastColoredTextBox.InsertLinePrefix(FastColoredTextBox.CommentPrefix);
            }
        }

        public void RemoveCommentPrefix()
        {
            if (FastColoredTextBox.Language == Language.HTML || FastColoredTextBox.Language == Language.XML)
            {
                InsertAndSelectText(FastColoredTextBox.SelectedText.TrimStart("<!--").TrimEnd("-->").Trim());
            }
            else if (FastColoredTextBox.CommentPrefix != null)
            {
                FastColoredTextBox.RemoveLinePrefix(FastColoredTextBox.CommentPrefix);
            }
        }

        private void InsertAndSelectText(string text)
        {
            FastColoredTextBox.InsertText(text);
            FastColoredTextBox.SelectionStart -= text.Length;
            FastColoredTextBox.SelectionLength = text.Length;
        }

        public void MoveSelectedLinesUp()
        {
            FastColoredTextBox.MoveSelectedLinesUp();
        }

        public void MoveSelectedLinesDown()
        {
            FastColoredTextBox.MoveSelectedLinesDown();
        }

        public void AutoFormatSelection()
        {
            switch (FastColoredTextBox.Language)
            {
                case Language.JSON:
                    if (FastColoredTextBox.SelectionLength > 0)
                    {
                        FastColoredTextBox.SelectedText = CodeFormatter.FormatJSON(FastColoredTextBox.SelectedText);
                    }
                    break;
                default:
                    MessageBox.Show(ParentForm, StringTable.FailedToAutoFormatMessageBoxText);
                    break;
            }
        }

        public void ShowAutocompleteMenu()
        {
            AutocompleteMenu.Show(true);
        }

        public void Expand()
        {
            if (FastColoredTextBox.StartFoldingLine != -1)
            {
                FastColoredTextBox.ExpandFoldedBlock(FastColoredTextBox.StartFoldingLine);
            }
        }

        public void Collapse()
        {
            if (FastColoredTextBox.StartFoldingLine != -1)
            {
                FastColoredTextBox.CollapseFoldingBlock(FastColoredTextBox.StartFoldingLine);
            }
        }

        public void ExpandSelection()
        {
            FastColoredTextBox.ExpandBlock(FastColoredTextBox.Selection.FromLine, FastColoredTextBox.Selection.ToLine);
        }

        public void CollapseSelection()
        {
            FastColoredTextBox.CollapseBlock(FastColoredTextBox.Selection.FromLine, FastColoredTextBox.Selection.ToLine);
        }

        public void ExpandAll()
        {
            FastColoredTextBox.ExpandAllFoldingBlocks();
        }

        public void CollapseAll()
        {
            FastColoredTextBox.CollapseAllFoldingBlocks();
        }

        public void UpperCase()
        {
            FastColoredTextBox.UpperCase();
        }

        public void LowerCase()
        {
            FastColoredTextBox.LowerCase();
        }

        public void TitleCase()
        {
            FastColoredTextBox.TitleCase();
        }

        public void SentenceCase()
        {
            FastColoredTextBox.SentenceCase();
        }

        public void BookmarkLine()
        {
            FastColoredTextBox.BookmarkLine(FastColoredTextBox.Selection.FromLine);
        }

        public void UnbookmarkLine()
        {
            FastColoredTextBox.UnbookmarkLine(FastColoredTextBox.Selection.FromLine);
        }

        public void ToggleBookmark()
        {
            int line = FastColoredTextBox.Selection.FromLine;

            if (FastColoredTextBox.Bookmarks.Contains(line))
            {
                FastColoredTextBox.UnbookmarkLine(line);
            }
            else
            {
                FastColoredTextBox.BookmarkLine(line);
            }
        }

        public void ClearBookmarks()
        {
            FastColoredTextBox.Bookmarks.Clear();

            Refresh();
        }

        public void NextBookmark()
        {
            FastColoredTextBox.GotoNextBookmark(FastColoredTextBox.Selection.FromLine);
        }

        public void PreviousBookmark()
        {
            FastColoredTextBox.GotoPrevBookmark(FastColoredTextBox.Selection.FromLine);
        }

        public void InsertText(string text)
        {
            FastColoredTextBox.InsertText(text);
        }

        public void InsertLinePrefix(string prefix)
        {
            FastColoredTextBox.InsertLinePrefix(prefix);
        }

        public void RemoveLinePrefix(string prefix)
        {
            FastColoredTextBox.RemoveLinePrefix(prefix);
        }

        public void InsertXmlTag(bool noClosingTag)
        {
            string tagName;

            if (FastColoredTextBox.SelectionLength == 0)
            {
                tagName = FastColoredTextBox.Selection.GetFragment(@"\w").Text;

                for (int i = 0; i < tagName.Length; i++)
                    FastColoredTextBox.Selection.GoLeft(true);

                FastColoredTextBox.ClearSelected();
                //FastColoredTextBox.InsertText(new string(Enumerable.Repeat('\b', tagName.Length).ToArray()));
            }
            else
            {
                tagName = FastColoredTextBox.SelectedText;
            }

            if (string.IsNullOrWhiteSpace(tagName))
            {
                return;
            }

            if (noClosingTag)
            {
                FastColoredTextBox.InsertText($"<{tagName} />");
            }
            else
            {
                FastColoredTextBox.InsertText($"<{tagName}></{tagName}>");
                FastColoredTextBox.SelectionStart -= tagName.Length + 3;
            }
        }

        public void InsertCodeSnippet(string snippet, Language lang)
        {
            if (FastColoredTextBox.Language == Language.PlainText)
            {
                Language = lang;
            }
            var p1 = FastColoredTextBox.Selection.Start;
            FastColoredTextBox.InsertText(snippet);
            var p2 = FastColoredTextBox.Selection.Start;
            for (int iLine = p1.iLine + 1; iLine <= p2.iLine; iLine++)
            {
                FastColoredTextBox.Selection.Start = new Place(0, iLine);
                FastColoredTextBox.DoAutoIndent(iLine);
            }
            FastColoredTextBox.Selection.Start = p1;
        }

        public void StartRecoringMacro()
        {
            FastColoredTextBox.MacrosManager.IsRecording = true;
        }

        public void StopRecoringMacro()
        {
            FastColoredTextBox.MacrosManager.IsRecording = false;
        }
    }

    internal enum Snippet
    {
        CSharp_Main         =  0,
        CSharp_ToString     =  1,
        CSharp_Equals       =  2,
        CSharp_GetHashCode  =  3,

        VB_Main             = 10,
        VB_ToString         = 11,
        VB_Equals           = 12,
        VB_GetHashCode      = 13,

        HTML_Document       = 20,
        HTML_Doctype        = 21,
        HTML_Doctype401     = 22,
        HTML_Doctype32      = 23,
        HTML_Doctype2       = 24,
        HTML_XUACompatible  = 25,

        XML_Prolog          = 30,
    }
}
