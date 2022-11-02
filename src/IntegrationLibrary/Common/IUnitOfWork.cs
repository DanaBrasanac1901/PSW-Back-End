using System;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
{
    public interface IUnitOfWork: IAsyncDisposable{

//interfejsi
      //  IBBRepository BBrepository {get;}
        Task CompleteAsync();

    }
}