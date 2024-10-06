using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    internal class CodeTabPage : TabPage 
    {
        private MainForm ParentForm => FindForm() as MainForm;

        private readonly FastColoredTextBox FastColoredTextBox;
        private readonly DocumentMap DocumentMap;
        private readonly Ruler Ruler;
        private readonly AutocompleteMenu AutocompleteMenu;
        
        private List<SnippetAutocompleteItem> AutocompleteItems;

        private readonly MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));
        private readonly InvisibleCharsStyle InvisCharStyle = new InvisibleCharsStyle(Pens.LightGray);

        public string? FilePath { get; private set; }
        public bool IsSaved { get; set; }
        //public bool IsSaved => !FastColoredTextBox.IsChanged;
        
        public bool AutoSave { get; set; }

        public string SelectedText => FastColoredTextBox.SelectedText;
        public int SelectionLength => FastColoredTextBox.SelectionLength;

        public bool CanUndo => FastColoredTextBox.UndoEnabled;
        public bool CanRedo => FastColoredTextBox.RedoEnabled;
        public bool CanCutCopy => FastColoredTextBox.SelectionLength > 0;
        public bool CanPaste => Clipboard.ContainsText();
        public bool CanSelectAll => FastColoredTextBox.TextLength > 0;

        public Encoding Encoding { get; private set; }
        public bool ReadOnly { get; }

        public Language Language
        {
            get { return FastColoredTextBox.Language; }
            set {
                FastColoredTextBox.Language = value;
                RefreshSyntaxHighlighting();
                if (ParentForm is MainForm mf)
                    mf.RefreshLanguage();
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
        public bool AllowDragDrop
        {
            get { return FastColoredTextBox.AllowDrop; }
            set { FastColoredTextBox.AllowDrop = value; }
        }
        public bool HighlightFoldingIndicator
        {
            get { return FastColoredTextBox.HighlightFoldingIndicator; }
            set { FastColoredTextBox.HighlightFoldingIndicator = value; }
        }
        private bool _highlightCurrentLine;
        public bool HighlightCurrentLine
        {
            //get { return FastColoredTextBox.CurrentLineColor != Color.Transparent; }
            //set { FastColoredTextBox.CurrentLineColor = value ? Color.LightBlue : Color.Transparent; }
            get { return _highlightCurrentLine; }
            set
            {
                _highlightCurrentLine = value;
                FastColoredTextBox.CurrentLineColor = _highlightCurrentLine ? _currentLineColor : Color.Transparent;
            }
        }
        private bool _highlightCurrentWord;
        public bool HighlightCurrentWord
        {
            get => _highlightCurrentWord;
            set {
                if (value) DoHighlightCurrentWord();
                else FastColoredTextBox.Range.ClearStyle(SameWordsStyle);
                _highlightCurrentWord = value;
            }
        }
        private bool _showInvisibleChars;
        public bool ShowInvisibleChars
        {
            get => _showInvisibleChars;
            set
            {
                _showInvisibleChars = value;
                RefreshInvisibleCharsHighlight();
            }
        }
        public Color LineNumberColor
        {
            get => FastColoredTextBox.LineNumberColor;
            set => FastColoredTextBox.LineNumberColor = value;
        }
        public Color BookmarkColor
        {
            get => FastColoredTextBox.BookmarkColor;
            set => FastColoredTextBox.BookmarkColor = value;
        }
        public Color FoldingIndicatorColor
        {
            get => FastColoredTextBox.FoldingIndicatorColor;
            set => FastColoredTextBox.FoldingIndicatorColor = value;
        }
        private Color _currentLineColor = Color.Transparent;
        public Color CurrentLineColor
        {
            get { 
                return _currentLineColor;
            }
            set {
                _currentLineColor = value;
                FastColoredTextBox.CurrentLineColor = _highlightCurrentLine ? _currentLineColor : Color.Transparent;
            }
        }
        public Color DocumentMapColor
        {
            get => DocumentMap.ForeColor;
            set => DocumentMap.ForeColor = value;
        }
        public Color AutocompleteMenuColor
        {
            get => AutocompleteMenu.SelectedColor;
            set => AutocompleteMenu.SelectedColor = value;
        }
        public Color BackgroundColor
        {
            get => FastColoredTextBox.BackColor;
            set => FastColoredTextBox.BackColor = value;
        }
        public Color SelectionColor
        {
            get => FastColoredTextBox.SelectionColor;
            set => FastColoredTextBox.SelectionColor = value;
        }
        public int Zoom
        {
            get { return FastColoredTextBox.Zoom; }
            set { if (FastColoredTextBox.Zoom != value) FastColoredTextBox.Zoom = value; }
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
        public event EventHandler? ZoomChanged;

        public CodeTabPage(string? filePath = null, bool readOnly = false) : base()
        {
            Encoding = new UTF8Encoding(false);
            FilePath = filePath;
            ReadOnly = readOnly;
            IsSaved  = true;
            
            FastColoredTextBox = new FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Hotkeys = StringTable.FastColoredTextBoxHotkeys,
                LeftPadding = 32,
                BookmarkColor = Color.Blue,
                DelayedEventsInterval = 200,
                DelayedTextChangedInterval = 1000,
                Language = Language.PlainText,
                HighlightingRangeType = HighlightingRangeType.VisibleRange,
                ReadOnly = ReadOnly
            };
            FastColoredTextBox.TextChanged += FastColoredTextBox_TextChanged;
            FastColoredTextBox.TextChangedDelayed += FastColoredTextBox_TextChangedDelayed;
            //FastColoredTextBox.SelectionChanged += FastColoredTextBox_SelectionChanged;
            FastColoredTextBox.SelectionChangedDelayed += FastColoredTextBox_SelectionChangedDelayed;
            FastColoredTextBox.VisibleRangeChangedDelayed += FastColoredTextBox_VisibleRangeChangedDelayed;
            FastColoredTextBox.ZoomChanged += FastColoredTextBox_ZoomChanged;
            FastColoredTextBox.CustomAction += FastColoredTextBox_CustomAction;

            DocumentMap = new DocumentMap
            {
                Dock = DockStyle.Right,
                Width = 200,
                ForeColor = Color.Blue,
                ScrollbarVisible = true,
                Target = FastColoredTextBox
            };

            Ruler = new Ruler
            {
                Dock = DockStyle.Top,
                Target = FastColoredTextBox
            };

            AutocompleteMenu = new AutocompleteMenu(FastColoredTextBox)
            {
                AutoClose = true,
                AllowTabKey = true,
                MinFragmentLength = 1,
                AppearInterval = 1000,
                SelectedColor = Color.CornflowerBlue,
                Font = FastColoredTextBox.Font,
                SearchPattern = @"<?\w+"
            };
            InitAutocompleteItems();
            AutocompleteMenu.Items.SetAutocompleteItems(AutocompleteItems);

            Resize += CodeTabPage_Resize;
            
            Controls.Add(FastColoredTextBox);
            Controls.Add(Ruler);
            Controls.Add(DocumentMap);

            RefreshSyntaxHighlighting();

            Open();

            RefreshText();
        }

        [MemberNotNull(nameof(AutocompleteItems))]
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
                NewAutocompleteItem("const"         , Language.CSharp, Language.JS),
                NewAutocompleteItem("let"           , Language.JS),
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
                NewAutocompleteItem("yield return"  , "yield return ^;"                         , Language.CSharp),
                NewAutocompleteItem("yield break"   , "yield break;"                            , Language.CSharp),

                NewAutocompleteItem("nameof"        , "nameof(^)"                               , Language.CSharp),
                NewAutocompleteItem("typeof"        , "typeof(^)"                               , Language.CSharp),
                NewAutocompleteItem("sizeof"        , "sizeof(^)"                               , Language.CSharp),

                NewAutocompleteItem("abstract"      , Language.CSharp),
                NewAutocompleteItem("as"            , Language.CSharp),
                NewAutocompleteItem("async"         , Language.CSharp),
                NewAutocompleteItem("await"         , Language.CSharp),
                NewAutocompleteItem("case"          , Language.CSharp),
                NewAutocompleteItem("class"         , Language.CSharp),
                NewAutocompleteItem("default"       , Language.CSharp),
                NewAutocompleteItem("delegate"      , Language.CSharp),
                NewAutocompleteItem("dynamic"       , Language.CSharp),
                NewAutocompleteItem("enum"          , Language.CSharp),
                NewAutocompleteItem("event"         , Language.CSharp),
                NewAutocompleteItem("explicit"      , Language.CSharp),
                NewAutocompleteItem("extern"        , Language.CSharp),
                NewAutocompleteItem("global"        , Language.CSharp),
                NewAutocompleteItem("goto"          , Language.CSharp),
                NewAutocompleteItem("implicit"      , Language.CSharp),
                NewAutocompleteItem("interface"     , Language.CSharp),
                NewAutocompleteItem("internal"      , Language.CSharp),
                NewAutocompleteItem("in"            , Language.CSharp),
                NewAutocompleteItem("is"            , Language.CSharp),
                NewAutocompleteItem("namespace"     , Language.CSharp),
                NewAutocompleteItem("new"           , Language.CSharp),
                NewAutocompleteItem("operator"      , Language.CSharp),
                NewAutocompleteItem("out"           , Language.CSharp),
                NewAutocompleteItem("params"        , Language.CSharp),
                NewAutocompleteItem("private"       , Language.CSharp),
                NewAutocompleteItem("protected"     , Language.CSharp),
                NewAutocompleteItem("public"        , Language.CSharp),
                NewAutocompleteItem("readonly"      , Language.CSharp),
                NewAutocompleteItem("ref"           , Language.CSharp),
                NewAutocompleteItem("ref struct"    , Language.CSharp),
                NewAutocompleteItem("struct"        , Language.CSharp),
                NewAutocompleteItem("using"         , Language.CSharp),
                NewAutocompleteItem("virtual"       , Language.CSharp),
                NewAutocompleteItem("void"          , Language.CSharp),
                NewAutocompleteItem("volatile"      , Language.CSharp),

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
                NewAutocompleteItem("<br>"          , "<br>"                                    , Language.HTML),
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
                NewAutocompleteItem("<embed>"       , "<embed src=\"^\" type=\"\">"             , Language.HTML),
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
                NewAutocompleteItem("<hr>"          , "<hr>"                                    , Language.HTML),
                NewAutocompleteItem("<html>"        , "<html>\n^\n</html>"                      , Language.HTML),
                NewAutocompleteItem("<i>"           , "<i>^</i>"                                , Language.HTML),
                NewAutocompleteItem("<iframe>"      , "<iframe src=\"^\"></iframe>"             , Language.HTML),
                NewAutocompleteItem("<img>"         , "<img src=\"^\" alt=\"\" />"              , Language.HTML),
                NewAutocompleteItem("<ins>"         , "<ins>^</ins>"                            , Language.HTML),
                NewAutocompleteItem("<input>"       , "<input type=\"^\">"                      , Language.HTML),
                NewAutocompleteItem("<kbd>"         , "<kbd>^</kbd>"                            , Language.HTML),
                NewAutocompleteItem("<label>"       , "<label for=\"^\"></label>"               , Language.HTML),
                NewAutocompleteItem("<legend>"      , "<legend>^</legend>"                      , Language.HTML),
                NewAutocompleteItem("<li>"          , "<li>^</li>"                              , Language.HTML),
                NewAutocompleteItem("<link>"        , "<link href=\"^\" rel=\"\" type=\"\">"    , Language.HTML),
                NewAutocompleteItem("<main>"        , "<main>\n^\n</main>"                      , Language.HTML),
                NewAutocompleteItem("<mark>"        , "<mark>^</mark>"                          , Language.HTML),
                NewAutocompleteItem("<marquee>"     , "<marquee>^</marquee>"                    , Language.HTML),
                NewAutocompleteItem("<menu>"        , "<menu>\n^\n</menu>"                      , Language.HTML),
                NewAutocompleteItem("<meta>"        , "<meta ^>"                                , Language.HTML),
                NewAutocompleteItem("<meter>"       , "<meter value=\"^\" min=\"\" max=\"\" low=\"\" optimum=\"\" high=\"\"></meter>", Language.HTML),
                NewAutocompleteItem("<nav>"         , "<nav>\n^\n</nav>"                        , Language.HTML),
                NewAutocompleteItem("<nobr>"        , "<nobr>^</nobr>"                          , Language.HTML),
                NewAutocompleteItem("<noembed>"     , "<noembed>^</noembed>"                    , Language.HTML),
                NewAutocompleteItem("<noframes>"    , "<noframes>^</noframes>"                  , Language.HTML),
                NewAutocompleteItem("<noscript>"    , "<noscript>^</noscript>"                  , Language.HTML),
                NewAutocompleteItem("<object>"      , "<object>^</object>"                      , Language.HTML),
                NewAutocompleteItem("<ol>"          , "<ol>\n^\n</ol>"                          , Language.HTML),
                NewAutocompleteItem("<optgroup>"    , "<optgroup label=\"^\"></optgroup>"       , Language.HTML),
                NewAutocompleteItem("<option>"      , "<option value=\"^\"></option>"           , Language.HTML),
                NewAutocompleteItem("<output>"      , "<output for=\"^\"></output>"             , Language.HTML),
                NewAutocompleteItem("<p>"           , "<p>^</p>"                                , Language.HTML),
                NewAutocompleteItem("<param>"       , "<param name=\"^\" value=\"\">"           , Language.HTML),
                NewAutocompleteItem("<picture>"     , "<picture>\n<source srcset=\"^\" media=\"\" />\n<img src=\"\" alt=\"\" />\n</picture>", Language.HTML),
                NewAutocompleteItem("<plaintext>"   , "<plaintext>\n^"                          , Language.HTML),
                NewAutocompleteItem("<pre>"         , "<pre>^</pre>"                            , Language.HTML),
                NewAutocompleteItem("<progress>"    , "<progress value=\"^\" max=\"\"></progress>", Language.HTML),
                NewAutocompleteItem("<q>"           , "<q cite=\"^\"></q>"                      , Language.HTML),
                NewAutocompleteItem("<s>"           , "<s>^</s>"                                , Language.HTML),
                NewAutocompleteItem("<script>"      , "<script>^</script>"                      , Language.HTML),
                NewAutocompleteItem("<select>"      , "<select>\n^\n</select>"                  , Language.HTML),
                NewAutocompleteItem("<source>"      , "<source src=\"^\" type=\"\">"            , Language.HTML),
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
                NewAutocompleteItem("<tr>"          , "<tr>\n^\n</tr>"                          , Language.HTML),
                NewAutocompleteItem("<tt>"          , "<tt>^</tt>"                              , Language.HTML),
                NewAutocompleteItem("<u>"           , "<u>^</u>"                                , Language.HTML),
                NewAutocompleteItem("<ul>"          , "<ul>\n^\n</ul>"                          , Language.HTML),
                NewAutocompleteItem("<var>"         , "<var>^</var>"                            , Language.HTML),
                NewAutocompleteItem("<viedo>"       , "<video controls=\"controls\">\n<source src=\"^\" type=\"\" />\n</video>", Language.HTML),
                
            };

            AutocompleteItems.Sort((a, b) => a.MenuText.CompareTo(b.MenuText));
        }

        private SnippetAutocompleteItem NewAutocompleteItem(string name, string snippet, params Language[] languages) => 
            new (FastColoredTextBox, name, snippet, languages, 13);
        private SnippetAutocompleteItem NewAutocompleteItem(string snippet, params Language[] languages) => 
            new (FastColoredTextBox, snippet, snippet, languages, -1);

        protected virtual void OnCodeChanged()
        {
            CodeChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnZoomChanged()
        {
            ZoomChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FastColoredTextBox_TextChanged(object? sender, TextChangedEventArgs e)
        {
            IsSaved = false;
            if (FastColoredTextBox.FindDialogForm != null)
                FastColoredTextBox.FindDialogForm.ClearMarker();
            if (FastColoredTextBox.ReplaceDialogForm != null)
                FastColoredTextBox.ReplaceDialogForm.ClearMarker();
            RefreshText();
            DoHighlightInvisibleChars(e.ChangedRange);
            OnCodeChanged();
            //if (AutoSave && FilePath != null)
            //{
            //    Save();
            //}
        }

        private void FastColoredTextBox_ZoomChanged(object? sender, EventArgs e)
        {
            OnZoomChanged();
        }

        private void FastColoredTextBox_SelectionChanged(object? sender, EventArgs e)
        {
            //OnCodeChanged();
        }

        private void FastColoredTextBox_SelectionChangedDelayed(object? sender, EventArgs e)
        {
            if (HighlightCurrentWord) DoHighlightCurrentWord();
        }

        private void FastColoredTextBox_VisibleRangeChangedDelayed(object? sender, EventArgs e)
        {
            //FastColoredTextBox.OnSyntaxHighlight(new TextChangedEventArgs(FastColoredTextBox.VisibleRange));
            FastColoredTextBox.SyntaxHighlighter.HighlightSyntax(FastColoredTextBox.Language, FastColoredTextBox.VisibleRange);
        }

        private void FastColoredTextBox_TextChangedDelayed(object? sender, TextChangedEventArgs e)
        {
            if (ShowInvisibleChars) DoHighlightInvisibleChars(e.ChangedRange);
        }

        private void FastColoredTextBox_CustomAction(object? sender, CustomActionEventArgs e)
        {
            switch (e.Action)
            {
                case FCTBAction.CustomAction1:
                    InsertCommentPrefix();
                    break;
                case FCTBAction.CustomAction2:
                    RemoveCommentPrefix();
                    break;
                case FCTBAction.CustomAction3:
                    InsertXmlTag(false);
                    break;
                case FCTBAction.CustomAction4:
                    InsertXmlTag(true);
                    break;
                case FCTBAction.CustomAction5:
                    DoAutoIndent();
                    break;
            }
        }

        private void CodeTabPage_Resize(object? sender, EventArgs e)
        {
            DocumentMap.Width = Width switch
            {
                < 256  =>         0,
                < 1024 =>       128,
                _      => Width / 8
            };
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

        public Language AutoDetectLanguage(bool verbose)
        {
            Language lang = FastColoredTextBox.AutoDetectLanguage();

            if (verbose && lang == Language.PlainText)
            {
                MessageBox.Show(ParentForm, StringTable.FailedToAutoDetectMessageBoxText, ParentForm.Text);
            }

            return lang;

            /*
            string? line1 = FastColoredTextBox.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).FirstOrDefault()?.Trim();

            if (line1 == null) goto end;

            string line1lc = line1.ToLowerInvariant();

            if (line1lc.StartsWith("<!doctype") || line1lc.StartsWith("<html")) {
                return Language.HTML;
            } else if (line1lc.StartsWith("<?xml")) {
                return Language.XML;
            } else if (line1lc.StartsWith("<?php")) {
                return Language.PHP;
            } else if (line1lc.StartsWith("@echo")) {
                return Language.Batch;
            } else if (line1.StartsWith("using") || line1.StartsWith("#region")) {
                return Language.CSharp;
            } else if (line1.StartsWith("Imports") || line1.StartsWith("Module") || line1.StartsWith("#Region")) {
                return Language.VB;
            } else if ((line1.StartsWith("import") || line1.StartsWith("package")) && line1.EndsWith(';')) {
                return Language.Java;
            } else if (line1.StartsWith("{")) {
                return Language.JSON;
            } else {
                goto end;
            }

        end:
            if (verbose) MessageBox.Show(ParentForm, StringTable.FailedToAutoDetectMessageBoxText, ParentForm.Text);
            return Language.PlainText;
            */
        }

        private void DoHighlightCurrentWord()
        {
            FastColoredTextBox.Range.ClearStyle(SameWordsStyle);

            string fragment;
            string pattern;

            if (FastColoredTextBox.Selection.IsEmpty)
            {
                // get fragment around caret
                fragment = FastColoredTextBox.Selection.GetFragment(@"\w").Text;

                if (fragment.Length == 0) return;

                pattern = $@"\b{fragment}\b";
            }
            else
            {
                if (FastColoredTextBox.Selection.FromLine != FastColoredTextBox.Selection.ToLine) return;

                fragment = FastColoredTextBox.SelectedText;

                if (fragment.Trim().Length == 0) return;

                pattern = Regex.Escape(fragment);
            }

            //highlight same words
            var ranges = FastColoredTextBox.Range.GetRanges(pattern);
            foreach (var r in ranges)
                r.SetStyle(SameWordsStyle);
        }

        private void DoHighlightInvisibleChars(FastColoredTextBoxNS.Range range)
        {
            range.SetStyle(InvisCharStyle, @".$|.\r\n|\s");
        }

        private void RefreshInvisibleCharsHighlight()
        {
            if (ShowInvisibleChars) DoHighlightInvisibleChars(FastColoredTextBox.Range);
            else FastColoredTextBox.Range.ClearStyle(InvisCharStyle);
        }

        public void Open()
        {
            if (FilePath != null)
            {
                if (Path.GetExtension(FilePath).Equals(".ASCII", StringComparison.InvariantCultureIgnoreCase))
                    Encoding = Encoding.ASCII;
                else
                    Encoding = EncodingDetector.DetectTextFileEncoding(FilePath) ?? new UTF8Encoding(false);
                FastColoredTextBox.OpenFile(FilePath, Encoding);
                IsSaved = true;
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
                FastColoredTextBox.SaveToFile(FilePath, Encoding);
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
            if (saveFileDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                FilePath = saveFileDialog.FileName;
                FastColoredTextBox.SaveToFile(FilePath, Encoding);
                IsSaved = true;
                RefreshText();
                return true;
            }
            return false;
        }

        public void Export()
        {
            //using SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Title = StringTable.ExportFileDialogTitle;
            //saveFileDialog.Filter = StringTable.ExportFileDialogFilter;
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    switch (saveFileDialog.FilterIndex)
            //    {
            //        case 1:
            //            File.WriteAllText(saveFileDialog.FileName, FastColoredTextBox.Rtf);
            //            break;
            //        case 2:
            //            File.WriteAllText(saveFileDialog.FileName, FastColoredTextBox.Html);
            //            break;
            //    }
            //}

            using ExportDialog exportDialog = new ExportDialog(FastColoredTextBox);
            exportDialog.Encoding = Encoding;
            exportDialog.ShowDialog(ParentForm);
        }

        public void Reload()
        {
            if (FilePath != null)
            {
                FastColoredTextBox.OpenFile(FilePath, Encoding);
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
            using PrintCodeDialog printCodeDialog = new PrintCodeDialog(!FastColoredTextBox.Selection.IsEmpty);
            if (printCodeDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                printCodeDialog.PrintDocument.DocumentName = "RedJ Code: " + (Path.GetFileName(FilePath) ?? "new file");
                ExportToRTF export = new ExportToRTF()
                {
                    UseOriginalFont = true,
                    IncludeLineNumbers = printCodeDialog.IncludeLineNumbers
                };
                bool selectionOnly = printCodeDialog.PrintDocument.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection;
                string rtf = export.GetRtf(selectionOnly ? FastColoredTextBox.Selection : FastColoredTextBox.Range);
                RichTextPrinter.PrintRTF(rtf, printCodeDialog.PrintDocument);
            }
        } // use this for printing

        public void ShowProperties()
        {
            if (FilePath == null) return;

            // ShellProperties.ShowPropertiesDialog(FilePath);

            using PropertiesDialog propertiesDialog = new PropertiesDialog(FilePath, Encoding);
            if (propertiesDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                if (ParentForm.IsSafeToClose(this))
                {
                    bool changed = false;

                    if (!Encoding.Equals(Encoding, propertiesDialog.FileEncoding))
                    {
                        Encoding = propertiesDialog.FileEncoding;
                        changed = true;
                    }

                    if (!String.Equals(propertiesDialog.FilePath, propertiesDialog.NewFilePath))
                    {
                        File.Move(propertiesDialog.FilePath, propertiesDialog.NewFilePath);
                        FilePath = propertiesDialog.NewFilePath;
                        changed = true;
                    }

                    if (changed)
                    { 
                        Reload(); 
                    }
                }
            }

        }
        
        public void ChangeEncoding()
        {
            if (!(IsSaved || Save()))
            {
                return;
            }
            using EncodingSelectionDialog encodingSelectionDialog = new EncodingSelectionDialog(Encoding);
            if (encodingSelectionDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                Encoding = encodingSelectionDialog.Encoding;
                Reload();
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
            AddKeysToMacro(Keys.Control | Keys.Z);
        }

        public void Redo()
        {
            FastColoredTextBox.Redo();
            AddKeysToMacro(Keys.Control | Keys.Y);
        }

        public void Cut()
        {
            FastColoredTextBox.Cut();
            AddKeysToMacro(Keys.Control | Keys.X);
        }

        public void Copy()
        {
            FastColoredTextBox.Copy();
            AddKeysToMacro(Keys.Control | Keys.C);
        }

        public void Paste()
        {
            FastColoredTextBox.Paste();
            AddKeysToMacro(Keys.Control | Keys.V);
        }

        public void SelectAll()
        {
            FastColoredTextBox.SelectAll();
            AddKeysToMacro(Keys.Control | Keys.A);
        }

        public void ShowFindDialog()
        {
            FastColoredTextBox.ShowFindDialog();

            if (FastColoredTextBox.FindDialogForm != null)
            {
                FastColoredTextBox.FindDialogForm.Owner = FastColoredTextBox.ParentForm;
                FastColoredTextBox.FindDialogForm.Text = "Find";
                FastColoredTextBox.FindDialogForm.Controls["label1"].Text = "&Find:";
                FastColoredTextBox.FindDialogForm.Controls["cbMatchCase"].Text = "Match &Case";
                FastColoredTextBox.FindDialogForm.Controls["cbWholeWord"].Text = "Match &Whole Word";
                FastColoredTextBox.FindDialogForm.Controls["cbRegex"].Text = "RegE&x";
                FastColoredTextBox.FindDialogForm.Controls["btFindNext"].Text = "Find &Next";
                FastColoredTextBox.FindDialogForm.Controls["btFindPrev"].Text = "Find &Prev";
                FastColoredTextBox.FindDialogForm.Controls["btFindAll"].Text = "Find &All";
                FastColoredTextBox.FindDialogForm.Controls["btClose"].Text = "Cancel";
            }
        }

        public void ShowReplaceDialog()
        {
            FastColoredTextBox.ShowReplaceDialog();

            if (FastColoredTextBox.ReplaceDialogForm != null)
            {
                FastColoredTextBox.ReplaceDialogForm.Owner = FastColoredTextBox.ParentForm;
                FastColoredTextBox.ReplaceDialogForm.Text = "Find and Replace";
                FastColoredTextBox.ReplaceDialogForm.Controls["label1"].Text = "&Find:";
                FastColoredTextBox.ReplaceDialogForm.Controls["label2"].Text = "Re&place:";
                FastColoredTextBox.ReplaceDialogForm.Controls["cbMatchCase"].Text = "Match &Case";
                FastColoredTextBox.ReplaceDialogForm.Controls["cbWholeWord"].Text = "Match &Whole Word";
                FastColoredTextBox.ReplaceDialogForm.Controls["cbRegex"].Text = "RegE&x";
                FastColoredTextBox.ReplaceDialogForm.Controls["btFindNext"].Text = "Find &Next";
                FastColoredTextBox.ReplaceDialogForm.Controls["btFindPrev"].Text = "Find &Prev";
                FastColoredTextBox.ReplaceDialogForm.Controls["btFindAll"].Text = "Find &All";
                FastColoredTextBox.ReplaceDialogForm.Controls["btReplace"].Text = "&Replace Next";
                FastColoredTextBox.ReplaceDialogForm.Controls["btReplacePrev"].Text = "R&eplace Prev";
                FastColoredTextBox.ReplaceDialogForm.Controls["btReplaceAll"].Text = "Replace A&ll";
                FastColoredTextBox.ReplaceDialogForm.Controls["btClose"].Text = "Cancel";
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
            AddKeysToMacro(Keys.Control | Keys.I);
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
            AddKeysToMacro(Keys.Control | Keys.K);
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
            AddKeysToMacro(Keys.Control | Keys.Shift | Keys.K);
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
            AddKeysToMacro(Keys.Alt | Keys.Up);
        }

        public void MoveSelectedLinesDown()
        {
            FastColoredTextBox.MoveSelectedLinesDown();
            AddKeysToMacro(Keys.Alt | Keys.Down);
        }

        public void AutoFormatSelection(Language lang)
        {
            if (FastColoredTextBox.SelectionLength < 0)
            {
                return;
            }
            switch (lang)
            {
                case Language.JSON:
                    InsertAndSelectText(AdvancedStringManipulator.FormatJSON(FastColoredTextBox.SelectedText));
                    break;
                case Language.XML:
                    InsertAndSelectText(AdvancedStringManipulator.FormatXML(FastColoredTextBox.SelectedText));
                    break;
                default:
                    MessageBox.Show(ParentForm, StringTable.FailedToAutoFormatMessageBoxText);
                    return;
            }
            DoAutoIndent();
        }

        public void EncodeBase64()
        {
            InsertAndSelectText(AdvancedStringManipulator.EncodeBase64(FastColoredTextBox.SelectedText, Encoding));
        }

        public void DecodeBase64()
        {
            InsertAndSelectText(AdvancedStringManipulator.DecodeBase64(FastColoredTextBox.SelectedText, Encoding));
        }

        public void EncodeURL()
        {
            InsertAndSelectText(AdvancedStringManipulator.EncodeURL(FastColoredTextBox.SelectedText));
        }

        public void DecodeURL()
        {
            InsertAndSelectText(AdvancedStringManipulator.DecodeURL(FastColoredTextBox.SelectedText));
        }

        public void EncodeRegex()
        {
            InsertAndSelectText(AdvancedStringManipulator.EncodeRegex(FastColoredTextBox.SelectedText));
        }

        public void DecodeRegex()
        {
            InsertAndSelectText(AdvancedStringManipulator.DecodeRegex(FastColoredTextBox.SelectedText));
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
            AddKeysToMacro(Keys.Control | Keys.U);
        }

        public void LowerCase()
        {
            FastColoredTextBox.LowerCase();
            AddKeysToMacro(Keys.Control | Keys.Shift | Keys.U);
        }

        public void TitleCase()
        {
            FastColoredTextBox.TitleCase();
        }

        public void SentenceCase()
        {
            FastColoredTextBox.SentenceCase();
        }

        public void InvertCase()
        {
            FastColoredTextBox.InvertCase();
        }

        public void RandomCase()
        {
            FastColoredTextBox.RandomCase();
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

        #region JSON Stuff

        private void EnsureEmptyLine()
        {
            string currLine = FastColoredTextBox.Lines[FastColoredTextBox.Selection.FromLine];
            if (!string.IsNullOrWhiteSpace(currLine))
            {
                InsertText("\n");
            }
        }

        private bool NeedAppendComma()
        {
            //if (FastColoredTextBox.Selection.FromLine == FastColoredTextBox.LinesCount - 1) return false;
            //string nextLine = FastColoredTextBox.Lines[FastColoredTextBox.Selection.FromLine + 1].TrimStart();
            //return nextLine.StartsWith('{') || nextLine.StartsWith('[') || nextLine.StartsWith('"');

            int line = FastColoredTextBox.Selection.FromLine;
            if (line == FastColoredTextBox.LinesCount - 1) return false;
            int maxSearch = Math.Min(line + 20, FastColoredTextBox.LinesCount - 1); // search for max this number of lines

            do
            {
                line++;
                var r = FastColoredTextBox.GetLine(line);
                var t = r.Text.TrimStart();
                if (t.StartsWith('"') || t.StartsWith('{') || t.StartsWith('{'))
                    return true;
            }
            while (string.IsNullOrWhiteSpace(FastColoredTextBox.Lines[line]) && line < maxSearch);

            return false;
        }

        private void EnsureComma()
        {
            int line = FastColoredTextBox.Selection.FromLine;
            if (line == 0) return;

            Place p;

            do
            {
                line--;
                var r = FastColoredTextBox.GetLine(line);
                var t = r.Text.TrimEnd();
                if (t.EndsWith(',') || t.EndsWith('{') || t.EndsWith('['))
                    return;
                else
                    p = r.End;
            }   
            while (string.IsNullOrWhiteSpace(FastColoredTextBox.Lines[line]) && line > 0) ;

            Place caret = FastColoredTextBox.Selection.Start;
            FastColoredTextBox.Selection.Start = p;
            FastColoredTextBox.InsertText(",");
            FastColoredTextBox.Selection.Start = caret;
        }

        private void GoToSelectionEnd()
        {
            Place end = FastColoredTextBox.GetLine(FastColoredTextBox.Selection.ToLine).End;
            FastColoredTextBox.SelectionLength = 0;
            FastColoredTextBox.Selection.Start = end;
        }

        private int GetBracketType()
        {
            Place start = FastColoredTextBox.Selection.End;

            var r1 = FastColoredTextBox.GetBracketsRange(start, '{', '}', false);
            var r2 = FastColoredTextBox.GetBracketsRange(start, '[', ']', false);

            if (r1 == null && r2 == null) return 0;
            else if (r1 != null && r2 == null) return 1;
            else if (r1 == null && r2 != null) return 2;
            else return r1!.Start > r2!.Start ? 1 : 2;
        }
         
        public void InsertNewJSONObject()
        {
            int bracketType = GetBracketType();

            FastColoredTextBox.BeginAutoUndo();

            GoToSelectionEnd();
            EnsureEmptyLine();
            EnsureComma();

            string str = bracketType == 1 ? "\"\": {\n\n}" : "{\n\n}";
            if (NeedAppendComma()) str += ",";

            InsertAndSelectText(str);
            FastColoredTextBox.DoAutoIndent();

            FastColoredTextBox.EndAutoUndo();
        }

        public void InsertNewJSONArray()
        {
            int bracketType = GetBracketType();

            if (bracketType == 0) return;

            FastColoredTextBox.BeginAutoUndo();

            GoToSelectionEnd();
            EnsureEmptyLine();
            EnsureComma();

            string str = bracketType == 1 ? "\"\": [\n\n]" : "[\n\n]";
            if (NeedAppendComma()) str += ",";

            InsertAndSelectText(str);
            FastColoredTextBox.DoAutoIndent();

            FastColoredTextBox.EndAutoUndo();
        }

        public void InsertNewJSONKeyValuePair()
        {
            int bracketType = GetBracketType();

            if (bracketType == 0) return;

            FastColoredTextBox.BeginAutoUndo();

            GoToSelectionEnd();
            EnsureEmptyLine();
            EnsureComma();

            string str = bracketType == 1 ? "\"\": \"\"" : "\"\"";
            if (NeedAppendComma()) str += ",";

            InsertAndSelectText(str);
            FastColoredTextBox.DoAutoIndent();

            FastColoredTextBox.EndAutoUndo();
        }

        #endregion

        public void InsertDateTime()
        {
            using InsertDateTimeDialog dlg = new();
            if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
            {
                InsertText(dlg.DateTimeString);
            }
        }

        public bool IsRecordingMacro => FastColoredTextBox.MacrosManager.IsRecording;
        public bool CanExecuteMacro => !FastColoredTextBox.MacrosManager.MacroIsEmpty;

        public void StartRecordingMacro()
        {
            FastColoredTextBox.MacrosManager.IsRecording = true;
        }

        public void StopRecordingMacro()
        {
            FastColoredTextBox.MacrosManager.IsRecording = false;
        }

        public void ExecuteMacro()
        {
            FastColoredTextBox.MacrosManager.ExecuteMacros();
        }

        public void ClearMacro()
        {
            FastColoredTextBox.MacrosManager.ClearMacros();
        }

        public void AddKeysToMacro(Keys keys, bool ignoreRecording = false)
        {
            if (IsRecordingMacro || ignoreRecording)
            {
                FastColoredTextBox.MacrosManager.AddKeyToMacros(keys);
            }
        }
    }
}
