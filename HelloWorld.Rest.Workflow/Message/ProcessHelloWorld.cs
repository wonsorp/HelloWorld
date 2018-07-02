using HelloWorld.Rest.Common.Logging;
using HelloWorld.Rest.Workflow.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Rest.Common.Repository;
using HelloWorld.Rest.Model.Message;

namespace HelloWorld.Rest.Workflow.Message
{
    public class ProcessHelloWorld : ITask
    {
        private IRepository _repository;
        public List<MessageDto> messages;
        public ErrorList ExecutionErrors { get; } = new ErrorList();
        

        public ProcessHelloWorld(int type)
        {
            if (Enum.IsDefined(typeof(RepositoryType), type))
            {
                var etype = (RepositoryType)type;
                _repository = Rest.Repository.Factory.RepositoryFactory.GetRepository(etype);
            }
            else
            {
                ExecutionErrors.AddError("", new List<string>() { "Incorrect type request" });
                return;
            }
        }
        
        public ErrorList ValidationErrors
        {
            get
            {
                var valErrors = new ErrorList();
             // add any value checking here
             //   ErrorHelper.CheckNotNull(valErrors, "", "");
                return valErrors;
            }
        }

        public async Task<bool> Execute()
        {
            if (ValidationErrors.Any())
            {
                return false;
            }
             messages = _repository.GetAll().ToList();
            if (!messages.Any())
            {
                
                ExecutionErrors.AddError("", new List<string>() { "Could Not Retreive Message"});
                return false;
            }
            return true;
        }

    }
   
    }
