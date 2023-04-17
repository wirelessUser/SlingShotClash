using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ShootScript : MonoBehaviour
{
   // private GameController gc;

    public float power = 2;
    private int dots = 15;

    private Vector3 startPos;

    private bool shoot, aiming;

    public GameObject Dots;
    public List<GameObject> projectilesPath;

    private Rigidbody2D ballBody;

    public GameObject ballPrefab;
   public GameObject ballsContainer;
   public  List<GameObject> InstanitatedBallList;

    public GameController gc;
    void Awake()
    {
       // gc = GameObject.Find("GameController").GetComponent<GameController>();
        Dots = GameObject.Find("dots");
    }

    void Start()
    {
        projectilesPath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
        HideDots();
    }

    void Update()
    {
        ballBody = ballPrefab.GetComponent<Rigidbody2D>();

        if (gc.shotCount <= 3 )
        {
            Aim();
        
        Rotate();
    }

    DestroyBalls();
    }

    //private bool IsMouseOverUI()
    //{
    //    return EventSystem.current.IsPointerOverGameObject();
    //}

    void Aim()
    {
        if (shoot)
            return;

        if (Input.GetMouseButton(0))
        {
            if (!aiming)
            {
                aiming = true;
                startPos = Input.mousePosition;
               // gc.CheckShotCount();
            }
            else
            {
                PathCalculation();
            }
        }
        else if (aiming && !shoot)
        {
            aiming = false;
            HideDots();
             StartCoroutine(Shoot());
            Camera.main.GetComponent<CameraEfefcts>().RotateCameraToSide();
            //if (gc.shotCount == 1)
            //    Camera.main.GetComponent<CameraTransitions>().RotateCameraToSide();
        }
    }

    Vector2 ShootForce(Vector3 force)
    {
        return (new Vector2(startPos.x, startPos.y) - new Vector2(force.x, force.y)) * power;
    }

    Vector2 DotPath(Vector2 startP, Vector2 startVel, float t)
    {
        return startP + startVel * t + 0.5f * Physics2D.gravity * t * t;
    }

    void PathCalculation()
    {
        Vector2 vel = ShootForce(Input.mousePosition) * Time.fixedDeltaTime / ballBody.mass;

        for (int i = 0; i < projectilesPath.Count; i++)
        {
            projectilesPath[i].GetComponent<Renderer>().enabled = true;
            float t = i / 15f;
            Vector3 point = DotPath(transform.position, vel, t);
            point.z = 1;
            projectilesPath[i].transform.position = point;
        }

    }

    void ShowDots()
    {
        for (int i = 0; i < projectilesPath.Count; i++)
        {
            projectilesPath[i].GetComponent<Renderer>().enabled = true;
        }
    }

    void HideDots()
    {
        for (int i = 0; i < projectilesPath.Count; i++)
        {
            projectilesPath[i].GetComponent<Renderer>().enabled = false;
        }
    }

    void Rotate()
    {
        Vector3 dir = GameObject.Find("DotsPath (1)").transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(1,0,0));
    }

   IEnumerator Shoot()
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.05f);
          GameObject   ball = Instantiate(ballPrefab, ballsContainer.transform.position, ballsContainer.transform.rotation);
            ball.name = "Ball";
           ball.gameObject.tag = "Ball";
            ballBody = ball.GetComponent<Rigidbody2D>();
            ballBody.AddForce(ShootForce(Input.mousePosition));
            InstanitatedBallList.Add(ball);
        }

        gc.shotCount++;
    }


    public void DestroyBalls()
    {
      
        for (int i = 0; i < InstanitatedBallList.Count; i++)
        {


            // InstanitatedBallList.RemoveRange(0, InstanitatedBallList.Count);
            

            //if (i== InstanitatedBallList.Count-1)
            //{
                
                if (InstanitatedBallList[i].transform.position.y <= -4f)
                {
                    Destroy(InstanitatedBallList[i]);
                InstanitatedBallList.RemoveAt(i);
                }
                
            //}
            
        }
       // InstanitatedBallList.RemoveAll(ball => ball == null/* && ball.transform.position.y <= -4f*/);


    }

    
}
