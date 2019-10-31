using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Buttons : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject StartSelectPanel;
    public GameObject InstructionPanel;
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        StartSelectPanel.SetActive(false);
        InstructionPanel.SetActive(false);
    }

    public void ShowGamePanel()
    {
        MenuPanel.SetActive(false);
        InstructionPanel.SetActive(false);
        StartSelectPanel.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        StartSelectPanel.SetActive(false);
        InstructionPanel.SetActive(false);
    }

    public void ShowInstructionPanel()
    {
        MenuPanel.SetActive(false);
        StartSelectPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
