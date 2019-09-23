using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ManyouLoadingTask : BaseTask
{
    public ManyouLoadingTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<LoadingPanel>(WindowTypeEnum.Screen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<LoadingPanel>(WindowTypeEnum.Screen, UIPanelStateEnum.Hide);
    }
}
