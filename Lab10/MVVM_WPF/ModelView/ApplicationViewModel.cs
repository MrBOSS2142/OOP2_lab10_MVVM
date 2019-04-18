using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF
{
    public class ApplicationViewModel : BaseViewModel
    {
        private Subject selectedSubject;

        public ObservableCollection<Subject> Subjects { get; set; }

        private RelayCommand newCommand;
        public RelayCommand NewCommand
        {
            get
            {
                return newCommand ??
                  (newCommand = new RelayCommand(obj =>
                  {
                      Subject subject = new Subject();
                      Subjects.Insert(0, subject);
                      SelectedSubject = subject;
                  }));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Subject subject = obj as Subject;
                      
                        using(SubjectContext db = new SubjectContext())
                        {
                            db.Subjects.Add(subject);
                            db.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Subject subject = obj as Subject;
                        if (subject != null)
                        {
                            Subjects.Remove(subject);
                        }

                        using (SubjectContext db = new SubjectContext())
                        {
                            Subject subject1 = new Subject();
                            subject1 = db.Subjects.FirstOrDefault(p => p.nameSubject == subject.nameSubject);
                            ///var store = db.Storages.Where(p => p.Name == storage.Name).ToList();
                            db.Subjects.Remove(subject1);
                            db.SaveChanges();
                        }
                    },
            (obj) => Subjects.Count > 0));
            }
        }

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }

        public ApplicationViewModel()
        {
            using(SubjectContext db = new SubjectContext())
            {
                Subjects = new ObservableCollection<Subject>();
                foreach (var v in db.Subjects)
                {
                    
                    Subjects.Add(new Subject {
                        nameSubject = v.nameSubject,
                        countLectures = v.countLectures,
                        countLabs = v.countLabs,
                        countListeners = v.countListeners,
                        nameReader = v.nameReader
                    });
                   
                }
            }
        }
           

       
    }
}
