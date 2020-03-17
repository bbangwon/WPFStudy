using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTreeView
{
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name => Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);
    }
}
