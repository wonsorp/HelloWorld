using System;
using Xunit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using HelloWorld.Rest.Workflow.Message;
using HelloWorld.Rest.Common.Repository;

namespace HelloWorld.Rest.UnitTest
{
  

    public class UnitTest1
    {
        string baseurl = "http://localhost:52760/";

        [Fact]
        public async Task testURLConnectSuccess()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                HttpResponseMessage response = client.GetAsync("/api/message/" + "0").Result;
                Assert.Equal("OK", response.StatusCode.ToString());
            }

        }

        [Fact]
        public async Task testURLConnectFail()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                HttpResponseMessage response = client.GetAsync("/api/message/" + "2").Result;
                Assert.NotEqual("OK", response.StatusCode.ToString());
            }

        }

        [Fact]
        public async Task testWorkflow()
        {
            ProcessHelloWorld p = new ProcessHelloWorld(0);
            bool retval = await p.Execute();
            Assert.True(retval);
            Assert.Empty(p.ExecutionErrors);
            Assert.Empty(p.ValidationErrors);
            Assert.NotEmpty(p.messages);
        }

        [Fact]
        public void testRepositoryImplementation()
        {
          IRepository _repository;
            _repository = Rest.Repository.Factory.RepositoryFactory.GetRepository(RepositoryType.InMemory);
            Assert.NotNull(_repository);
        }

    }
}
