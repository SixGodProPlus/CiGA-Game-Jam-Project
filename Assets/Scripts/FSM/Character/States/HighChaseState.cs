using System;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class HighChaseState : FSMState {
    //FIXME:人物撞墙，追击状态有点问题
    private List<PathNode> pathList;
    private Vector3 nextPos;
    public override void Init () {
        stateID = FSMStateID.HighChase;
        //        throw new System.NotImplementedException();
    }
    public override void EnterState (FSMBase fsm) {
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Dragged", true);
        //fsm.isDoneChase = false;
        fsm.m_speed = fsm.highchaseSpeed;
        pathList = GridManager.Instance.FindPath (fsm.transform.position, fsm.targetTF.position);
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
        pathList = GridManager.Instance.FindPath (fsm.transform.position, fsm.targetTF.position);
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
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Dragged", false);
        //fsm.isDoneChase = false;
        fsm.StopPosition ();
    }
}