using FastColoredTextBoxNS;
using System;
using System.Linq;

namespace RedJ_Code
{
    /// <summary>
    /// Autocomplete item for code snippets.
    /// </summary>
    /// <remarks>Snippet can contain special char ^ for caret position.</remarks>
    public class SnippetAutocompleteItem : AutocompleteItem
    {
        public Language[] Languages { get; set; }
        public FastColoredTextBox FCTB { get; set; }

        public SnippetAutocompleteItem(FastColoredTextBox fctb, string name, string snippet, Language[] languages, int imageIndex)
        {
            Languages = languages;
            FCTB = fctb;
            MenuText = name;
            Text = snippet;
            ImageIndex = imageIndex;
            ToolTipTitle = "Snippet:";
            ToolTipText = Text.Replace("^", string.Empty);
        }

        public override string ToString()
        {
            return MenuText;
        }

        public override string GetTextForReplace()
        {
            return Text;
        }

        public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            e.Tb.BeginUpdate();
            e.Tb.Selection.BeginUpdate();
            //remember places
            var p1 = popupMenu.Fragment.Start;
            var p2 = e.Tb.Selection.Start;
            //do auto indent
            if (e.Tb.AutoIndent)
            {
                for (int iLine = p1.iLine + 1; iLine <= p2.iLine; iLine++)
                {
                    e.Tb.Selection.Start = new Place(0, iLine);
                    e.Tb.DoAutoIndent(iLine);
                }
            }
            e.Tb.Selection.Start = p1;
            //move caret position right and find char ^
            while (e.Tb.Selection.CharBeforeStart != '^')
                if (!e.Tb.Selection.GoRightThroughFolded())
                    break;
            //remove char ^
            if (e.Tb.Selection.CharBeforeStart == '^')
            {
                e.Tb.Selection.GoLeft(true);
                e.Tb.ClearSelected();
            }
            //
            e.Tb.Selection.EndUpdate();
            e.Tb.EndUpdate();
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        public override CompareResult Compare(string fragmentText)
        {
            if (!Languages.Contains(FCTB.Language))
                return CompareResult.Hidden;

            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }
    }
}
