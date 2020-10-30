using IL2CPPBugSample.Api;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IL2CPPBugSample.Handlers
{
    public sealed class WorkingHandler : IRequestHandler<WorkingRequest, string>
    {
        public Task<string> Handle(WorkingRequest request, CancellationToken cancellationToken) => Task.FromResult("Hello");
    }
}
