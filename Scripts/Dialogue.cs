using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
   
    public float textSpeed;
    
    [HideInInspector]
    public float delay;
    public float delayMultiplyer;
    private int index;
    private char spc = ' ';
    private char comma = ',';
    private char fullStop = '.';

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
      {
        
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Loop through each line
        foreach (char c in lines[index].ToCharArray())
        {
            // We start with a textSpeedDelay of 0 for normal letters
            delay = 0.0f;

            // play a short audio clip here if the c is not a space            
            if (!spc.Equals(c)){
                FindObjectOfType<AudioManager>().Play("TypingSound");
            }

            // If the letter is a comma, add a delay
            if(comma.Equals(c) || fullStop.Equals(c) ){
                delay = textSpeed*delayMultiplyer;
            }

            // Appends each char in turn to the textComponent of the dialog box
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed+delay);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
