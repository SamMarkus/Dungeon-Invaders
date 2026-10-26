using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPrefabs : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float offsetX = 0.5f;
    [SerializeField] private float offsetY = 0.5f;

    [Header("Prefabs")]
    [SerializeField] private GameObject entrance;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject[] treasure;
    [SerializeField] private GameObject[] enemy;

    [Header("Spawn Coordinates")]
    private HashSet<Vector2Int> spawnPositions; 

    public void Place (HashSet<Vector2Int> coordinates)
    {
        spawnPositions = coordinates;

        SingleSpawn(entrance);
        SingleSpawn(exit);
        FillSpawn();
    }

    public void ClearAll()
    {
        Clear("Entrance");
        Clear("Exit");
        Clear("Enemy");
        Clear("Treasure");
    }

    private void Clear (string gameObjectTag)
    {
        foreach (var gameObject in GameObject.FindGameObjectsWithTag(gameObjectTag))
        {
            if (Application.isPlaying)
                Destroy(gameObject);
            else
                DestroyImmediate(gameObject);
        }
    }

    private void SingleSpawn(GameObject gameObject)
    {
        int randomElement = Random.Range(0, spawnPositions.Count);
        SpawnObject(gameObject, spawnPositions.ElementAt(randomElement));
        spawnPositions.Remove(spawnPositions.ElementAt(randomElement));
    }

    private void FillSpawn()
    {
        int openSpaces = spawnPositions.Count; 
        for (int i = 0; i < openSpaces; i++)
        {
            if (Random.Range(0, 3) == 0)
                SpawnFromList(treasure);
            else
                SpawnFromList(enemy);
        }
        
    }

    private void SpawnFromList(GameObject[] gameObjects)
    {
        int randomObject = Random.Range(0, gameObjects.Length);
        SingleSpawn(gameObjects[randomObject]);
    }

    private void SpawnObject(GameObject gameObject, Vector2Int spawnPosition)
    {
        Vector3 position = ((Vector3Int)spawnPosition);
        position = new Vector3(position.x + offsetX, position.y + offsetY, position.z);
        Instantiate(gameObject, position, Quaternion.identity);
    }
}
