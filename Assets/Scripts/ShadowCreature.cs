using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCreature : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    public bool alwaysChase = false;
    public bool isChasing = false;

    private PlayerController playerScript;
    private Vector2 spawnPosition;

    

    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
        spawnPosition = transform.position;
        
    }

    void Update()
    {
        if ((alwaysChase || isChasing) && !playerScript.isInLight)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }


    public void StartChasing()
    {
        isChasing = true;
    }

    
    public void StopChasing()
    {
        if (!alwaysChase)
        {
            isChasing = false;
        }
    }

 IEnumerator Respawn()
{
    GetComponent<SpriteRenderer>().enabled = false;
    GetComponent<Collider2D>().enabled = false;

    yield return new WaitForSeconds(2f);

    transform.position = spawnPosition;

    GetComponent<SpriteRenderer>().enabled = true;
    GetComponent<Collider2D>().enabled = true;

    if (!alwaysChase)
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < 6f)
        {
            isChasing = true;
        }
    }
}
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && !playerScript.isInLight)
    {
        playerScript.Damage();
        StartCoroutine(Respawn());
    }
}

}


