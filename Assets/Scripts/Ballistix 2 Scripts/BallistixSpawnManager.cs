using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class BallistixSpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //array of spawners for the balls to spawn from
    float angle; 
    public GameObject [] spawner;
    public GameObject test;
    public GameObject prefabBall;
    private GameObject curnrentball;
    private int ballCount = 0;
    private int requiredballs = 1;
    private float lastSpawnTime;
    private float spawnSpeed;
    void Start()
    {
        // SpawnBall();
      





    }

    private void FixedUpdate()
    {
        //testing certain spawners
        //SpawnFromSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (curnrentball == null)
        {
           SpawnBall();


        }
        if (Time.time - lastSpawnTime >= 5f)
        {
           SpawnBall();
        }
    }


        void SpawnBall()
        {

            lastSpawnTime = Time.time;
        angle = Random.Range(-30, 30f);
        spawnSpeed = Random.Range( 4, 10f);

        //randomly select a spawner from the array of spawners
        int randomSpawner = Random.Range(0, spawner.Length);
        Debug.DrawRay(
        spawner[randomSpawner].transform.position,
        spawner[randomSpawner].transform.forward * 5,
        Color.red,
        5f);


        //spawn a ball from the selected spawner
        Vector3 direction = Quaternion.Euler(0, angle, 0) * spawner[randomSpawner].transform.forward;
            curnrentball = Instantiate(prefabBall, spawner[randomSpawner].transform.position, Quaternion.LookRotation(direction));
        Rigidbody rb = curnrentball.GetComponent<Rigidbody>();
        rb.linearVelocity = direction.normalized * spawnSpeed;
        ballCount++;
            requiredballs++;
            Debug.Log(ballCount);
            Debug.Log(requiredballs);
        }

        void SpawnFromSpawner()
        {
        //angle = Random.Range(-180, 180);
        //spawn a ball from the selected spawner
        Vector3 direction = Quaternion.Euler(0, 0, 0) * test.transform.forward;
            Instantiate(prefabBall, test.transform.position, Quaternion.LookRotation(direction));
            ballCount++;
        }
    }
