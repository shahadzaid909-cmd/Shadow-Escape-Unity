using System.Collections;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    private SpriteRenderer sr;

    public GameObject winUI;

    private bool playerInRange = false;
    private bool isOpened = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedSprite;
    }

    void Update()
    {
        if (playerInRange && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        isOpened = true;

        sr.sprite = openSprite;

        StartCoroutine(WinDelay());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(0.1f); // delay (you can change)

        winUI.SetActive(true);
        Time.timeScale = 0f;
    }
}