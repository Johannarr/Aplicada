using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
   
    int[] _scores = new int[6];

    public TextMesh BlueScoreText, GreenScoreText, PinkScoreText, PurpleScoreText, RedScoreText,
    YellowScoreText;

    public void IncrementScore (EssenceType number)
    {
        _scores[(int)number]++;

        switch (number)
        {
            case EssenceType.Blue:
                BlueScoreText.text = _scores[(int)number].ToString();
                break;
            case EssenceType.Green:
                GreenScoreText.text = _scores[(int)number].ToString();
                break;
            case EssenceType.Pink:
                PinkScoreText.text = _scores[(int)number].ToString();
                break;
            case EssenceType.Purple:
                PurpleScoreText.text = _scores[(int)number].ToString();
                break;
            case EssenceType.Red:
                RedScoreText.text = _scores[(int)number].ToString();
                break;
            case EssenceType.Yellow:
                YellowScoreText.text = _scores[(int)number].ToString();
                break;
        }
    }




}
