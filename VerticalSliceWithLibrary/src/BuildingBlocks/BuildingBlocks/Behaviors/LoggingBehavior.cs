//using MediatR;
//using Microsoft.Extensions.Logging;
//using System.Diagnostics;


//namespace BuildingBlocks.Behaviors;
//public class LoggingBehavior<TRequest, TResponse>
//    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
//    : IPipelineBehavior<TRequest, TResponse>
//    where TRequest : notnull, IRequest<TResponse>
//    where TResponse : notnull
//{
//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        logger.LogInformation("[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
//            typeof(TRequest).Name, typeof(TResponse).Name, request);

//        var timer = new Stopwatch();
//        timer.Start();

//        var response = await next();

//        timer.Stop();
//        var timeTaken = timer.Elapsed;
//        if (timeTaken.Seconds > 3) // if the request is greater than 3 seconds, then log the warnings
//            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
//                typeof(TRequest).Name, timeTaken.Seconds);

//        logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
//        return response;
//    }
//}

using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("""
            [START] Handling {Request} -> {Response}
            RequestData: {@Request}
            """, typeof(TRequest).Name, typeof(TResponse).Name, request);

        var stopwatch = Stopwatch.StartNew();
        var response = await next();
        stopwatch.Stop();

        var elapsed = stopwatch.Elapsed;
        if (elapsed.TotalSeconds > 3)
        {
            _logger.LogWarning("[PERFORMANCE] {Request} took {ElapsedSeconds:0.000} seconds",
                typeof(TRequest).Name, elapsed.TotalSeconds);
        }

        _logger.LogInformation("[END] Handled {Request} -> {Response}",
            typeof(TRequest).Name, typeof(TResponse).Name);

        return response;
    }
}
