using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour

{

    [SerializeField]
    private Image _heartImg;

    [SerializeField]
    private Sprite[] _heartSprites;


    public void UpdateLives(int currentLives)

    {

        _heartImg.sprite = _heartSprites[currentLives];

    }



}

