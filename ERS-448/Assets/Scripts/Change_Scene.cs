using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Scene : MonoBehaviour
{
    public void changemenuscene(string scenename)
    {
        Application.LoadLevel (scenename);
    }
}
