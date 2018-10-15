using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class LevelManager : MonoBehaviour {

    [SerializeField] private int levelChangeDelayInSeconds = 3; // Seconds to realize you are dead

    private AudioSource audioSource;
    private int score = 0;

    // Use this for initialization
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(AudioController.FadeIn(audioSource, levelChangeDelayInSeconds));
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadLevel("Game"));
    }

    IEnumerator LoadLevel(string name)
    {
        yield return StartCoroutine(AudioController.FadeOut(audioSource, 1));
        SceneManager.LoadScene(name);
    }

    public void GameOver()
    {
        // Give the player some time to think about it...
        StartCoroutine(LoadGameOverScreen());
    }

    IEnumerator LoadGameOverScreen()
    {
        yield return StartCoroutine(AudioController.FadeOut(audioSource, levelChangeDelayInSeconds));
        SceneManager.LoadScene("Game Over");
    }

    public void ExitGame()
    {
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

}
