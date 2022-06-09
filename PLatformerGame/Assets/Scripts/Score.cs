using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int ScoreNum = 0;

    //[SerializeField] private int addScore;
    // Start is called before the first frame update
    private void Start()
    {
        ScoreText.text = "Score: " + ScoreNum;
    }

    // Update is called once per frame
    public void Update()
    {
        ScoreText.text = "Score: " + ScoreNum;
    }

    //public void AddScore(int addScore)
    //{
    //    ScoreNum += addScore;
    //    ScoreText.text = "Score: " + ScoreNum;
    //}
}