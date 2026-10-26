using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadDungeon() { SceneManager.LoadScene("Dungeon"); }
    public void LoadSetup() { SceneManager.LoadScene("Setup"); }
    public void LoadCredits() { SceneManager.LoadScene("Credits"); }
    public void LoadMenu() { SceneManager.LoadScene("MainMenu"); }
    public void LoadInstructions() { SceneManager.LoadScene("Instructions"); }
    public void LoadGameOver() { SceneManager.LoadScene("GameOver"); }
}
