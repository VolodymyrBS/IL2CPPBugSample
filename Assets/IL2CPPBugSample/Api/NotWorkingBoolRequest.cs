using MediatR;

namespace IL2CPPBugSample.Api
{
    public sealed class NotWorkingBoolRequest : IRequest<bool>
    {
    }
}