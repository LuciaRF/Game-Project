using UnityEngine;
using DG.Tweening;

public class ScaleWithTime : MonoBehaviour {
    public Vector3 targetScale = Vector3.one * 2;
    public float timeToScale = 3;
    // Start is called before the first frame update
    void Start() {
        transform.DOScale(targetScale, timeToScale);
    }
}
