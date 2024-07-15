using System.Collections.Generic;
using System.Windows.Forms;

namespace RedJ_Code
{
    internal class RecentFilesList
    {
        public int MaxFiles { get; }
        public List<string> Files { get; }

        public RecentFilesList(int max)
        {
            MaxFiles = max;
            Files = new List<string>(max);
        }

        public void AddFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                return;
            }

            int index = Files.IndexOf(file);

            if (index == 0)
            {
                return;
            }

            if (index != -1)
            {
                Files.RemoveAt(index);
            }

            Files.Insert(0, file);

            if (Files.Count > MaxFiles)
            {
                Files.RemoveAt(MaxFiles);
            }
        }

        public void ClearFiles()
        {
            Files.Clear();
        }

        public ToolStripMenuItem[] ToToolStripMenuItemArray()
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[Files.Count];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ToolStripMenuItem($"");
            }

            return items;
        }
    }
}
