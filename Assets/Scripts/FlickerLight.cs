using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Transform[] targets;

    public GameObject warningText;

    Vector3 originalScale;
    SpriteMask mask;

    public float dangerDistance = 0.5f;
    bool isFlickeringOff = false;

    public AudioSource enemyAudio;

    void Start()
    {
        originalScale = transform.localScale;
        mask = GetComponent<SpriteMask>();

        

        warningText.SetActive(false);
    }

    void Update()
    {
        bool danger = false;

        foreach (Transform target in targets)
        {
            if (target == null) continue;

            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < dangerDistance)
            {
                danger = true;
                break;
            }
        }

        if (danger)
        {
            warningText.SetActive(true);

            if (!enemyAudio.isPlaying)
            {
                enemyAudio.Play();
            }

            if (!isFlickeringOff)
            {
                StartCoroutine(LightOffMoment());
            }
        }
        else
        {
            warningText.SetActive(false);

            enemyAudio.Stop();
        }

        float pulse = 1 + Mathf.Sin(Time.time * 2f) * 0.05f;
        transform.localScale = originalScale * pulse;
    }

    IEnumerator LightOffMoment()
    {
        isFlickeringOff = true;

        mask.enabled = false;
        yield return new WaitForSeconds(0.05f);

        mask.enabled = true;

        yield return new WaitForSeconds(0.15f);

        isFlickeringOff = false;
    }
}