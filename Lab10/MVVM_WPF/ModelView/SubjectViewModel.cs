using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF
{
    public class SubjectViewModel : INotifyPropertyChanged
    {
        private Subject subject;

        public SubjectViewModel(Subject s)
        {
            subject = s;
        }

        public string nameSubject
        {
            get { return subject.nameSubject; }
            set
            {
                subject.nameSubject = value;
                OnPropertyChanged("nameSubject");
            }
        }

        public string countLectures
        {
            get { return Convert.ToString(subject.countLectures); }
            set
            {
                subject.countLectures = Convert.ToInt32(value);
                OnPropertyChanged("countLectures");
            }
        }

        public string countLabs
        {
            get { return Convert.ToString(subject.countLabs); }
            set
            {
                subject.countLabs = Convert.ToInt32(value);
                OnPropertyChanged("countLabs");
            }
        }

        public string countListeners
        {
            get { return Convert.ToString(subject.countListeners); }
            set
            {
                subject.countListeners = Convert.ToInt32(value);
                OnPropertyChanged("countListeners");
            }
        }

        public string nameReader
        {
            get { return subject.nameReader; }
            set
            {
                subject.nameReader = value;
                OnPropertyChanged("nameReader");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}