﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CleanApi.Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanApi.Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (ApplicationException e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
            catch (Exception e)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(e,"Unhandled Exception for Request {Name} {@Request}",requestName,request);
                throw;
            }
        }
    }
}