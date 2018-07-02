using System.Collections.Generic;
using HelloWorld.Rest.Model.Message;

namespace HelloWorld.Rest.Common.Repository
{
    public interface IRepository
    {
        bool Delete(int Id);
        MessageDto GetbyID(int Id);
        IEnumerable<MessageDto> GetAll();
        bool Insert(MessageDto Message);
        bool Update(MessageDto Message, int Id);
    }
}
