using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoScoreController : MonoBehaviour
{
   
    public int[] _scores = new int[5];

    public TextMesh BlueScoreText, GreenScoreText, RedScoreText, OrangeScoreText, FrogScoreText;
    

    public void IncrementScore (FishType number)
    {
        _scores[(int)number]++;

        switch (number)
        {
            case FishType.Blue:
                BlueScoreText.text = _scores[(int)number].ToString();
                break;
            case FishType.Green:
                GreenScoreText.text = _scores[(int)number].ToString();
                break;
            case FishType.Red:
                RedScoreText.text = _scores[(int)number].ToString();
                break;
            case FishType.Orange:
                OrangeScoreText.text = _scores[(int)number].ToString();
                break;
            case FishType.Frog:
                FrogScoreText.text = _scores[(int)number].ToString();
                break;
         }

    }

}
