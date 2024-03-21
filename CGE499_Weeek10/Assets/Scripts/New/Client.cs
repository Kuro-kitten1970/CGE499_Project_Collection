using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private int _currentGameMode = 0;

    private GameObject _enemy;
    private List<IBehavior> _components = new List<IBehavior>();

    private void SpawnEnemy()
    {
        _enemy= GameObject.CreatePrimitive(PrimitiveType.Cube);

        _enemy.AddComponent<Enemy>();

        ApplyStrategies();
    }

    private void ApplyStrategies()
    {
        _components.Add(_enemy.AddComponent<SleepBehavior>());
        _components.Add(_enemy.AddComponent<PatrolBehavior>());
        _components.Add(_enemy.AddComponent<SearchDestroyBehavior>());

        _enemy.GetComponent<Enemy>().ApplyStrategy(_components[_currentGameMode]);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Easy"))
        {
            _currentGameMode = 0;
        }
        if (GUILayout.Button("Normal"))
        {
            _currentGameMode = 1;
        }
        if (GUILayout.Button("Hard"))
        {
            _currentGameMode = 2;
        }

        if (GUILayout.Button("Spawn Enemy"))
        {
            SpawnEnemy();
        }
    }
}
