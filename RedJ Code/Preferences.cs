namespace RedJ_Code
{
    public class Preferences
    {
        public Preferences() { }

        public bool ToolStripVisible { get; set; }
        public bool StatusStripVisible { get; set; }

        public bool TabControlMultiline { get; set; }
        public int TabControlAppearance { get; set; }
        public int TabControlSizingMode { get; set; }

        public bool WordWrap { get; set; }
        public bool WordWrapAutoIndent { get; set; }
        public int WordWrapMode { get; set; }
        public bool ShowLineNumbers { get; set; }
        public int LineNumberColor { get; set; }
        public int ReservedCountOfLineNumberChars { get; set; }
        public int LeftPadding { get; set; }
        public int BookmarkColor { get; set; }
        public bool ShowScrollBars { get; set; }
        public bool ShowFoldingLines { get; set; }
        public bool HighlightFoldingIndicator { get; set; }
        public int FoldingIndicatorColor { get; set; }
        public bool HighlightCurrentLine { get; set; }
        public int CurrentLineColor { get; set; }
        public bool HighlightCurrentWord { get; set; }
        //public bool CaretVisible { get; set; }
        //public bool CaretBlinking { get; set; }
        //public bool WideCaret {  get; set; }
        //public bool ShowCaretWhenInactive { get; set; }
        public bool AllowDragDrop { get; set; }
        public bool AutoIndent { get; set; }
        public bool AutoCompleteBrackets { get; set; }
        public bool VirtualSpace { get; set; }

        public bool DocumentMapVisible { get; set; }
        public bool DocumentMapScrollbarVisible { get; set; }
        public int DocumentMapWidth { get; set; }
        public int DocumentMapForeColor { get; set; }

        public bool RulerVisible { get; set; }

        public bool AutocompleteMenuEnabled { get; set; }
        public int AutocompleteMenuForeColor { get; set; }

        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public int FontStyle { get; set; }
    }
}
