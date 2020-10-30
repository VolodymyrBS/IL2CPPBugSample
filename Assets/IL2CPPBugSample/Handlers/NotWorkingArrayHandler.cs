using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using IL2CPPBugSample.Api;
using MediatR;

namespace IL2CPPBugSample.Handlers
{
    public sealed class NotWorkingArrayHandler : IRequestHandler<NotWorkingArrayRequest, ImmutableArray<string>>
    {
        public Task<ImmutableArray<string>> Handle(NotWorkingArrayRequest request, CancellationToken cancellationToken) => Task.FromResult(ImmutableArray.Create("Hello"));
    }
}