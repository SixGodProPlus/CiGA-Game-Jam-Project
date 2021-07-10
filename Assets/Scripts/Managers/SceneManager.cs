using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    public void loadScene (string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene (name);
    }

    public void reloadCurScene () {
        UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name);
    }

    public void destoryCurGameObj () {
        Destroy (gameObject);
    }

    public void setTimeScale (float scale) {
        Time.timeScale = scale;
    }
    public void ExitGame () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}