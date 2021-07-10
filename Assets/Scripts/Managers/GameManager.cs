using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake() {
        if(Instance!=null){
            Debug.LogError("GameManager重复实例");
            Destroy(gameObject);
            return;
        }
        Instance=this;
    }

}