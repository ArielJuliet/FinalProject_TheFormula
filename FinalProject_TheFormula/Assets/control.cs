

using System.Collections;
using UnityEngine;

public class control : MonoBehaviour
{

    public Transform sparkle;
    void Start()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void onTriggerEnter2D()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stopSparkles());
    }


    IEnumerator stopSparkles()

    {
        yield return new WaitForSeconds (.4f);

        sparkle.GetComponent<ParticleSystem>().enableEmission = false;

    }

}