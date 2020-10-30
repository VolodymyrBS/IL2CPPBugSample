using System.Threading;
using System.Threading.Tasks;
using IL2CPPBugSample.Api;
using MediatR;

namespace IL2CPPBugSample.Handlers
{
    public sealed class NotWorkingUnityHandler : IRequestHandler<NotWorkingUnitRequest, Unit>
    {
        public Task<Unit> Handle(NotWorkingUnitRequest request, CancellationToken cancellationToken) => Unit.Task;
    }
}