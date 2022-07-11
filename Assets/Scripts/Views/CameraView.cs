using Cinemachine;
using UnityEngine;

public class CameraView : LinkableView
{
    public Animator CameraAnimator;
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    private static readonly int PlayStage = Animator.StringToHash("PlayStage");
    private static readonly int LevelCompletedStage = Animator.StringToHash("LevelCompletedStage");

    public void SetTarget(Transform target)
    {
        CinemachineVirtualCamera.Follow = target;
    }

    public void SetStage(IGameStage stage)
    {
        if (stage is StagePlay)
        {
            CameraAnimator.SetTrigger(PlayStage);
        }
        
        if (stage is StageLevelCompleted)
        {
            CameraAnimator.SetTrigger(LevelCompletedStage);
        }
    }
}