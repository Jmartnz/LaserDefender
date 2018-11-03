using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    // Seconds to realize you are dead
    [SerializeField] private int levelChangeDelayInSeconds = 3; 

    private AudioSource audioSource;
    private int score = 0;

    // Use this for initialization
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(AudioController.FadeIn(audioSource, levelChangeDelayInSeconds));
    }

    public void LoadStartMenu()
    {
        StopAllCoroutines();
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        StopAllCoroutines();
        StartCoroutine(LoadLevel("Game"));
    }

    public void GameOver()
    {
        StopAllCoroutines();
        // Give the player some time to think about it...
        StartCoroutine(LoadGameOverScreen());
    }

    public void ExitGame()
    {
        StopAllCoroutines();
        Application.Quit();
    }

    public void AddToScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    IEnumerator LoadLevel(string name)
    {
        yield return StartCoroutine(AudioController.FadeOut(audioSource, 1));
        SceneManager.LoadScene(name);
    }

    IEnumerator LoadGameOverScreen()
    {
        yield return StartCoroutine(AudioController.FadeOut(audioSource, levelChangeDelayInSeconds));
        SceneManager.LoadScene("Game Over");
    }
}
