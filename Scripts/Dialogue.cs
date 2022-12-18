using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public float delayMultiplyer;
    public float minPitch = 1.6f;
    public float maxPitch = 2.0f;
    public string[] lines;
    private float pitch = 1.0f;
    private int index;
    private char spc = ' ';
    private char comma = ',';
    private char fullStop = '.';
    private float delay;

    void Start() // Start is called before the first frame update
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update() // Update is called once per frame
    {
      if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) // Check for space or click
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

    // This method prints a line of dialogue to the screen
    // one letter at a time.
    IEnumerator TypeLine() 
    {
        char[] charArray = lines[index].ToCharArray(); // Get an array of letters for the current line
        foreach (char c in charArray)
        {
            delay = 0.0f;  // Set a textSpeedDelay of 0 for normal letters

            if (!spc.Equals(c)) // Play a short audio clip here if the letter is not a space
            {
                pitch = UnityEngine.Random.Range(minPitch,maxPitch);
                FindObjectOfType<AudioManager>().Play("TypingSound", pitch);
            }

            if(comma.Equals(c) || fullStop.Equals(c)) // If the letter is a comma or a full stop, add a delay
            {
                delay = textSpeed*delayMultiplyer;
            }

            textComponent.text += c; // Append the current letter to the dialog
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
            // System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("Game");
        }
    }
}
