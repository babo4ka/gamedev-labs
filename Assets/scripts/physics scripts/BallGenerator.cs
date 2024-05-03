using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _ballrb;

    [SerializeField]
    private float _force;

    [SerializeField]
    private GameObject ballPrefab;

    private Vector3 place = new Vector3(-0.382f, 0.58f, -3.77f);

    [SerializeField]
    private float _interval;
    private float delta;

    [SerializeField]
    private float deleteInterval;
    private float deleteDelta;

    private Queue<GameObject> _ballsQueue = new Queue<GameObject>();

    private void Start()
    {
        InstantiateBall();
    }

    

    private void Update()
    {
        delta += Time.deltaTime;
        if (delta > _interval)
        {
            delta = 0;
            InstantiateBall();
        }

        deleteDelta += Time.deltaTime;
        if (deleteDelta > deleteInterval)
        {
            deleteDelta = 0;
            Destroy(_ballsQueue.Dequeue());
        }
        
    }

    private void InstantiateBall()
    {
        GameObject ball = Instantiate(ballPrefab);
        ball.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(500f, 1000f));
        _ballsQueue.Enqueue(ball);
    }



    /* private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawLine(transform.position, transform.position + transform.forward*3);

         Gizmos.color = Color.green;
         Gizmos.DrawLine(transform.position, transform.position + transform.up*3);

         Gizmos.color = Color.yellow;
         Gizmos.DrawLine(transform.position, transform.position + transform.right * 3);

         Gizmos.color = Color.blue;
         Gizmos.DrawLine(transform.position, transform.position + transform.right * 3 * -1);
     }*/
}
