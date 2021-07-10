using System;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class LowChaseState : FSMState {
    //FIXME:人物撞墙，追击状态有点问题
    private List<PathNode> pathList;
    private Vector3 nextPos;
    private Transform target;
    public override void Init () {
        stateID = FSMStateID.LowChase;
        //        throw new System.NotImplementedException();
    }
    public override void EnterState (FSMBase fsm) {
        //fsm.isDoneChase = false;
        fsm.animator.Play("CarLove");
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Slow", true);
        fsm.m_speed = fsm.lowchaseSpeed;
        target = fsm.targetTF;
        pathList = GridManager.Instance.FindPath (fsm.transform.position, target.position);
        if (pathList == null) return;
        if (pathList.Count > 1) {
            nextPos = GridManager.Instance.GetWorldCenterPosition (pathList[1].x, pathList[1].y);
            fsm.MovePosition (nextPos);
        }
        /*  else {
                    fsm.isDoneChase = true;
                }
         */
    }
    public override void ActionState (FSMBase fsm) {
        //如果到达位置
        pathList = GridManager.Instance.FindPath (fsm.transform.position, target.position);
        //没有方法抵达
        if (pathList == null) {
            fsm.StopPosition ();
            return;
        }
        if (pathList.Count <= 1) {
            //fsm.isDoneChase = true;
            return;
        }
        nextPos = GridManager.Instance.GetWorldCenterPosition (pathList[1].x, pathList[1].y);
        fsm.MovePosition (nextPos);
    }
    public override void ExitState (FSMBase fsm) {
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Slow", false);
        //fsm.isDoneChase = false;
        fsm.StopPosition ();
    }
}