using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMiniCube : MonoBehaviour
{    
    public GameObject[] ColorCube;
   
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            float RanX = Random.Range(-2.3f, 2.3f);
            float RanY = Random.Range(5.6f, 20f);
            Vector3 spawnPos = new Vector3(RanX, RanY, transform.position.z);
            Instantiate(ColorCube[Random.Range(0, ColorCube.Length)], spawnPos, transform.rotation);
        }
    }
    private void Update()
    {
        GameObject[] posCube = GameObject.FindGameObjectsWithTag("miniCube");
        foreach (GameObject go in posCube)
        {
            if (go.transform.position.y <= -5)
            {
                float x = Random.Range(-2.3f, 2.3f);
                float y = Random.Range(5.6f, 20f);
                go.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}
