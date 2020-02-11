﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private LevelManager LevelManager;
    private BricksManager BricksManager;
    private AudioManager audioManager;
    private void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        BricksManager = GameObject.FindObjectOfType<BricksManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If while waiting for transition to next level, don't check lose condition
        if (BricksManager.RemainBricks() > 0)
        {
            audioManager.PlayFailingAudio();
            LevelManager.LoadLevel("Lose");
        }
    }
}
