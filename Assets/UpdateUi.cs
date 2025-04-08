using UnityEngine;

public class UpdateUi : MonoBehaviour
{
    public ScoreManager scoreMan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreMan.GetFinalScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
