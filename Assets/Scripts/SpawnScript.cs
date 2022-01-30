using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] Enemies;
    public float TimeSpan;
    public float Interval;
    // Start is called before the first frame update
    void Start()
    {
        Spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan += Time.deltaTime;
        if(TimeSpan >= Interval)
        {
            TimeSpan = 0f;
            int randomEnemy = Random.Range(0, Enemies.Length);
            int randomSpawner = Random.Range(0, Spawners.Length);
            var NewEnemy = Instantiate(Enemies[randomEnemy], Spawners[randomSpawner].gameObject.transform);
        }
    }
}
