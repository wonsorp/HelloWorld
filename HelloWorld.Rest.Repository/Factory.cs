using HelloWorld.Rest.Common.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace HelloWorld.Rest.Repository
{
    public static class Factory
    {
        public static class RepositoryFactory
        {
           
            //return the required object
           public static IRepository GetRepository(RepositoryType type)
            {
                switch (type)
                {
                    case RepositoryType.InMemory:
                        return new InMemory.Repository();
                    default:
                        throw new ArgumentException();
                }
            }
           
        }
    }
}
