using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehvaior : MonoBehaviour
{
    [Header("References")]
    private AbstractDungeonGenerator generator;
    private FloorManager floorManager;

    private void Awake()
    {
        generator =
            GameObject.Find("RoomsFirstDungeonGenerator").GetComponent<AbstractDungeonGenerator>();
        floorManager =
            GameObject.Find("GameManager").GetComponent<FloorManager>();
    }

    public void ExitTriggered()
    {
        floorManager.AddFloor(1);
        generator.GenerateDungeon();
    }
}
