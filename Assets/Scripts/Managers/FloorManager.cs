using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [Header("References")]
    public SaveDataManager save;
    public UIManager ui;
    public PlayerBehavior player;

    [Header("Variables")]
    private int floorNumber;
    protected int maxFloorNumber;

    private void Start()
    {
        // Check for player pref data on set floor size (Default should return 5).
        maxFloorNumber = save.GetFloor();

        // Restart floor number in case of debug work
        floorNumber = 1;

        // Modify floor text
        ui.SetFloorText(floorNumber, maxFloorNumber);
    }

    public void DEBUGPrintFloor()
    {
        Debug.Log(floorNumber);
    }

    public void AddFloor(int num)
    {
        floorNumber += num;
        CheckFloor();
        ui.SetFloorText(floorNumber, maxFloorNumber);
    }

    public void CheckFloor()
    {
        if (floorNumber > maxFloorNumber)
        {
            Debug.Log("Floor maxed");
            player.GameOver();
        }
    }
}
