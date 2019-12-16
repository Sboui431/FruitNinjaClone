using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject SlicedFruitPrefab;
    public float explosionforce = 5;
	public void CreatSlicedFruit()
    {
        GameObject inst = Instantiate(SlicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        FindObjectOfType<GameManager>().PlayRandomSliceSound();

        foreach(Rigidbody r in rbOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionforce);
        }

        FindObjectOfType<GameManager>().IncreaseScore(3);

        Destroy(inst.gameObject, 5);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        CreatSlicedFruit();
    }
	
	
}
