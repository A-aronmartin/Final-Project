using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrigger : MonoBehaviour
{
    public static float slowTimeScale = 0.5f;
    public static float normalTimeScale = 1f;
    public static float timeOut = 5f;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().StartCoroutine(CountDown());


            Destroy(gameObject);
        }
    }

    public static IEnumerator CountDown()
    {
        Time.timeScale = slowTimeScale;
        yield return new WaitForSeconds(timeOut);
        Time.timeScale = normalTimeScale;
    }
}