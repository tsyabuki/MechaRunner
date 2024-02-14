using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _defaultSpawnedObjectSpeed;
    [SerializeField] private List<SpawnData> _phase1SpawnList;
    [Header("Fill references")]
    [SerializeField] private GameManagerFSM _gmFSM;

    private void Awake()
    {
        _gmFSM.spawnObstacle += SpawnObstacle;
    }

    private void Start()
    {
        SpawnObstacle(1);
    }

    private void OnDestroy()
    {
        _gmFSM.spawnObstacle -= SpawnObstacle;
    }

    /// <summary>
    /// Spawns an obstacle when sent an event by the game manager.
    /// </summary>
    /// <param name="phase">Currently does nothing. If I want to make spawns phase dependent, then I'll add that functionality here</param>
    private void SpawnObstacle(int phase)
    {
        //Select a random object from the spawn list and spawn it
        int _selectedObstacle = Random.Range(0, _phase1SpawnList.Count);
        GameObject SpawnedObstacleGO = Instantiate(_phase1SpawnList[_selectedObstacle].spawnObject, transform.position + new Vector3(_phase1SpawnList[_selectedObstacle].spawnPositionHorizontal, 0f, 0f), Quaternion.identity);
        Obstacle SpawnedObstacleClass = SpawnedObstacleGO.GetComponent<Obstacle>();
        SpawnedObstacleClass.speed = _defaultSpawnedObjectSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
