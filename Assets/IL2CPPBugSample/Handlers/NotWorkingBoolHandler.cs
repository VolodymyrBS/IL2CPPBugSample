using System.Threading;
using System.Threading.Tasks;
using IL2CPPBugSample.Api;
using MediatR;

namespace IL2CPPBugSample.Handlers
{
    public sealed class NotWorkingBoolHandler : IRequestHandler<NotWorkingBoolRequest, bool>
    {
        public Task<bool> Handle(NotWorkingBoolRequest request, CancellationToken cancellationToken) => Task.FromResult(true);
    }
}