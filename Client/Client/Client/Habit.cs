using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Habit
    {
        public string Line { get; set; }
        public bool IsActive { get; set; }

        public Habit(string line, bool isActive)
        {
            Line = line;
            IsActive = isActive;
        }
    }
}
