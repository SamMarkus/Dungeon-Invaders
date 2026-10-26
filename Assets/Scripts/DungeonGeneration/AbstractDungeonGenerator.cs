using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using NavMeshPlus.Components;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [Header("Abstract Dungeon Generator")]
    [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField] protected SpawnPrefabs spawnPrefabs = null;
    [SerializeField] protected NavMeshSurface Surface2D;

    protected HashSet<Vector2Int> spawnCoords = new HashSet<Vector2Int>();
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        tilemapVisualizer.Clear();
        spawnPrefabs.ClearAll();
        RunProceduralGeneration();
        Surface2D.BuildNavMeshAsync();
        spawnPrefabs.Place(spawnCoords);
    }

    public void ClearDungeon()
    {
        tilemapVisualizer.Clear();
        Surface2D.BuildNavMeshAsync();
        spawnPrefabs.ClearAll();
    }

    protected abstract void RunProceduralGeneration();
}
