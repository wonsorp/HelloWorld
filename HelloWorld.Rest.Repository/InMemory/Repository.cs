using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld.Rest.Common.Repository;
using HelloWorld.Rest.Model.Message;

namespace HelloWorld.Rest.Repository.InMemory
{
    public class Repository : IRepository
    {
        bool IRepository.Delete(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MessageDto> IRepository.GetAll()
        {
            List<MessageDto> messages = new List<MessageDto>();
            MessageDto message = new MessageDto();
            message.MessageId = 0;
            message.StorageType = 0;
            message.Message = "Hello World";
            messages.Add(message);
            return messages;
        }

        MessageDto IRepository.GetbyID(int Id)
        {
            throw new NotImplementedException();
        }

        bool IRepository.Insert(MessageDto Message)
        {
            throw new NotImplementedException();
        }

        bool IRepository.Update(MessageDto Message, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
