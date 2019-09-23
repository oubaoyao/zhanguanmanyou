using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class Scenes01Task : BaseTask
{
    public Scenes01Task(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<Scenes01Panel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<Scenes01Panel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
