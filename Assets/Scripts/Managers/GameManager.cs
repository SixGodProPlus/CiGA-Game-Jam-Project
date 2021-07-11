using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    [Tooltip ("开始等待时间")]
    public float StartWaitTime = 2f;
    [Tooltip ("星星总数")]
    public int starNum = 0;
    [Tooltip ("纽扣总数")]
    public int gearNum = 0;
    [Tooltip ("油总量")]
    public float totalFuel = 50f;
    [Tooltip ("胜利音乐")]
    public AudioClip victoryClip;
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

    private float startTime;
    private float endTime;
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
        if (remainedFuel < 0) {
            Defeat ();
            remainedFuel = totalFuel;
        }
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
    public void AddGear (int addNum) {
        gearNum += addNum;
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
        startTime = Time.time;
        player.GetComponentInChildren<PlayerController> ().walkable = true;
        fireCar.GetComponentInChildren<FSMBase> ().walkAble = true;
    }
    //胜利
    public void Victory () {
        Debug.Log ("胜利");
        endTime = Time.time;
        player.GetComponent<AudioSource> ().clip = victoryClip;
        player.GetComponent<AudioSource> ().Play ();

        Time.timeScale = 0;
        var dialogPrefab = Resources.Load<GameObject> ("Prefabs/Utilities/VictoryDialog");
        var dialog = Instantiate<GameObject> (dialogPrefab, Vector3.zero, Quaternion.identity);
        GameObject.Find ("CoinText").GetComponent<Text> ().text = starNum.ToString ();
        GameObject.Find ("GearText").GetComponent<Text> ().text = (Mathf.RoundToInt ((remainedFuel / totalFuel) * 100)).ToString () + "%";
        int score = starNum + (int) remainedFuel + (int) (80 - (endTime - startTime));
        GameObject.Find ("TotalScore").GetComponent<Text> ().text = score.ToString();
    }
    IEnumerator countScore () {
//        int score = starNum + (int) remainedFuel + (int) (80 - (endTime - startTime)), currentScore = 0;
//        Text text = GameObject.Find ("TotalScore").GetComponent<Text> ();
        yield return null;
        /*         yield return new WaitForFixedUpdate ();
                while (currentScore < score) {
                    yield return new WaitForFixedUpdate ();
                    Debug.Log ("currentscore:" + currentScore);
                    currentScore++;
                    text.text = currentScore.ToString ();
                }
         */
    }
    public void Defeat () {
        Debug.Log ("失败");

        Time.timeScale = 0;
        var dialogPrefab = Resources.Load<GameObject> ("Prefabs/Utilities/DefeatDialog");
        var dialog = Instantiate<GameObject> (dialogPrefab, Vector3.zero, Quaternion.identity);
    }
}