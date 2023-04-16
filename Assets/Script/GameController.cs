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
        Level1Pos = new Vector3(-4f, 1f, 25);
        Level1Pos = new Vector3(7f, 1f, 25);


        Level1= Instantiate(LevelsList[0], Level1Pos, Quaternion.identity);
        Level2= Instantiate(LevelsList[1], Level1Pos, Quaternion.identity);

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
