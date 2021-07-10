using UnityEngine;
public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public float remained_Fuel = 5f;
    private void Awake () {
        if (Instance != null) {
            Debug.LogError ("GameManager重复实例");
            Destroy (gameObject);
            return;
        }
        Instance = this;
    }
    private void Update () {
        if (remained_Fuel > 0)
            remained_Fuel -= Time.deltaTime;
    }

}