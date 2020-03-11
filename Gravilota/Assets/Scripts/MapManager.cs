using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine;



public class MapManager : MonoBehaviour
{
    public GameObject Grass1, Grass2, RoadCross,
    RoadEndHor2, RoadEndHor2Left, RoadEndVer2,
     RoadEndVer2Down, RoadMiddleHor, RoaddMiddleVer1, Tree;
    XmlDocument xmlDoc;
    GameObject currentPrefab;
    XmlNode currentNode;
    XmlNodeList nodeList;
    // Start is called before the first frame update
    void Start()
    {
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Resources.Load<TextAsset>("Level1").text);
        LoadMap();
    }

    // Update is called once per frame
    void LoadMap()
    {
         //Loading the map
        currentPrefab = null;
        nodeList = xmlDoc.SelectNodes("//level/map/row");
                
        for( int i = 0; i< nodeList.Count; i++ )
        {
            currentNode = nodeList[i];
            for (int j = 0; j < currentNode.InnerText.Length; j++)
            {
                switch(currentNode.InnerText[j])
                {
                    case 'A':
                    currentPrefab = Grass1;
                        break;
                    case 'B':
                    currentPrefab = Grass2;
                        break;
                    case 'C':
                    currentPrefab = Tree;
                        break;
                    case 'D':
                    currentPrefab= RoadCross;
                        break;
                    case 'E':
                    currentPrefab= RoadEndHor2;
                        break;
                    case 'F':
                    currentPrefab=RoadEndHor2Left;
                        break;
                    case 'G':
                    currentPrefab= RoadEndVer2;
                        break;
                    case 'H':
                    currentPrefab= RoadEndVer2Down;
                        break;
                    case 'I':
                    currentPrefab=RoadMiddleHor;
                        break;
                    case 'J':
                    currentPrefab=RoaddMiddleVer1;
                        break;
                    
                }

                Instantiate (currentPrefab, new Vector3(j,-i), Quaternion.identity);
            }
        }

        //Loading characters:

        LoadCharacters();
        
    }

    void LoadCharacters()
    {
        GameObject newElement;
        currentPrefab = null;
        nodeList = xmlDoc.SelectNodes("//Level/characters/character");
        foreach( XmlNode currentElement in nodeList)
        {
            switch (currentElement.Attributes ["prefabName"].Value)
            {
                case "Player":
                    currentPrefab = Tree;
                    break;
                case "Morah":
                    break;
                case "Lianel":
                    break;
            }
            newElement = Instantiate (currentPrefab, 
            new Vector3(Convert.ToSingle(currentElement.Attributes["posX"].Value),
            Convert.ToSingle(currentElement.Attributes["posY"].Value)),
            Quaternion.identity);

            newElement.name = currentElement.Attributes["uniqueObjectName"].Value;

        }
    }
}
