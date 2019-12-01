/// File Name Change_Scene.cs.
/// Assignment EECS 448 Project 3.
/// Brief Defines function to change scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Scene : MonoBehaviour
{
  /*!
   \pre game is ran.
   \post changes scene based on user input.
   \return none.
  */

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel (scenename);
    }
}
