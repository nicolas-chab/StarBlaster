using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreKeeper : MonoBehaviour
{
    int Score=0;

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
    
}
