using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnWhiteMiniCube : MonoBehaviour
{
    public float radius = 3.0F;
    public float power = 20F;
    public GameObject miniCube;
    public GameObject AnimFinishScene;
   
    private void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < 50; i++)
        {
            spawnPosition.x = Random.Range(-2.3f, 2.3f);
            spawnPosition.y = Random.Range(7f, 20f);

            Instantiate(miniCube, spawnPosition, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {


        if (Input.GetMouseButton(0))


        {

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 explosionPos = Camera.main.ScreenToWorldPoint(mousePos);

            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 0F, ForceMode.Force);
            }

        }
        GameObject[] newSpawn = GameObject.FindGameObjectsWithTag("miniCube");
        foreach (GameObject go in newSpawn)
        {
            if (go.transform.position.y <= -5)
            {
                float x = Random.Range(-2.3f, 2.3f);
                float y = Random.Range(7, 20);
                go.transform.position = new Vector3(x, y, 0);
            }
        }
    }
    public void AnFinishScene()
    {
        AnimFinishScene.SetActive(true);
        StartCoroutine(LoadLevel());
     
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);

    }
    
      
}
