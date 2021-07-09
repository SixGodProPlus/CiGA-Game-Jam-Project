using System.Collections.Generic;

namespace EveryFunc.FSM
{
    public class NormalEnemyFSM : FSMBase
    {
        public override void ConfigFSM()
        {
            if (statesList != null) return;
            statesList = new List<FSMState>();
            //创建状态对象
            FSMState idle = new IdleState();
            FSMState patrol = new PatrolState();
            FSMState lowChase = new LowChaseState();
            FSMState highChase = new HighChaseState();
            FSMState happyIdle = new HappyIdleState();
            //添加映射(AddMap) 
            //idle的映射
            idle.addMap(FSMTriggerID.IdleDone, FSMStateID.Patrol);
            idle.addMap(FSMTriggerID.TargetFound, FSMStateID.LowChase);

            //patrol的映射
            patrol.addMap(FSMTriggerID.PatrolDone, FSMStateID.Idle);
            patrol.addMap(FSMTriggerID.TargetFound, FSMStateID.LowChase);

            //lowChase的映射
            lowChase.addMap(FSMTriggerID.TargetCloser, FSMStateID.HighChase);
            lowChase.addMap(FSMTriggerID.TargetLost, FSMStateID.Idle);

            //highChase的映射
            highChase.addMap(FSMTriggerID.TargetGet, FSMStateID.HappyIdle);
            highChase.addMap(FSMTriggerID.TargetFarAway, FSMStateID.LowChase);

            //happyIdle的映射
            happyIdle.addMap(FSMTriggerID.HappyIdleDone, FSMStateID.Patrol);

            //加入状态机
            statesList.Add(idle);
            statesList.Add(patrol);
            statesList.Add(lowChase);
            statesList.Add(highChase);
            statesList.Add(happyIdle);

        }
    }
}