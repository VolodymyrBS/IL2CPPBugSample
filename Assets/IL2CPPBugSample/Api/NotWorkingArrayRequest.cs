using MediatR;
using System.Collections.Immutable;

namespace IL2CPPBugSample.Api
{
    public class NotWorkingArrayRequest : IRequest<ImmutableArray<string>>
    {
    }
}
