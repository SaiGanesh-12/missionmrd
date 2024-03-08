using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellspawner : MonoBehaviour
{
    public GameObject bloodcell;
    public GameObject cancercell;
    public float ypos;

    private void Start()
    {
        StartCoroutine(spawncell());
        StartCoroutine(spawncancercell());
    }


    IEnumerator spawncell()
    {
        while (true)
        {
            ypos = Random.Range(transform.position.y-1, transform.position.y+1);
            Instantiate(bloodcell, new Vector3(transform.position.x, ypos, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator spawncancercell()
    {
        while (true)
        {
            ypos = Random.Range(transform.position.y - 0.2f, transform.position.y + 0.3f);
            Instantiate(cancercell, new Vector3(transform.position.x, ypos, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(1.5f);
        }
    }
}