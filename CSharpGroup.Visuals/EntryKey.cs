using CSharpGroup.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGroup.Calculator
{
    public class EntryKey: ObservableObject
    {
        private string _caption;
        public string caption
        {
            get { return _caption; }
            set
            {
                if (_caption != value)
                {
                    _caption = value;
                    OnPropertyChanged();
                }
            }
        }
        public EntryKey(string caption)
        {
            this.caption = caption;
        }
    }
}
