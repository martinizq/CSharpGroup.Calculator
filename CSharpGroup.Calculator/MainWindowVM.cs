using CSharpGroup.Helper;
using System;
using System.Collections.Generic;
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
        private Dictionary<string, Action> _commandSwitch = new Dictionary<string, Action>();

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

        public MainWindowVM()
        {
            BuildCommandButtonDictionary();
        }

        public void CommandButton(string command)
        {
            _commandSwitch[command].Invoke();
        }

        private void BuildCommandButtonDictionary()
        {
            _commandSwitch.Add("sampleButton", SampleButton);
        }

        public void SampleButton()
        {
            title = "You pressed my button!";
        }
    }
}