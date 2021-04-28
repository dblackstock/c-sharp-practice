using System;

namespace GradeBook
{
    public class NamedObject
    {
        private string name;

        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}