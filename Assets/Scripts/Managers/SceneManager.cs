using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    AudioSource audioSource;
    public Transform[] aboutTransform;
    public float aboutSpeed;
    private Transform aboutTarget;
    private int aboutIndex;
    private void Awake () {
        audioSource = this.GetComponent<AudioSource> ();
        aboutTarget = this.transform.Find ("StageEntrance");
        aboutIndex = 0;
    }
    private void Update () {
        if (aboutTarget != null) {
            if (Vector3.Distance (aboutTarget.position, aboutTransform[aboutIndex].position) > 0.05f) {
                aboutTarget.position = Vector3.Lerp (aboutTarget.position, aboutTransform[aboutIndex].position, aboutSpeed * Time.deltaTime);
            }
        }
    }
    public void loadScene (string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene (name);
    }
    public void AboutUI () {
        aboutIndex = (aboutIndex + 1) % aboutTransform.Length;
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
    public void AudioPlay (AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play ();
    }
}