using System.Collections.Generic;

namespace HospitalLibrary.Core.Room
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);
        void Create(Room room);
        void Update(Room room);
        void Delete(Room room);
        IEnumerable<int> GetAllWithFreeBeds();
    }
}
