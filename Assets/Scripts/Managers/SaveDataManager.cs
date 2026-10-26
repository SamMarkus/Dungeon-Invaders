using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SaveDataManager : MonoBehaviour
{
    private int floorLimit;


    private void Start()
    {
        floorLimit = GetFloor();
    }

    public void SetFloorLimit(int floor)
    {
        floorLimit = floor;
        PlayerPrefs.SetInt("Floor", floor);
        PlayerPrefs.Save();
    }

    public int GetFloor()
    {
        if (PlayerPrefs.HasKey("Floor"))
            return PlayerPrefs.GetInt("Floor");
        else
            return 5;
    }

    public void SetMoney(int amount)
    {
        PlayerPrefs.SetInt("Money", amount);
        PlayerPrefs.Save();
    }
    
    public int GetMoney()
    {
        if (PlayerPrefs.HasKey("Money"))
            return PlayerPrefs.GetInt("Money");
        else
            return 0;
    }
}
