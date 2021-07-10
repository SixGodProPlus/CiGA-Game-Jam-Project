using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public static UIManager Instance;
    private void Awake () {
        if (Instance != null) {
            Debug.LogError ("UIManager重复实例");
            Destroy (gameObject);
            return;
        }
        Instance = this;
    }
    public Text coinText;
    public Image fuelImage;
    public Image fuelTrainImage;
    public Transform trainLeftPos;
    public Transform trainRightPos;
    public float distance;
    public float per;
    private void Start () {
        InitComponent ();
        UpdateCoinUI ();
        UpdateFuelUI ();
    }
    private void Update () {
        UpdateCoinUI ();
        UpdateFuelUI();
    }
    private void InitComponent () {
        distance = trainRightPos.position.x - trainLeftPos.position.x;
    }
    private void UpdateCoinUI () {
        coinText.text = GameManager.Instance.starNum.ToString ();
    }
    private void UpdateFuelUI () {
        per = GameManager.Instance.remainedFuel / GameManager.Instance.totalFuel;
        fuelImage.fillAmount = per;
        fuelTrainImage.transform.position = trainLeftPos.position + (Vector3.right * per * distance);
    }
}