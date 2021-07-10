using UnityEngine;
public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    [Tooltip ("星星总数")]
    public int starNum = 0;
    [Tooltip ("油总量")]
    public float totalFuel = 50f;
    //剩余燃料
    public float remainedFuel;
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
    }
    public void SupplyFuel (float buff) {
        remainedFuel = Mathf.Clamp (remainedFuel + buff, 0, totalFuel);
    }
    public void AddStar (int addNum) {
        starNum += addNum;
    }
}