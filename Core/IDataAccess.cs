using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IDataAccess<TModel, TArg> where TModel : class
    {
        List<TModel> GetAll();
        TModel Get(TArg id);
        TArg Create(TModel model);
        TArg Update(TModel model);
        void Delete(TArg id);
    }
}
