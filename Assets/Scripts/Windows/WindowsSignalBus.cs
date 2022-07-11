using UniRx;
using Zenject;

public class WindowsSignalBus : IInitializable
{
    [Inject] private IGameStageService _gameStage;
    [Inject] private SignalBus _signalBus;
    [Inject] private SceneData _sceneData;

    public void Initialize()
    {
        _signalBus.GetStream<InputEvent>().Subscribe(x =>
        {
            
        }).AddTo(_sceneData);
    }
}