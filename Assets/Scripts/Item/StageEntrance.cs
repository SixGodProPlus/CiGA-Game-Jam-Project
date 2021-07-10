using UnityEngine;
using Tween;

public class StageEntrance : ItemAction {
  [Tooltip("接触时缩放"), Range(1.0f, 2.0f)]
  public float scale;
  [Tooltip("接触持续时间/s")]
  public float duration;
  [Tooltip("关卡场景名")]
  public string stageSceneName;
  
  private bool onTrigger;

  void Start() {
    onTrigger = false;
  }

  void Update() {
    if (onTrigger && Input.GetKey(KeyCode.Return)) {
      this.gameObject.transform.TnStop();
      UnityEngine.SceneManagement.SceneManager.LoadScene(stageSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
  }
  public override void Action() {
    onTrigger = true;
    this.gameObject.transform.TnScale(new Vector3(scale, scale, scale), duration);
    // this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, new Vector3(scale, scale, scale), Time.deltaTime);
  }

  public override void ExitAction() {
    onTrigger = false;
    this.gameObject.transform.TnScale(new Vector3(1, 1, 1), duration);
  }
}