using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Dialogue : MonoBehaviour
{
    private System.Random random = new System.Random();  
    private float pitch = 1.0f;
    public TextMeshProUGUI textComponent;
    public string[] lines;
   
    public float textSpeed;
    
    [HideInInspector]
    public float delay;
    public float delayMultiplyer;
    private int index;
    private int carIndex;
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
        // Loop through each character
        char[] charArray = lines[index].ToCharArray();
        carIndex = 0;
        foreach (char c in charArray)
        {
            //pitch = random.Next(1,4);
            pitch = random.Next(1,3);
            Debug.Log(pitch);
            carIndex++;
            // We start with a textSpeedDelay of 0 for normal letters
            delay = 0.0f;

            // play a short audio clip here if the c is not a space            
            if (!spc.Equals(c) && (carIndex%2 == 0) ){

                FindObjectOfType<AudioManager>().Play("TypingSound", pitch);
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
