using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    [Tooltip("初始关节数量"), Range(2, 16)]
    public int startJointCount;
    
    [Tooltip("链接端A")]
    public SpriteRenderer anchorA;
    
    [Tooltip("链接端B")]
    public SpriteRenderer anchorB;

    private GameObject chainJointHeadPrefab, chainJointPrefab;
    private List<Sprite> jointList;
    private int curJointCount;

    void Start()
    {
        curJointCount = 0;
        
        // 加载关节
        chainJointHeadPrefab = Resources.Load<GameObject>("Prefabs/chainJointHead");
        chainJointPrefab = Resources.Load<GameObject>("Prefabs/chainJointPrefab");

        // 添加首个节点
        // var chainJoint = Instantiate(chainJointHeadPrefab, anchorA.transform.position + )
    }

    public void addJoint(int count) {

    }
}
