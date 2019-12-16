using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] fruitTopSpawnPrefab;
    public int chanceToSpawnBomb = 10;
    public GameObject bombPrefab;
    public Transform[] spwanPlaces;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;
    
    // Use this for initialization
	void Start () {

        StartCoroutine(SpawnFruits());

		
	}
	
	private IEnumerator SpawnFruits()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Transform t = spwanPlaces[Random.Range(0, spwanPlaces.Length)];

            GameObject go = null;
            float rnd = Random.Range(0, 100);
            if (chanceToSpawnBomb > 90)
            {
                chanceToSpawnBomb = 90;
            }else if (chanceToSpawnBomb < 0)
            {
                chanceToSpawnBomb = 0;
            }


            if (rnd < chanceToSpawnBomb)
            {
                go = bombPrefab;
            }
            else
            {
                go = fruitTopSpawnPrefab[Random.Range(0, fruitTopSpawnPrefab.Length)];
            }

            GameObject fruit = Instantiate(go, t.transform.position, t.transform.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up *  
                Random.Range(minForce,maxForce), ForceMode2D.Impulse);
            Debug.Log("Frucht wurde erzeugt");
        }
        
    }
}
