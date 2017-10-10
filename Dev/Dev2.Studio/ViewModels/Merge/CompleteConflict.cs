﻿using System;
using Dev2.Common.Interfaces;
using System.Collections.ObjectModel;
using Dev2.Studio.Interfaces;
using Microsoft.Practices.Prism.Mvvm;

namespace Dev2.ViewModels.Merge
{
    public class CompleteConflict : BindableBase, ICompleteConflict
    {
        private bool _isMergeExpanded;
        private bool _isMergeExpanderEnabled;
        private bool _hasConflict;

        public CompleteConflict()
        {
            Children = new ObservableCollection<ICompleteConflict>();
        }

        public IMergeToolModel CurrentViewModel { get; set; }
        public IMergeToolModel DiffViewModel { get; set; }
        public ObservableCollection<ICompleteConflict> Children { get; set; }
        public Guid UniqueId { get; set; }

        public bool HasConflict
        {
            get => _hasConflict;
            set
            {
                _hasConflict = value;
                OnPropertyChanged(() => HasConflict);
            }
        }

        public bool IsMergeExpanderEnabled
        {
            get => _isMergeExpanderEnabled;
            set
            {
                _isMergeExpanderEnabled = value;
                OnPropertyChanged(() => IsMergeExpanderEnabled);
            }
        }

        public bool IsMergeExpanded
        {
            get => _isMergeExpanded;
            set
            {
                _isMergeExpanded = value;
                OnPropertyChanged(() => IsMergeExpanded);
            }
        }
    }
}