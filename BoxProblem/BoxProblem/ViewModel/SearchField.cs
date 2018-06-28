using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.ViewModel
{
    public class SearchField
    {
        private string Type;
        private string Value;
        public SearchField()
        {
            Type = "";
            Value = "";
        }
        public SearchField(string NewType, string NewValue)
        {
            Type = NewType;
            Value = NewValue;
        }
        public string GType()
        {
            return Type;
        }
        public string GValue()
        {
            return Value;
        }
        public void SType(string NewType)
        {
            Type = NewType;
        }
        public void SValue(string NewValue)
        {
            Value = NewValue;
        }
    }
}
