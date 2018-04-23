using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CustomEditSettingExample
{
    class TaskViewModel
    {
        private ObservableCollection<Task> _List;
        public ObservableCollection<Task> List {
            get {
                if (_List == null) {
                    _List = new ObservableCollection<Task>();
                    for (int i = 0; i < 100; i++) {
                        _List.Add(new Task() { Name = "Task" + i, Date = DateTime.Now.AddDays(new Random(i).Next(1, 31)) });
                    }
                }
                return _List;
            }
        }

        public class Task
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
