using System.Collections;
using Cinemachine;
using UnityEngine;
public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    [Tooltip ("开始等待时间")]
    public float StartWaitTime = 2f;
    [Tooltip ("星星总数")]
    public int starNum = 0;
    [Tooltip ("油总量")]
    public float totalFuel = 50f;
    [Tooltip ("胜利音乐")]
    public AudioClip victoryClip;
    [Tooltip ("bgm音乐")]
    public AudioClip bgmClip;
    //剩余燃料
    [HideInInspector]
    public float remainedFuel;
    //玩家
    [HideInInspector]
    public GameObject playerWithFireCar;
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject fireCar;
    private void Awake () {
        if (Instance != null) {
            Debug.LogError ("GameManager重复实例");
            Destroy (gameObject);
            return;
        }
        Instance = this;
        InitComponent ();
    }
    private void Update () {
        if (remainedFuel > 0)
            remainedFuel -= Time.deltaTime;
    }
    private void InitComponent () {
        remainedFuel = totalFuel;
        playerWithFireCar = GameObject.Find ("PlayerWithFireCar");
        player = playerWithFireCar.transform.Find ("Player").gameObject;
        fireCar = playerWithFireCar.transform.Find ("FireCar").gameObject;
        StartGame ();
    }
    public void SupplyFuel (float buff) {
        remainedFuel = Mathf.Clamp (remainedFuel + buff, 0, totalFuel);
    }
    public void AddStar (int addNum) {
        starNum += addNum;
    }
    //开始游戏
    public void StartGame () {
        /*         player = Resources.Load<GameObject> ("Prefabs/PlayerWithFireCar");
                player = GameObject.Instantiate (player, StartPos.position, Quaternion.identity); */
        player.GetComponent<PlayerController> ().walkable = false;
        fireCar.GetComponent<FSMBase> ().walkAble = false;
        StartCoroutine (StartWalkable ());
    }
    IEnumerator StartWalkable () {
        yield return new WaitForSeconds (StartWaitTime);
        Debug.Log ("开始游戏");
        player.GetComponentInChildren<PlayerController> ().walkable = true;
        fireCar.GetComponentInChildren<FSMBase> ().walkAble = true;
    }
    //胜利
    public void Victory () {
        Debug.Log ("胜利");
        player.GetComponent<AudioSource> ().clip = victoryClip;
        player.GetComponent<AudioSource> ().Play ();
    }
}