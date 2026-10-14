using System.Collections;
using UnityEngine;

public class TimedLamp : MonoBehaviour
{
    public GameObject lightAround;
    public GameObject lightArea;

    void Start()
    {
        StartCoroutine(LampRoutine());
    }

    IEnumerator LampRoutine()
    {
        while (true)
        {
            
            lightAround.SetActive(true);
            lightArea.SetActive(true);

            yield return new WaitForSeconds(5f);

            
            lightAround.SetActive(false);
            lightArea.SetActive(false);

            yield return new WaitForSeconds(3f);
        }
    }
}