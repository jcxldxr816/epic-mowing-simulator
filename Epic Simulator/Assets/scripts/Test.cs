using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

	public float radius = 1;
	public Vector2 regionSize = Vector2.one;
	public int rejectionSamples = 30;
	public float displayRadius = 1;


	//private float randomRot = Random.Range(0f, 90f);

	List<Vector2> points;

	[SerializeField] private GameObject prefab;

	public bool render = false;

	public Transform parent;
	
	
	
	
	void OnValidate()
	{
		if (render)
        {	
			points = PaissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
			foreach (Vector2 point in points)
			{
				Vector3 newPoint = point;
				//Debug.Log(newPoint);
				//Debug.Log("-------------------");
				Vector3 newerPoint;
				newerPoint.x = newPoint.x;
				newerPoint.y = newPoint.z; //switched y and z
				newerPoint.z = newPoint.y;
				//Debug.Log(newerPoint);

				GameObject child = Instantiate(prefab, newerPoint, Quaternion.Euler(0, Random.Range(0f,90f), 0));
				child.transform.SetParent(parent, false);
			}
			render = false;
		}
	}


    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(regionSize / 2, regionSize);
    //    if (points != null)
    //    {
    //        foreach (Vector2 point in points)
    //        {
    //            Gizmos.DrawSphere(point, displayRadius);
    //        }
    //    }
    //}
}