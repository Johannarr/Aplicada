using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    public string sortingLayerName = string.Empty; //initialization before the methods
    public int orderInLayer = 0;
    public Renderer MyRenderer;
    void Start()
    {
        SetSortingLayer();
    }
 
void SetSortingLayer()
    {
        if (sortingLayerName != string.Empty)
        {
            MyRenderer.sortingLayerName = "Characters";
            MyRenderer.sortingOrder = 4;
        }
    }
}

