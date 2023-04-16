using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=-4)
        {
            Destroy(this.gameObject);
        }
    }


    public void CountSetter(int _count)
    {
        this.count = _count;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag=="Ball" && count>0)
        {
            Camera.main.GetComponent<CameraEfefcts>().SmallShake();
            count--;

            if (count==0)
            {
                Camera.main.GetComponent<CameraEfefcts>().BigShake();
                Destroy(gameObject);
            }
        }
    }
}
