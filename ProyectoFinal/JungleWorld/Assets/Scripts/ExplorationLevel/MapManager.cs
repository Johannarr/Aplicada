using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
//using UnityEngine;



public class MapManager : MonoBehaviour
{
    public GameObject Grass1, Grass2, Grass3, Rock, Obstacle1, Obstacle2, Obstacle3, Tree1, Tree2;
    XmlDocument xmlDoc;

    public GameObject PlayerPrefab, Enemy1Prefab, Enemy2Prefab, CoinPrefab, PowerupPrefab, CheckPrefab, Check1Prefab;
    GameObject currentPrefab = null;
    Transform cellsConstainer, charactersContainer;
    XmlNode currentNode;
    XmlNodeList nodeList;
    // Start is called before the first frame update

    private void Awake()
    {
        cellsConstainer = GameObject.Find("Cells").transform;
        charactersContainer = GameObject.Find("Characters").transform;

    }
    void Start()
    {
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Resources.Load<TextAsset>("JungleLevel").text);
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
                    currentPrefab = Grass3;
                        break;
                    case 'E':
                    currentPrefab= Tree1;
                        break;
                    case 'F':
                    currentPrefab=Tree2;
                        break;
                    case 'G':
                    currentPrefab= Rock;
                        break;
                     case 'J':
                    currentPrefab=Obstacle1;
                        break;
                    case 'K':
                    currentPrefab=Obstacle2;
                        break;
                    case 'L':
                    currentPrefab=Obstacle3;
                        break;
                    
                }

                currentPrefab = Instantiate (currentPrefab, new Vector3(j,-i), 
                Quaternion.identity);

                currentPrefab.transform.SetParent(cellsConstainer);
            
            }
        }

        //Loading characters:

        LoadCharacters();
        
        
    }

   void LoadCharacters()
    {
        GameObject newElement;
        currentPrefab = null;
        nodeList = xmlDoc.SelectNodes("//level/characters/character");
        foreach( XmlNode currentElement in nodeList)
        {
            switch (currentElement.Attributes ["prefabName"].Value)
            {
                case "Player":
                    currentPrefab = PlayerPrefab;
                    break;
                case "Enemy1":
                    currentPrefab = Enemy1Prefab;
                    break;
                case "Enemy2":
                    currentPrefab = Enemy2Prefab;
                    break;
                case "CoinPrefab":
                    currentPrefab = CoinPrefab;
                    break;
                case "PowerupPrefab":
                    currentPrefab = PowerupPrefab;
                    break;
                case "Check1Prefab":
                    currentPrefab = Check1Prefab;
                    break;
                case "CheckPrefab":
                    currentPrefab = CheckPrefab;
                    break;
                    /*default:
                        currentPrefab = EnemyPrefab;
                        break;*/
            }
            newElement = Instantiate (currentPrefab, 
            new Vector3(Convert.ToSingle(currentElement.Attributes["posX"].Value),
            -Convert.ToSingle(currentElement.Attributes["posY"].Value)),
            Quaternion.identity);

            newElement.name = currentElement.Attributes["uniqueObjectName"].Value;
            newElement.transform.SetParent(charactersContainer);

            if (newElement.tag == "Player")
            {
                
                Camera.main.transform.SetParent(newElement.transform);
                Camera.main.transform.localPosition = new Vector3(0,0, 
                Camera.main.transform.localPosition.z);
            }
        }
    }
}
