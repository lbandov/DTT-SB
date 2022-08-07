using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services
{
    public class TaxuallyQueueClient : ITaxuallyQueueClient
    {
        public Task EnqueueAsync<TPayload>(string queueName, TPayload payload) 
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
