using System;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
{ /*
    public class UnitOfWork: IUnitOfWork{

        private readonly IntegrationDbContext _integrationDbContext;
        private BBRepository _bbRepository;
        public IBBRepository BBRepository => _bbRepository ?? = new BBRepository(_integrationDbContext);

        private bool _disposed;
        public UnitOfWork (IntegrationDbContext integrationDbContext)
        {
            _integrationDbContext = integrationDbContext ?? throw new ArgumentNullException(nameof(integrationDbContext));

        } 

        public async Task CompleteAsync()=> await _integrationDbContext.SaveChangesAsync(); 
        public async ValueTask DisposeAsync()
        {	await DisposeAsync(true);
            GC.SuppressFinalize(this); //?
        }

        private async ValueTask DisposeAsync(bool disposing)
        {
            if(!_disposed)
            {
                if (disposing)
                {
                    await _integrationDbContext.DisposeAsync();

                }
                _disposed = true;
            }


        } 
    }

*/
}