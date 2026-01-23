using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper=FindFirstObjectByType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        scoreKeeper.ResetScore();
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver",2f));
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    IEnumerator WaitAndLoad(string SceneName,float Delay)
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(SceneName);
    }
}
