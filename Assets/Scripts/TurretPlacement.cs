using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretPlacement : MonoBehaviour
{
    public float minDistance;
    Transform currentObject;
    public LayerMask validSurfaces;

    private void Update()
    {
        if(currentObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit info, Mathf.Infinity, validSurfaces))
            {
                currentObject.position = info.point;
                if(Input.GetMouseButtonDown(0))
                {
                    currentObject = null;
                }
            }
            else
            {
                currentObject.position = Camera.main.transform.position + ray.direction * minDistance;
            }
        }
    }
    public void PlaceTurret(Transform prefab)
    {
 
        if(currentObject != null)
        {
            Destroy(currentObject.gameObject);

        }
        Vector3 prefabPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentObject = Instantiate(prefab, prefabPos, Quaternion.identity);


    }


}
