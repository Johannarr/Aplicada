using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
   
    int[] _scores = new int[6];

    public void IncrementScore (EssenceType number)
    {
        _scores[(int)number]++;
    }




}
