using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleMat : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public GameObject parent;
    private int currentMat = 0;
    public bool cycling = false;

    public void CycleMaterial()
    {
        if (cycling == false)
        {
            StartCoroutine(Cycle());
        }
    }

    public IEnumerator Cycle()
    {

        cycling = true;
        if (currentMat == 0)
        {
            parent.GetComponent<MeshRenderer>().material = mat2;
            currentMat = 1;
        }
        else if (currentMat == 1)
        {
            parent.GetComponent<MeshRenderer>().material = mat3;
            currentMat = 2;
        }
        else
        {
            parent.GetComponent<MeshRenderer>().material = mat1;
            currentMat = 0;
        }
        yield return new WaitForSeconds(0.5f);
        cycling = false;
    }
}
