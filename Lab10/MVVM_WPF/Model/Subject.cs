using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF
{
    public class Subject
    {
        public int Id { get; set; }
        public string nameSubject { get; set; }
        public int countLectures { get; set; }
        public int countLabs { get; set; }
        public int countListeners { get; set; }
        public string nameReader { get; set; }
    }
}
