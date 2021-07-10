using UnityEngine;

public class Star : ItemAction {
    [Tooltip ("增加星星数")]
    public int addStarNum = 1;
    public override void Action () {
        GameManager.Instance.AddStar (addStarNum);
        Destroy (gameObject);
    }
}