using System.Drawing;

namespace RedJ_Code
{
    internal static class StringTable
    {
        public static readonly string ThreadExceptionMessageBoxCaption  = "Error";
        public static readonly string FastColoredTextBoxHotkeys         = "Tab=IndentIncrease, Escape=ClearHints, PgUp=GoPageUp, PgDn=GoPageDown, End=GoEnd, Home=GoHome, Left=GoLeft, Up=GoUp, Right=GoRight, Down=GoDown, Ins=ReplaceMode, Del=DeleteCharRight, Ctrl+0=ZoomNormal, Ctrl+Add=ZoomIn, Ctrl+Subtract=ZoomOut, Ctrl+Oemplus=ZoomIn, Ctrl+OemMinus=ZoomOut, F3=FindNext, Shift+F3=FindPrevious, Ctrl+Alt+F=FindChar, Shift+Tab=IndentDecrease, Shift+PgUp=GoPageUpWithSelection, Shift+PgDn=GoPageDownWithSelection, Shift+End=GoEndWithSelection, Shift+Home=GoHomeWithSelection, Shift+Left=GoLeftWithSelection, Shift+Up=GoUpWithSelection, Shift+Right=GoRightWithSelection, Shift+Down=GoDownWithSelection, Shift+Ins=Paste, Shift+Del=Cut, Ctrl+Back=ClearWordLeft, Ctrl+End=GoLastLine, Ctrl+Home=GoFirstLine, Ctrl+Left=GoWordLeft, Ctrl+Up=ScrollUp, Ctrl+Right=GoWordRight, Ctrl+Down=ScrollDown, Ctrl+Ins=Copy, Ctrl+Del=ClearWordRight, Ctrl+Shift+End=GoLastLineWithSelection, Ctrl+Shift+Home=GoFirstLineWithSelection, Ctrl+Shift+Left=GoWordLeftWithSelection, Ctrl+Shift+Right=GoWordRightWithSelection, Alt+Shift+Left=GoLeft_ColumnSelectionMode, Alt+Shift+Up=GoUp_ColumnSelectionMode, Alt+Shift+Right=GoRight_ColumnSelectionMode, Alt+Shift+Down=GoDown_ColumnSelectionMode, Ctrl+Alt+F=FindChar, Ctrl+A=SelectAll, Ctrl+Z=Undo, Ctrl+Y=Redo, Ctrl+X=Cut, Ctrl+C=Copy, Ctrl+V=Paste, Ctrl+U=UpperCase, Ctrl+Shift+U=LowerCase, Alt+Up=MoveSelectedLinesUp, Alt+Down=MoveSelectedLinesDown, Ctrl+K=CustomAction1, Ctrl+Shift+K=CustomAction2, Ctrl+J=CustomAction3, Ctrl+Shift+J=CustomAction4, Ctrl+I=CustomAction5";
        public static readonly string TerminalFastColoredTextBoxHotkeys = "PgUp=GoPageUp, PgDn=GoPageDown, End=GoEnd, Home=GoHome, Left=GoLeft, Right=GoRight, Ctrl+0=ZoomNormal, Ctrl+Add=ZoomIn, Ctrl+Subtract=ZoomOut, Ctrl+Oemplus=ZoomIn, Ctrl+OemMinus=ZoomOut, Shift+PgUp=GoPageUpWithSelection, Shift+PgDn=GoPageDownWithSelection, Shift+End=GoEndWithSelection, Shift+Home=GoHomeWithSelection, Shift+Left=GoLeftWithSelection, Shift+Up=GoUpWithSelection, Shift+Right=GoRightWithSelection, Shift+Down=GoDownWithSelection, Ctrl+Back=ClearWordLeft, Ctrl+End=GoLastLine, Ctrl+Home=GoFirstLine, Ctrl+Left=GoWordLeft, Ctrl+Up=ScrollUp, Ctrl+Right=GoWordRight, Ctrl+Down=ScrollDown, Ctrl+Ins=Copy, Ctrl+Del=ClearWordRight, Ctrl+Shift+End=GoLastLineWithSelection, Ctrl+Shift+Home=GoFirstLineWithSelection, Ctrl+Shift+Left=GoWordLeftWithSelection, Ctrl+Shift+Right=GoWordRightWithSelection, Ctrl+X=Cut, Ctrl+C=Copy, Ctrl+V=Paste, Ctrl+A=SelectAll";
        public static readonly string OpenFileDialogTitle               = "Open File";
        public static readonly string SaveFileDialogTitle               = "Save File";
        public static readonly string ExportFileDialogTitle             = "Export File";
        public static readonly string OpenFileDialogFilter              = "All Supported Types|*.txt;*.bat;*.cmd;*.cs;*.html;*.htm;*.java;*.js;*.json;*.lua;*.php;*.py;*.sql;*.vb;*.xml|Plain Text|*.txt|C#|*.cs|CMD Batch|*.bat;*.cmd|HTML|*.html;*.htm|Java|*.java|JavaScript|*.js|JSON|*.json|Lua|*.lua|PHP|*.php|Python|*.py|SQL|*.sql|Visual Basic|*.vb|XML|*.xml|All Files|*";
        public static readonly string SaveFileDialogFilter              = "Plain Text|*.txt|C#|*.cs|CMD Batch|*.bat;*.cmd|HTML|*.html;*.htm|Java|*.java|JavaScript|*.js|JSON|*.json|Lua|*.lua|PHP|*.php|Python|*.py|SQL|*.sql|Visual Basic|*.vb|XML|*.xml|All Files|*";
        public static readonly string ExportFileDialogFilter            = "RTF|*.rtf|HTML|*.html;*.htm";
        public static readonly string CloseUnsavedFileMessageBoxText    = "Do you want to save changes made to this tab?";
        public static readonly string ResetSettingsMessageBoxText       = "Are you sure you want to reset all preferences to their default values? This action cannot be undone!";
        public static readonly string ResetSettingsMessageBoxCaption    = "Reset Preferences";
        public static readonly string NoHelpAvailableMessageBoxCaption  = "No help available for this setting.";
        public static readonly string FailedToAutoDetectMessageBoxText  = "Failed to auto-detect the language.";
        public static readonly string FailedToAutoFormatMessageBoxText  = "No auto-formatting is available for this language.";
        public static readonly string WebsiteURL                        = "https://www.redj.me/";
    }

