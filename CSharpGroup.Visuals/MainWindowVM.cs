using CSharpGroup.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CSharpGroup.Calculator
{
    public class MainWindowVM : ObservableObject
    {
        private ICommand _commandButton;
        public ICommand commandButton
        {
            get
            {
                if (_commandButton == null)
                {
                    _commandButton = new RelayCommand(
                        param => CommandButton(param.ToString()),
                        param => true
                    );
                }
                return _commandButton;
            }
        }

        private Dictionary<string, Action<int>> _numberSwitch = new Dictionary<string, Action<int>>();
        private Dictionary<string, Action> _commandSwitch = new Dictionary<string, Action>();
        public ObservableCollection<EntryKey> numberKeyList { get; set; } = new ObservableCollection<EntryKey>();

        private string _title = "Future Calculator";
        public string title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _userEntry;
        public string userEntry
        {
            get { return _userEntry; }
            set
            {
                if (_userEntry != value)
                {
                    _userEntry = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindowVM()
        {
            BuildButtons();
            BuildCommandButtonDictionary();
        }

        private void BuildButtons()
        {
            for (int i = 9; i > 0; i--)
                numberKeyList.Add(new EntryKey(i.ToString()));
        }

        public void CommandButton(string command)
        {
            int value;
            if (int.TryParse(command, out value))

                _numberSwitch[command].Invoke(value);
            else

                _commandSwitch[command].Invoke();
        }

        private void BuildCommandButtonDictionary()
        {
            for (int i = 9; i > 0; i--)
                _numberSwitch.Add(i.ToString(), (value) => { userEntry= value.ToString(); });
        }
    }
}