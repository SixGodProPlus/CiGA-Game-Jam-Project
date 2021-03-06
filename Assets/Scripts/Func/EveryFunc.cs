using UnityEngine;

namespace EveryFunc {
    public enum FSMStateID {
        Default,
        Idle,
        HappyIdle,
        Patrol,
        UIPatrol,
        LowChase,
        HighChase,
        Dead,
        RunAway
    }
    public enum FSMTriggerID {
        FindScare,
        IdleDone,
        HappyIdleDone,
        PatrolDone,
        TargetFoundLove,
        TargetCloserLove,
        TargetFarAwayLove,
        TargetLostLove,
        TargetGetLove,
        TargetFoundHate,
        TargetLostHate,
    }
    /// <summary>
    /// 常量列表
    /// </summary>
    public static class ConstantList {
        [Tooltip ("y方向移动偏斜值")]
        public static float moveYPer = 1f;
        [Tooltip ("速度偏斜")]
        public static float speedPer = 50f;
        [Tooltip ("重力加速度")]
        public static float g = -20f;
        [Tooltip ("受击时间")]
        public static float HurtedTime = 0.2f;
    }
    /// <summary>
    /// 通用方法
    /// </summary>
    public static class EveryFunction {
        //默认排序
        private static int sortingOrder = 1;
        /// <summary>
        /// 在Scene中创造文字
        /// </summary>
        /// <param name="text">文字</param>
        /// <param name="parent">父对象</param>
        /// <param name="localPosition">位置</param>
        /// <param name="fontsize">字体大小</param>
        /// <param name="color">字体颜色</param>
        /// <param name="textAnchor"></param>
        /// <param name="textAlignment"></param>
        /// <returns></returns>
        public static TextMesh CreateWorldText (string text, Transform parent = null, Vector3 localPosition = default (Vector3), int fontsize = 35, Color color = default (Color), TextAnchor textAnchor = default (TextAnchor), TextAlignment textAlignment = default (TextAlignment)) {
            if (color == null) color = Color.white;
            return CreateWorldText (parent, text, localPosition, fontsize, color, textAnchor, textAlignment);
        }
        public static Vector3 GetRandomDir () { //随机方向的单位向量（Vector3）
            return new Vector3 (UnityEngine.Random.Range (-1f, 1f), UnityEngine.Random.Range (-1f, 1f)).normalized;
        }
        public static TextMesh CreateWorldText (Transform parent, string text, Vector3 localPosition, int fontsize, Color color, TextAnchor textAnchor, TextAlignment textAlignment) {
            GameObject gameObject = new GameObject ("World Text", typeof (TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent (parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh> ();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontsize;
            textMesh.color = color;
            textMesh.characterSize = 0.1f;
            textMesh.GetComponent<MeshRenderer> ().sortingOrder = sortingOrder + 100;
            //gameObject.AddComponent<BoxCollider2D>().size = new Vector2(GridManager.Instance.cellsize / 2, GridManager.Instance.cellsize / 2);
            //gameObject.tag = "Ground";
            return textMesh;
        }
    }
}