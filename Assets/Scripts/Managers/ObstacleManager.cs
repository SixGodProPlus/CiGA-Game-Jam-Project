// ! Deprecated

using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    [Tooltip("玩家位置")]
    public Transform playerPos;
    [Tooltip("可选生成坐标")]
    public Transform[] points;
    [Tooltip("道具生成间隔/ms")]
    public float propsGenInterval;
    [Tooltip("每次生成数量")]
    public int countPerTime;

    [Tooltip("道具刷新位置与玩家的最大距离")]
    public float maxDistanceToPlayer;

    [Tooltip("允许同一位置重复生成道具")]
    public bool allowReGenAtSamePos = false;

    [Tooltip("道具列表(填写路径)")]
    public string[] propPathList;

    private List<int> validPosition;
    private List<bool> posUsed;
    private float timePassed = 0;
    private List<GameObject> propPrefabList;

    void Start()
    {
        for (int i = 0; i < points.Length; ++i)
            posUsed.Add(false);

        foreach (var str in propPathList)
            propPrefabList.Add(Resources.Load<GameObject>(str));
    }

    private void GenProps() {
        timePassed += Time.deltaTime;

        // have not reached generate time
        if (timePassed < propsGenInterval)
            return;
        
        // reset timer
        timePassed = 0;

        // check position validity
        for (int i = 0; i < points.Length; ++i)
            if ((allowReGenAtSamePos || !posUsed[i]) && Vector3.Distance(points[i].position, playerPos.position) < maxDistanceToPlayer)
                validPosition.Add(i);
        
        for (int i = 0; i < countPerTime; ++i) {
            int positionID = UnityEngine.Random.Range(0, validPosition.Count);
            int propID = UnityEngine.Random.Range(0, propPathList.Length);

            var newProp = Instantiate<GameObject>(propPrefabList[propID], points[validPosition[positionID]].position, Quaternion.identity);

            // ! unfinished
            if (!allowReGenAtSamePos) {
                posUsed[validPosition[positionID]] = true;
                validPosition.Remove(positionID);
            }
        }
    }

    void Update()
    {
        GenProps();
    }
}
