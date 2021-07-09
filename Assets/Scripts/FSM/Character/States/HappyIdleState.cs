using EveryFunc;
using UnityEngine;
using System;
public class HappyIdleState : FSMState
{
    private float idleTimer;
    public override void Init()
    {
        stateID = FSMStateID.HappyIdle;
        //        throw new System.NotImplementedException();
    }
    public override void EnterState(FSMBase fsm)
    {
        idleTimer = fsm.happyIdleTime;
    }
    public override void ActionState(FSMBase fsm)
    {
        fsm.happyIdleTime -= Time.deltaTime;
    }
    public override void ExitState(FSMBase fsm)
    {
        fsm.happyIdleTime = idleTimer;
    }
}