﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(true);
    }
}
