using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void loadScene(string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}
