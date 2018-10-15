using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] private int delaySeconds = 3; // Seconds to realize you are dead

    // Use this for initialization
    private void Start() {

    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        // Give the player some time to think about it...
        StartCoroutine(LoadGameOverScreen());
    }

    IEnumerator LoadGameOverScreen()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
