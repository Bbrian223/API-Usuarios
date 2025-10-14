using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responce
{
    public class ResponceViewModel<T>
    {
        public bool status { get; set; }
        public string? msg { get; set; }
        public T? data { get; set; }

        public ResponceViewModel(T? data, string msg = "Operacion realizada exitosamente")
        {
            this.status = true;
            this.msg = msg;
            this.data = data;
        }

        public ResponceViewModel()
        {
        }
    }

    public class ResponceViewModel
    {
        public bool status { get; set; }
        public string? ErrorCode { get; set; }
        public string? msg { get; set; }
    }
}
