using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Controls.ItemPicker
{
    public class ItemPickerControlViewModel<T>:BindableBase
    {
        private ObservableCollection<T> _availableItems=new ObservableCollection<T>();
        private ObservableCollection<T> _chosenItems=new ObservableCollection<T>();
        private T _selectedAvailableItem;
        private T _selectedChosenItem;

        public ObservableCollection<T> AvailableItems { get => _availableItems; set {
                if (value == null) return;
                _availableItems = value;
                RaisePropertyChanged(); } }
        public ObservableCollection<T> ChosenItems { get => _chosenItems; set {
                if (value == null) return;
                _chosenItems = value;
                RaisePropertyChanged(); } }
        public T SelectedAvailableItem { get => _selectedAvailableItem; set { _selectedAvailableItem = value; RaisePropertyChanged(); AddItemCmd.RaiseCanExecuteChanged(); } }
        public T SelectedChosenItem { get => _selectedChosenItem; set { _selectedChosenItem = value; RaisePropertyChanged(); RemoveItemCmd.RaiseCanExecuteChanged(); } }
        
        public DelegateCommand AddItemCmd { get; set; }
        public DelegateCommand RemoveItemCmd { get; set; }

        public ItemPickerControlViewModel()
        {
            AddItemCmd = new DelegateCommand(() => {
                ChosenItems.Add(SelectedAvailableItem);
                AvailableItems.Remove(SelectedAvailableItem);
            }, () => _selectedAvailableItem != null);

            RemoveItemCmd = new DelegateCommand(() => {
                AvailableItems.Add(SelectedChosenItem);
                ChosenItems.Remove(SelectedChosenItem);
            }, () => _selectedChosenItem != null);
        }

    }
}
