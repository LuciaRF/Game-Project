using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _currentHealth; 
    private Material _mat;
    private bool invulnerable;


    public int maxHealth => _maxHealth;
    public int currentHealth => _currentHealth;
    public float invulnerabilityDuration = 1;
    public bool IsAlive => _currentHealth > 0;

    private void Awake() {
        _mat = GetComponentInChildren<MeshRenderer>().material;
    }

    private void OnEnable() {
        _currentHealth = _maxHealth;
        _mat.color = Color.white;
        invulnerable = false;
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    public void TakeDamage(int amount) {
        if (invulnerable) {
            return;
        }

        StartCoroutine(InvulnerabilityCoroutine());
        _currentHealth -= amount;
        if (_currentHealth <= 0) {
            Destroy(gameObject);
        } else {
            _mat
                .DOColor(Color.red, .05f).SetLoops(10, LoopType.Yoyo)
                .OnComplete(() => _mat.color = currentHealth/(float)maxHealth * Color.white);
        }
    }

    IEnumerator InvulnerabilityCoroutine() {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        invulnerable = false;
    }

}
