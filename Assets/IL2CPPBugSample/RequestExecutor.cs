using IL2CPPBugSample.Api;
using Injecter;
using MainThreadDispatcher;
using MediatR;
using System;
using System.Threading.Tasks;
using UnityEngine;
using IL2CPPBugSample.Handlers;
using MediatR.Pipeline;
using UnityEngine.UI;
using UnityEngine.Scripting;
using System.Collections.Immutable;

namespace IL2CPPBugSample
{
    public sealed class RequestExecutor : MonoBehaviour
    {
        [Inject] private readonly IMediator _mediator = default;
        [Inject] private readonly IMainThreadDispatcher _dispatcher = default;

        [SerializeField] private Button _workingButton;
        [SerializeField] private Text _workingText;
        [SerializeField] private Button _notWorkingUnitButton;
        [SerializeField] private Text _notWorkingUnitText;
        [SerializeField] private Button _notWorkingArrayButton;
        [SerializeField] private Text _notWorkingArrayText;
        [SerializeField] private Button _notWorkingBoolButton;
        [SerializeField] private Text _notWorkingBoolText;

        [Preserve]
        public void Stub()
        {
            Inner<NotWorkingUnitRequest, Unit>();
            Inner<NotWorkingBoolRequest, bool>();
            Inner<NotWorkingArrayRequest, ImmutableArray<string>>();

            void Inner<TRequest, TResponse>()
            where TRequest : IRequest<TResponse>
            {
                MediatR.Il2Cpp.HandlerStub.MakeStub<TRequest, TResponse>();
                new RequestPreProcessorBehavior<TRequest, TResponse>(null);
                new RequestPostProcessorBehavior<TRequest, TResponse>(null);
                new RequestExceptionProcessorBehavior<TRequest, TResponse>(null);
                new RequestExceptionActionProcessorBehavior<TRequest, TResponse>(null);
            }
        }


        private void Start()
        {
            _workingButton.onClick.AddListener(async () =>
            {
                try
                {
                    await _mediator.Send(new WorkingRequest()).ConfigureAwait(false);
                    await _dispatcher.InvokeAsync(() => _workingText.text = "Worked");
                }
                catch (Exception e)
                {
                    await LogMessage(e, _workingText);
                }
            });

            _notWorkingUnitButton.onClick.AddListener(async () =>
            {
                try
                {
                    await _mediator.Send(new NotWorkingUnitRequest()).ConfigureAwait(false);
                    await _dispatcher.InvokeAsync(() => _notWorkingUnitText.text = "Worked");
                }
                catch (Exception e)
                {
                    await LogMessage(e, _notWorkingUnitText);
                }
            });

            _notWorkingArrayButton.onClick.AddListener(async () =>
            {
                try
                {
                    await _mediator.Send(new NotWorkingArrayRequest()).ConfigureAwait(false);
                    await _dispatcher.InvokeAsync(() => _notWorkingArrayText.text = "Worked");
                }
                catch (Exception e)
                {
                    await LogMessage(e, _notWorkingArrayText);
                }
            });

            _notWorkingBoolButton.onClick.AddListener(async () =>
            {
                try
                {
                    await _mediator.Send(new NotWorkingBoolRequest()).ConfigureAwait(false);
                    await _dispatcher.InvokeAsync(() => _notWorkingBoolText.text = "Worked");
                }
                catch (Exception e)
                {
                    await LogMessage(e, _notWorkingBoolText);
                }
            });
        }

        private async Task LogMessage(Exception e, Text text)
        {
            await _dispatcher.InvokeAsync(() => text.text = e.Message);
            Debug.LogError(e);
        }
    }
}
