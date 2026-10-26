using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI floorText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI spaceText;

    public void SetMoneyText(int money)
    {
        moneyText.text = "$" + money.ToString();
    }

    public void SetFloorText(int currentFloor, int maxFloor)
    {
        floorText.text = "Floor: " + currentFloor.ToString() + "/" + maxFloor.ToString();
    }

    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void EnableSpaceText()
    {
        spaceText.enabled = true;
    }

    public void DisableSpaceText()
    {
        spaceText.enabled = false;
    }
}
