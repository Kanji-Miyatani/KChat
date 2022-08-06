using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Interfaces
{
    public interface IViewModelSelectProcess<T>
    {
        T GetViewModel();
    }
}
