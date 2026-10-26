using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI score;
    public SaveDataManager save; 

    private void Start()
    {
        SetScore();
    }

    private void SetScore()
    {
        score.text = "Money gathered: $" + save.GetMoney().ToString();
    }
}
