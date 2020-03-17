using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows.Input;

namespace WpfTreeView
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name => Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand => Type != DirectoryItemType.File;

        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);

            FullPath = fullPath;
            Type = type;

            ClearChildren();
        }

        public bool IsExpanded
        {
            get => Children?.Count(f => f != null) > 0;
            set
            {
                if (value == true)
                    Expand();
                else
                    ClearChildren();

            }
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;

            var children = DirectoryStructure.GetDirectoryContent(FullPath);

            Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
