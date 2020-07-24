using System;
namespace spa.Data.Network
{
    public class CustomerResponse
    {
        private Array results;
        public CustomerResponse()
        {
        }
        public Array getResults()
        {
            return results;
        }

        public void setResults(Array results)
        {
            this.results = results;
        }
    }
}
