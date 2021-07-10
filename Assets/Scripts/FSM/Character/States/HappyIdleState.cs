using System;
using EveryFunc;
using UnityEngine;
public class HappyIdleState : FSMState {
    private float idleTimer;
    private float maxMass = 200;
    public override void Init () {
        stateID = FSMStateID.HappyIdle;
        //        throw new System.NotImplementedException();
    }
    public override void EnterState (FSMBase fsm) {
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Dragged", true);
        idleTimer = fsm.happyIdleTime;
        fsm.rb.mass = maxMass;
    }
    public override void ActionState (FSMBase fsm) {
        fsm.happyIdleTime -= Time.deltaTime;
        if (fsm.happyIdleTime <= 0 && fsm.targetTF != null) GameObject.Destroy (fsm.targetTF.gameObject);
    }
    public override void ExitState (FSMBase fsm) {
        GameManager.Instance.player.GetComponentInChildren<Animator> ().SetBool ("Dragged", false);
        fsm.happyIdleTime = idleTimer;
        fsm.rb.mass = fsm.originalMass;
    }
}