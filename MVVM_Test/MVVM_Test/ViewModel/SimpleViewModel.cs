using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MVVM_Test.Model;

namespace MVVM_Test.ViewModel
{
    public class SimpleViewModel : CommonBase
    {
        private bool _IsDadChecked = false;
        private bool _IsSonEnabled = false;
        private bool _IsDaughterEnabled = false;

        public bool IsDadChecked
        {
            get { return _IsDadChecked; }
            set
            {
                if (_IsDadChecked != value)
                {
                    _IsDadChecked = value;
                    IsSonEnabled = value;
                    IsDaughterEnabled = value;
                    RaisePropertyChanged("IsDadChecked");
                }
            }
        }

        public bool IsSonEnabled
        {
            get { return _IsSonEnabled; }
            set
            {
                if (_IsSonEnabled != value)
                {
                    _IsSonEnabled = value;
                    RaisePropertyChanged("IsSonEnabled");
                }
            }
        }

        public bool IsDaughterEnabled
        {
            get { return _IsDaughterEnabled; }
            set
            {
                if (_IsDaughterEnabled != value)
                {
                    _IsDaughterEnabled = value;
                    RaisePropertyChanged("IsDaughterEnabled");
                }
            }
        }
    }
}
