using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    private TextMesh text;
    private ParticleSystem sparksParticles;
    
    private List<string> textToDisplay;
    
    public float timeToNextText;

    private int currentText;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();

        sparksParticles = GameObject.Find("SparksEffect").GetComponent<ParticleSystem>();
        sparksParticles.Play();

        textToDisplay.Add("Congratulation");
        textToDisplay.Add("All Errors Fixed");

        InvokeRepeating("Timer", 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeToNextText > 2)
        {
            if (currentText == textToDisplay.Count - 1)
            {
                timeToNextText = 0;
                currentText = 0;
            }

            else
            {
                timeToNextText = 0;
                currentText++;
            }
        }
    }

    void Update()
    {
        text.text = textToDisplay[currentText];
    }

    void Timer()
    {
        timeToNextText++;
    }
}