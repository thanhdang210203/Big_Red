using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static int ScoreNum = 0;

    //[SerializeField] private int addScore;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        ScoreText.text = "Score: " + ScoreNum;
    }

    //public void AddScore(int addScore)
    //{
    //    ScoreNum += addScore;
    //    ScoreText.text = "Score: " + ScoreNum;
    //}
}