using UnityEngine;

public class SpawnManager : MonoBehaviour
{ public GameObject obstaclePrefab;
private PlayerController playerControllerScript;
   private Vector3 spawnPos = new Vector3(10, 0, 0);
   public float startDelay = 10f;
   public float repeatRate = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        InvokeRepeating("SpawnObstecle", startDelay,repeatRate );
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       
    }

    // Update is called once per frame
    void SpawnObstecle()
    {if (playerControllerScript.gameOver == false){
         Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);}
    }
}


