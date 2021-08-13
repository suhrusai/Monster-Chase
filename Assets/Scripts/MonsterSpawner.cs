using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    private Transform player;
    [SerializeField]
    private Transform leftPos, rightPos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SpawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonster()
    { 
        while (player)  //Spawn Monsters Until Player is alive and if player is null stop spawnning monsters
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            //For spawnning monster on left
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(3, 10);
            }
            //For spawnning monster on right
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -1 * Random.Range(3, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

           // spawnedMonster.transform.position = new Vector3(spawnedMonster.transform.position.x, spawnedMonster.transform.position.y, 0f);
        }
    }
}
