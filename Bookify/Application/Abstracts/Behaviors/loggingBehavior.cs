using Application.Abstracts.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Abstracts.Behaviors
{
    public class loggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public loggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation("Executing command {Command}", name);

                var result = await next();

                _logger.LogInformation("Command {Command} processed succesfully", name);

                return result;

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Command {Command} processing failed", name);
                throw;
            }
        }
    }
}
