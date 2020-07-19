using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IApiProvider {
    Task<T> post<T>(string endPoint, object data);

    Task<T> get<T>(string endPoint);
}

