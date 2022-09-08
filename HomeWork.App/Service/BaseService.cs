using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.App.Service
{
    internal class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
    }
}
