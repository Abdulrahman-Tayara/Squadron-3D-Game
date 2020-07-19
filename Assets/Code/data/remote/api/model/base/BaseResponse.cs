using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class BaseResponse<T> {
    public bool success { set; get; }
    public string message { set; get; }
    public T data { set; get; }

}


