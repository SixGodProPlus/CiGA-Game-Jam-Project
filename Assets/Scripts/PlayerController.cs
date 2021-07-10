using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EveryFunc;
public class PlayerController : MonoBehaviour
{
    [Tooltip("玩家Rigidbody2D")]
    public Rigidbody2D playerRigidbody;

    [Tooltip("玩家默认速度")]
    public float defaultSpeed;

    void Start()
    {
    }

    void Update()
    {
        Vector2 speed = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRigidbody.velocity = speed * defaultSpeed * Time.fixedDeltaTime * ConstantList.speedPer;
    }
}