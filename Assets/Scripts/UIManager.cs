using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UIinstance;

    public GameObject dialogueBox;
    public Text characterNameText;
    public Text dialogueLineText;
    public GameObject spacebar;

    private void Awake()
    {
        if (UIinstance == null)
        {
            UIinstance = this;
        }
        else
        {
            if (UIinstance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleDialogueBox(bool _isActive)
    {
        dialogueBox.gameObject.SetActive(_isActive);
    }

    public void ToggleSpacebar(bool _isActive)
    {
        spacebar.SetActive(_isActive);
    }

    public void SetupDialogue(string _name, string _line,int _size)
    {
        characterNameText.text = _name;
        dialogueLineText.text = _line;
        dialogueLineText.fontSize = _size;

        ToggleDialogueBox(true);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
