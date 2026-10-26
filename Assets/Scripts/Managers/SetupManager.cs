using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    [Header("References")]
    public SaveDataManager save;
    public Button[] buttons;
    public Button startButton;
    public Slider slider;
    public Toggle toggle;
    public TextMeshProUGUI startFloorButtonText;

    [Header("Variables")]
    public int savedFloorNumber = 5;

    public void ToggleSlider()
    {
        foreach (var button in buttons)
        {
            button.interactable = !toggle.isOn;
        }
        if (!buttons[0].interactable)
        {
            savedFloorNumber = save.GetFloor();
        }
        else
            ChangeFloorNumber(savedFloorNumber);
        slider.interactable = toggle.isOn;
    }

    public void ChangeFloorNumber(int floorNumber)
    {
        save.SetFloorLimit(floorNumber);
        if (startButton.interactable == false)
            startButton.interactable = true;
        startFloorButtonText.text = "Start " + floorNumber.ToString() + " Floor";
    }

    private void Update()
    {
        if (slider.interactable)
            ChangeFloorNumber((int)(slider.value));
    }
}
