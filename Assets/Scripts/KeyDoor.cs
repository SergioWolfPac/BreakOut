using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Puzzle.QA;

public class KeyDoor : MonoBehaviour
{
    public GameObject puzzle;
    public Text keyText;

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerMovement.keys >= 1)
        {
            PlayerMovement.keys--;
            Debug.Log("Player has " + PlayerMovement.keys + " keys");
            keyText.text = "x " + PlayerMovement.keys;
            //Debug.Log("Player has " + PlayerMovement.keys + " Remaining");
            //PlayerMovement.keyText.text = "x " + PlayerMovement.keys;

            puzzle.SetActive(true);
        }
        else
        {
            Debug.Log("No Key on player");
        }
    }
}