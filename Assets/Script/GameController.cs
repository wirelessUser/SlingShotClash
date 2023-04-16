using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> LevelsList;

    public GameObject Level1;
    public GameObject Level2;
     Vector3 Level1Pos;
     Vector3 Level2Pos;
    void Start()
    {
        SpawnNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewLevel()
    {
        Level1Pos = new Vector3(-4f, 1f, 25);
        Level1Pos = new Vector3(7f, 1f, 25);


        Level1= Instantiate(LevelsList[0], Level1Pos, Quaternion.identity);
        Level2= Instantiate(LevelsList[1], Level1Pos, Quaternion.identity);
    }
}
