using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class RunAwayState : FSMState {
    private float patrolTime;
    private Vector3 targetDir;
    public override void Init () {
        stateID = FSMStateID.RunAway;
        //        throw new System.NotImplementedException();
    }
    public override void EnterState (FSMBase fsm) {
        fsm.m_speed = fsm.runAwaySpeed;
        fsm.animator.Play ("CarScare");
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Slow", true);

    }
    public override void ActionState (FSMBase fsm) {
        targetDir = fsm.transform.position - fsm.targetTF.position;
        fsm.MovePosition (targetDir + fsm.transform.position);
    }
    public override void ExitState (FSMBase fsm) {
        //停止移动
        fsm.StopPosition ();
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Slow", false);
    }
}