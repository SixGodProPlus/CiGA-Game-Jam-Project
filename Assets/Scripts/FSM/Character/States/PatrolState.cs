using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PatrolState : FSMState {
    private float patrolTime;
    private Vector3 targetDir;
    public override void Init () {
        stateID = FSMStateID.Patrol;
        //        throw new System.NotImplementedException();
    }
    public override void EnterState (FSMBase fsm) {
        fsm.m_speed = fsm.walkSpeed;
        fsm.animator.Play ("CarIdle");
        //获取随即方向
        targetDir = EveryFunction.GetRandomDir ();
        patrolTime = fsm.patrolTime;
        //是否完成巡逻
    }
    public override void ActionState (FSMBase fsm) {
        fsm.MovePosition (targetDir + fsm.transform.position);
        fsm.patrolTime -= Time.deltaTime;
    }
    public override void ExitState (FSMBase fsm) {
        //停止移动
        fsm.StopPosition ();
        fsm.patrolTime = patrolTime;
        //fsm.isDonePatrol = false;
        //      fsm.walkAble=false;
    }
}