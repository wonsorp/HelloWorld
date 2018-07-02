using HelloWorld.Rest.Common.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HelloWorld.Rest.Workflow.Common
{
    public interface ITask
    {
        ErrorList ValidationErrors { get; }
        ErrorList ExecutionErrors { get;}
        Task<bool> Execute();
    }
}
