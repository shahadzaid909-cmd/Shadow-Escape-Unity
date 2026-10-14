using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
   
    private float lastMoveX;
    
    private float lastMoveY;
    
    private bool IsMoving;

    private Animator animator;

    public bool isInLight = false;
   
    [SerializeField]
    private int _lives = 3;

    private UIManager ui;

    public GameObject gameOverPanel;

    private AudioSource footstepAudio;

    private void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (ui == null)
        {
            Debug.LogError("the ui is  null");
        }

        footstepAudio = GetComponent<AudioSource>();
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        CalculateMovement();


        void CalculateMovement()

        {

            float XI = Input.GetAxisRaw("Horizontal");
            float YI = Input.GetAxisRaw("Vertical");

            if (XI != 0) YI = 0;

            animator.SetFloat("moveX", lastMoveX);
            animator.SetFloat("moveY", lastMoveY);
            

            Vector2 direction = new Vector2(XI, YI);

            if (XI != 0 || YI != 0)
            {
                lastMoveX = XI;
                lastMoveY = YI;
                IsMoving = true;

                if (!footstepAudio.isPlaying)
                {
                    footstepAudio.Play();
                }
            }
            else
            {
                IsMoving = false;

                footstepAudio.Stop();
            }

            transform.Translate(direction * speed * Time.deltaTime);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            isInLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            isInLight = false;
        }
    }

    public void Damage()

    {

        _lives--;
        ui.UpdateLives(_lives);


        if (_lives <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }



    }
}