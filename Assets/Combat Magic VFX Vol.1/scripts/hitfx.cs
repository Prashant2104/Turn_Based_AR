using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitfx : MonoBehaviour
{
    public GameObject explosion;
    private void Start()
    {
        StartCoroutine(Explode());   
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(expl, 3); // delete the explosion after 3 seconds
        this.gameObject.SetActive(false);
    }
    void OnCollisionEnter()
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(expl, 3); // delete the explosion after 3 seconds
        this.gameObject.SetActive(false);
    }
}