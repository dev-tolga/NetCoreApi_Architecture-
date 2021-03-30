using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        public string Name { get; set; }//Product ==> instance ismi product
        public object Value { get; set; }//
        public string Type { get; set; }//Product

    }
}