    internal static class Snippets
    {
        public static readonly string CSharp_Main           = "public static void Main(string[] args)\n{\n\n}";
        public static readonly string CSharp_ToString       = "public override string ToString()\n{\nreturn base.ToString();\n}";
        public static readonly string CSharp_Equals         = "public override bool Equals(object? obj)\n{\nreturn base.Equals(obj);\n}";
        public static readonly string CSharp_GetHashCode    = "public override int GetHashCode()\n{\nreturn base.GetHashCode();\n}";

        public static readonly string VB_Main               = "Sub Main(args As String())\n\nEnd Sub";
        public static readonly string VB_ToString           = "Public Overrides Function Equals(obj As Object) As Boolean\nReturn MyBase.Equals(obj)\nEnd Function";
        public static readonly string VB_Equals             = "Public Overrides Function GetHashCode() As Integer\nReturn MyBase.GetHashCode()\nEnd Function";
        public static readonly string VB_GetHashCode        = "Public Overrides Function ToString() As String\nReturn MyBase.ToString()\nEnd Function";

        public static readonly string HTML_V5Document       = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset=\"UTF-8\">\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1.0\">\n<title>YOUR WEBSITE TITLE</title>\n</head>\n<body>\nYOUR WEBSITE CONTENT\n</body>\n</html>";
        public static readonly string HTML_V4Document       = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">\n<HTML>\n<HEAD>\n<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n<META http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\" />\n<TITLE>My first Website</TITLE>\n</HEAD>\n<BODY>\n<P>Hello, world!</P>\n</BODY>\n</HTML>";
        public static readonly string HTML_XUACompatible    = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\">";

        public static readonly string XML_Prolog            = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        public static readonly string Java_Main             = "public static void main(String[] args)\n{\n\n}";
        public static readonly string Java_ToString         = "@Override\npublic String toString()\n{\nreturn super.toString();\n}";
        public static readonly string Java_Equals           = "@Override\npublic boolean equals(Object obj)\n{\nreturn super.equals(obj);\n}";
        public static readonly string Java_HashCode         = "@Override\npublic int hashCode()\n{\nreturn super.hashCode();\n}";
    }

    internal static class ColorTable
    {
        public static readonly Color LineNumberColor = Color.Teal;
        public static readonly Color BookmarkColor = Color.Blue;
        public static readonly Color FoldingIndicatorColor = Color.Green;
        public static readonly Color CurrentLineColor = Color.LightBlue;
        public static readonly Color SelectionColor = Color.MediumBlue;
        public static readonly Color DocumentMapForeColor = Color.Blue;
        public static readonly Color AutocompleteMenuColor = Color.CornflowerBlue;
        public static readonly Color BackgroundColor = Color.White;
    }
}
