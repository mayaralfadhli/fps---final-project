using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    public GameObject Bot1;
    public GameObject Bot2;
    public GameObject Bot3;
    public GameObject Bot4;
    public GameObject Bot5;
    public GameObject Bot6;
    public GameObject Bot7;
    
    public GameObject enemyObject;

    void Spawn()
    {
        GameObject spawnObject;
        int choice = Random.Range(0, 7);

        if (choice == 1)
            spawnObject = Bot1;
        else if (choice == 2)
            spawnObject = Bot2;
        else if (choice == 3)
            spawnObject = Bot3;
        else if (choice == 4)
            spawnObject = Bot4;
        else if (choice == 5)
            spawnObject = Bot5;
        else if (choice == 6)
            spawnObject = Bot6;
        else if (choice == 7)
            spawnObject = Bot7;

        int newPosition = Random.Range(0, 7);
        Vector3 vPosition = transform.position;
        vPosition.x = vPosition.x * 5 * newPosition; 
        
        GameObject newSpawn = Instantiate(enemyObject, vPosition, Quaternion.identity);





    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
