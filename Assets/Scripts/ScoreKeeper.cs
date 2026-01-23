using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreKeeper : MonoBehaviour
{
    int Score=0;
    static ScoreKeeper instance;
    public int GetScore()
    {
        return Score;
    }
    public void modifyscore(int ScoretoAdd)
    {
        Score+=ScoretoAdd;
        Score=Mathf.Clamp(Score,0,int.MaxValue);
        print(Score);
    }
    public void ResetScore()
    {
        Score=0;    
    }
     


    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        //int instanceCount=FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
}
