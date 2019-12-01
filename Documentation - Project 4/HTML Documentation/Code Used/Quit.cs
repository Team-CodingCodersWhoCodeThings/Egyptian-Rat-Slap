/// File Name Quit.cs.
/// Assignment EECS 448 Project 3.
/// Brief Closes application on Esc press.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    /*!
     \pre file opened.
     \post application closed.
     \return none.
    */

    void Update()
    {
        /// If Esc is pressed, close application.
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
