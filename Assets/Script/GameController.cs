using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject[] blocks;
    public List<GameObject> LevelsList;

    public GameObject Level1;
    public GameObject Level2;
     Vector3 Level1Pos;
     Vector3 Level2Pos;

   public int shotCount;
    void Start()
    {
        Physics2D.gravity = new Vector2(0, 50);
        SpawnNewLevel(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewLevel(int min,int max)
    {

        shotCount = 1;
        Camera.main.GetComponent<CameraEfefcts>().RotateCameraToFront();
        Level1Pos = new Vector3(3f, 5.8f, 34);
        Level2Pos = new Vector3(6f, 5.8f, 34);


        Level1= Instantiate(LevelsList[0], Level1Pos, Quaternion.identity);
        Level2= Instantiate(LevelsList[1], Level2Pos, Quaternion.identity);

        SetBlockCount(min, max);
    }


    public void SetBlockCount( int minCount, int maxCount)
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        

        for (int i = 0; i < blocks.Length; i++)
        {
            int randCount = Random.Range(minCount, maxCount);
            blocks[i].GetComponent<Block>().CountSetter(randCount);
        }
       
       
    }
}
