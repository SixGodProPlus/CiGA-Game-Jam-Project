using System.Collections.Generic;

namespace EveryFunc.FSM {
    public class UIFSM : FSMBase {
        public override void ConfigFSM () {
            if (statesList != null) return;
            statesList = new List<FSMState> ();
            //创建状态对象
            FSMState idle = new IdleState ();
            FSMState patrol = new UIPatrolState ();
            //idle的映射
            idle.addMap (FSMTriggerID.IdleDone, FSMStateID.UIPatrol);
            //patrol的映射
            patrol.addMap (FSMTriggerID.PatrolDone, FSMStateID.Idle);
            //加入状态机
            statesList.Add (idle);
            statesList.Add (patrol);

        }
    }
}