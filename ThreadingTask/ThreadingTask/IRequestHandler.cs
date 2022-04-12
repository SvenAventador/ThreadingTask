using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingTask
{
    public interface IRequestHandler
    {
        /// <summary>
        /// Обработать запрос
        /// </summary>
        /// <param name="message"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        string HandleRequest(string message, string[] arguments);
    }
}
