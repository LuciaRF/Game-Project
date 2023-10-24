using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager> {
    [Header("Enemies")] public float timeBetweenEnemyGenerations = 6;
    public float enemySpawnMinDistance = 5;
    public float enemySpawnMaxDistance = 12;
    public float enemyDespawnDistance = 20;
    public GameObject enemyPrefab;

    protected List<Transform> _enemyTransforms;
    protected List<Transform> _enemiesToRemove;
    protected Transform _playerTransform;
    protected bool _isPlayerAlive = true;


    // Start is called before the first frame update
    void Awake() {
        _enemyTransforms = new List<Transform>();
        _enemiesToRemove = new List<Transform>();
        _playerTransform = Player.instance.transform;
    }

    private void Start() {
        PoolManager.instance.Load(enemyPrefab, 10);
        StartCoroutine(SpawnCoroutine(timeBetweenEnemyGenerations, enemySpawnMinDistance, enemySpawnMaxDistance,
            enemyPrefab));
        StartCoroutine(DespawnCoroutine());
    }

    // Update is called once per frame
    void Update() {
        if (_isPlayerAlive) {
            _isPlayerAlive = _playerTransform != null;
        } else if (Input.GetKeyDown(KeyCode.Space)) {

            SceneManager.LoadScene(0);
        }

    }

    public IEnumerator SpawnCoroutine(float waitTime, float minDist, float maxDist, GameObject prefab) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            var distanceToPlayer = Random.Range(minDist, maxDist);
            var randomVector = Random.onUnitSphere;
            randomVector.y = 0;
            if (!_isPlayerAlive) {
                break;
            }

            var position = _playerTransform.position;
            var spawnPosition = position + randomVector.normalized * distanceToPlayer;
            _enemyTransforms.Add(
                PoolManager.instance.Spawn(prefab, spawnPosition,
                    Quaternion.LookRotation(position - spawnPosition, Vector3.up)).transform
            );
        }
    }

    public IEnumerator DespawnCoroutine() {
        while (true) {
            
            if (!_isPlayerAlive) {
                break;
            }
            
            foreach (var enemyTransform in _enemyTransforms) {
                if (enemyTransform == null || Vector3.Distance(enemyTransform.position, _playerTransform.position) >=
                    enemyDespawnDistance) {
                    _enemiesToRemove.Add(enemyTransform);
                }
            }

            foreach (var enemyToRemove in _enemiesToRemove) {
                // Destruyo el enemigo
                _enemyTransforms.Remove(enemyToRemove);
                if (enemyToRemove != null) {
                    PoolManager.instance.Despawn(enemyToRemove.gameObject);
                }
            }

            _enemiesToRemove.Clear();
            yield return new WaitForSeconds(1);
        }
    }
}