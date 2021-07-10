using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
//状态机基类
public abstract class FSMBase : MonoBehaviour {
    [Header ("公开变量")]
    [Tooltip ("默认状态编号")]
    public FSMStateID DefaultStateID;
    [Tooltip ("移动速度")]
    public float walkSpeed;
    [Tooltip ("追击速度")]
    public float lowchaseSpeed;
    [Tooltip ("超级追击速度")]
    public float highchaseSpeed;
    [Tooltip ("移动时间")]
    public float patrolTime;
    [Tooltip ("发现物品时的半径")]
    public float findRadius;
    [Tooltip ("告诉追击时的半径")]
    public float highChaseRadius;
    //只要一个圆形半径就好了 
    [Tooltip ("抓到物品时的半径")]
    public float getRadius;
    /*     [Tooltip("发现玩家的扇形半径")]
        public float sectorRadius;
        [Tooltip("发现玩家的扇形角度")]
        public float sectorAngle;
     */
    [Tooltip ("普通待机时长")]
    public float idleTime;
    [Tooltip ("开心待机时长")]
    public float happyIdleTime;

    [Header ("私有变量")]
    //移动方向
    [HideInInspector]
    public Vector3 moveVelocity;

    //TODO:是否需要给敌人设置一个巡逻范围：只会在巡逻范围内随机选择点来巡逻
    /*     [Tooltip("巡逻范围,以左下点和右上点为主")]
        public Transform[] patrolTFs; */
    //状态列表
    protected List<FSMState> statesList;

    //当前状态
    protected FSMState currentState;
    public FSMStateID testState;
    //默认状态
    protected FSMState defaultState;
    //    public FSMStateID currentID;
    [HideInInspector]
    public Rigidbody2D rb;
    //原有的质量
    [HideInInspector]
    public float originalMass;
    private SpriteRenderer sprite;
    //子物体获取（贴图为主）
    private Transform childTF;
    //追击目标
    [HideInInspector]
    public Transform targetTF;
    [HideInInspector]
    public bool walkAble;
    [HideInInspector]
    public float m_speed;
    //是否受伤
    [HideInInspector]
    public bool isHurted;
    private void Awake () {
        Init ();
    }
    //初始化怪物数据
    private void Init () {
        //初始化Component的东西
        InitComponent ();
        //配置状态机
        ConfigFSM ();
        //查找默认状态：默认状态初始化
        InitDefaultState ();
    }

    /*     private void Reset()
        {
            statesList.Clear();
        }
     */
    public virtual void InitComponent () {
        rb = GetComponent<Rigidbody2D> ();
        childTF = this.transform.Find ("SelfSprite");
        sprite = childTF.GetComponent<SpriteRenderer> ();
        walkAble = true;
        isHurted = false;
        targetTF = null;
        originalMass = rb.mass;
        /*  //动画机
        animator = GetComponentInChildren<Animator> ();
        //角色数值
        characterStatus = GetComponent<CharacterStatus> ();
        //初始化位置
        startPosition = transform.position;
        //初始化技能管理器
        skillSystem = GetComponent<CharacterSkillSystem> (); */
    }
    public void InitDefaultState () {
        defaultState = statesList.Find (s => s.stateID == DefaultStateID);
        currentState = defaultState;
        currentState.EnterState (this);
    }
    //配置状态机
    //根据人物状态需要设置状态机
    public abstract void ConfigFSM ();
    //--创建状态对象
    //--设置状态(AddMap)

    //每帧处理的逻辑
    public virtual void Update () {
        testState = currentState.stateID;
        //检测是否被攻击了，被攻击就放大搜索圈
        //HurtedSearch ();
        //TODO:侦测周围是否有敌人
        DetectTarget ();
        //每帧判断条件，如果有条件满足了就切换状态
        //判断当前状态条件
        currentState.DetectTriggers (this);
        //执行当前逻辑
        currentState.ActionState (this);
        //贴图翻转
        textureClip ();
    }
    public virtual void FixedUpdate () {
        if (walkAble) {
            //移动
            rb.velocity = moveVelocity * m_speed * Time.fixedDeltaTime * ConstantList.speedPer;

            /* if (Vector3.Distance (transform.position, movePos) > 0.05f) {
                Vector3 dir = (movePos - this.transform.position).normalized;
                rb.velocity = dir * m_speed;
            } */
        }
    }

    //切换状态
    public void ChangeActiveState (FSMStateID stateID) {
        //更新当前状态
        //退出当前状态
        //               Debug.Log ("change state:" + currentState.stateID.ToString () + " to " + stateID.ToString ());
        currentState.ExitState (this);
        //切换状态
        //如果需要切换的状态编号是 Default 就直接返回默认状态,否则返回查找的状态
        currentState = stateID == FSMStateID.Default ? defaultState : statesList.Find (s => s.stateID == stateID);
        //进入下一个状态
        currentState.EnterState (this);
    }
    /// <summary>
    /// 检测目标
    /// </summary>
    private void DetectTarget () {
        var targetArray = Physics2D.OverlapCircleAll (this.transform.position, findRadius);
        foreach (var target in targetArray) {
            if (target.CompareTag ("MyLove")) {
                targetTF = target.transform;
                break;
            }
        }
    }
    /// <summary>
    /// 贴图翻转
    /// </summary>
    private void textureClip () {
        if (rb.velocity.x > 0.05f) {
            sprite.flipX = false;
        } else if (rb.velocity.x < -0.05f) {
            sprite.flipX = true;
        }
    }
    /// <summary>
    /// 移动位置
    /// </summary>
    /// <param name="dirPos"></param>
    public void MovePosition (Vector3 dirPos) {
        moveVelocity = (dirPos - this.transform.position).normalized;
        //Debug.Log("moveVelocity:"+moveVelocity);
    }
    public void StopPosition () {
        moveVelocity = Vector3.zero;
    }
    //自身检测
    private void OnTriggerEnter2D (Collider2D other) {
        /*         if(other.CompareTag("myLove")){
                    other.gameObject.SetActive(false);
                }
         */

    }
}