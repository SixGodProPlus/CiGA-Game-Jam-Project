using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void loadScene(string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void reloadCurScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void destoryCurGameObj() {
        Destroy(gameObject);
    }

    public void setTimeScale(float scale) {
        Time.timeScale = scale;
    }
}
