using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShootOnSight))]
public class ScaleDamageWithTime : MonoBehaviour {
    public float iterationTime = 1;
    private ShootOnSight _shootOnSight;
    // Start is called before the first frame update
    void Awake() {
        _shootOnSight = GetComponent<ShootOnSight>();
    }

    private void Start() {
        StartCoroutine(ScaleDamageCoroutine());
    }

    // Update is called once per frame
    private IEnumerator ScaleDamageCoroutine()
    {
        while (true) {
            yield return new WaitForSeconds(iterationTime);
            _shootOnSight.bulletDamage++;
        }
    }
}
