using UnityEngine;
using DG.Tweening;

public class ExplodeAfterTimeElapsed : MonoBehaviour
{
    public float timeToWait = 1;
    public float finalScale = 2;
    public float explosionRadius = 4;
    public LayerMask targetLayers;
    static int numberDeath = 0;

    private Transform _transform;

    private void Awake() {
        _transform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start() {
        _transform.DOScale(finalScale, timeToWait).SetEase(Ease.OutBack);
        GetComponent<MeshRenderer>().material.DOColor(Color.red, timeToWait).SetEase(Ease.OutCirc).OnComplete(Explode);
    }
    
    void Explode() {
        var hits = Physics.SphereCastAll(_transform.position, explosionRadius, Vector3.up, explosionRadius, targetLayers);

        foreach (var hit in hits) {
            var health = hit.collider.GetComponent<Health>();
            if (health) {
                health.TakeDamage(health.currentHealth);
                numberDeath++;
                Debug.Log("Llevas las siguientes muertes: "+numberDeath);
            }
        }
        Destroy(gameObject);
    }
}
