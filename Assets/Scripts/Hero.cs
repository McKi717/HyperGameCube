using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero : MonoBehaviour
{
	Vector3 screenPoint;
	Vector3 offset;
	
	//цвет сферы
	public static  bool green,black,red,standart = false;
	public static bool boom=false;
	public  Material[] colSphere;
	MeshRenderer meshRenderer;
	 public GameObject gm;

	public float radius = 5.0F;
	public float power = 10.0F;
	private void Start()
    {

		meshRenderer = GetComponent<MeshRenderer>();
		
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        //if (Input.touchCount == 1)  Добавить при компиляции

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, -2.3f, 2.3f);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, -3.45f, 5.46f);
        transform.position = cursorPosition;

    }
    private void Update()
	{
		
			if (boom == true)
        {
			Boom();
        }
		if (green == true)
        {
			green = false;
			meshRenderer.material = colSphere[1];
        }
        if (black == true)
        {
			black = false;
			meshRenderer.material = colSphere[0];
        }
		if (red == true)
		{
			red = false;
			meshRenderer.material = colSphere[2];
		}
		if (standart == true)
		{
			standart = false;
			meshRenderer.material = colSphere[3];
		}
	}
	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.name == "BlackCube(Clone)" && meshRenderer.material.name == "Black (Instance)")
		{//+score
			gm.GetComponent<GameManager>().AddScore();

		}
		if (meshRenderer.material.name == "Black (Instance)" && collision.gameObject.name != "BlackCube(Clone)")
		{
			//game over
			gm.GetComponent<GameManager>().DeadMoment();
		}
		if (collision.gameObject.name == "GreenCube(Clone)" && meshRenderer.material.name=="Green (Instance)")
		{
			gm.GetComponent<GameManager>().AddScore();
		}
		if (meshRenderer.material.name == "Green (Instance)" && collision.gameObject.name != "GreenCube(Clone)")
		{
			//game over
			gm.GetComponent<GameManager>().DeadMoment();
		}
		if (collision.gameObject.name == "RedCube(Clone)" && meshRenderer.material.name == "Red (Instance)")
		{//+score
			gm.GetComponent<GameManager>().AddScore();

		}
		if (meshRenderer.material.name == "Red (Instance)" && collision.gameObject.name != "RedCube(Clone)")
		{
			//game over
			gm.GetComponent<GameManager>().DeadMoment();
		}
	}
	
 

	public void Boom()
	{
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
				rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
		}
	}
}

