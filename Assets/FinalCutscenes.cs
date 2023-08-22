using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class FinalCutscenes : MonoBehaviour
{
    [TextArea(2, 15)]
    public string[] sentences;
    public Text text;
    private string sentence;
    private bool start;
    private int count;
    public float speed;
    [SerializeField] GameObject player;
    private bool skipWait;
    [SerializeField] AudioSource openBoxSound;
    public Image curScene;
    public Sprite[] scenes;
    private bool next = true;
    public GameObject continueText;

    // Start is called before the first frame update
    void Start()
    {
        sentence = "";
        start = false;
        count = 0;
        skipWait = true;
        StartDialogue();
        continueText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((count == 4 || count == 5 || count == 6 || count == 7 || (count >= 11 && count <= 13)) && count < sentences.Length)
        {
            StartCoroutine(SceneAnimation());
        } else
        {
            if (Input.anyKeyDown && start && !skipWait)
            {
                NextSentence();
            }
        }
        if (count >= 14)
        {
            continueText.SetActive(true);
        }
    }

    void StartDialogue()
    {

        if (!start)
        {
            NextSentence();
        }
        start = true;
        //dialogueBox.SetActive(true);

    }

    void EndDialogue()
    {
        SceneManager.LoadScene(0);
    }

    void NextSentence()
    {
            
        if (count < sentences.Length)
        {

                openBoxSound.Play();
                sentence = sentences[count];
                curScene.sprite = scenes[count];
                player.GetComponent<ActivePlayer>().Deactivate();
                StartCoroutine(Typing(sentence));
            
        }
        else
        {
            EndDialogue();
        }
        count++;

    }


    IEnumerator Typing(string sentence)
    {
        skipWait = true;
        text.text = string.Empty;
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(speed);
        }
        skipWait = false;
    }

    IEnumerator SceneAnimation()
    {
        if (next)
        {
            if (count < sentences.Length)
            {
                if ((count == 4 || count == 5 || count == 6 || count == 7 || (count >= 11 && count <= 13)))
                {
                    sentence = sentences[count];
                    curScene.sprite = scenes[count];
                    player.GetComponent<ActivePlayer>().Deactivate();
                    next = false;
                    yield return new WaitForSeconds(0.8f);
                    next = true;
                    StartCoroutine(Typing(sentence));
                }
            }
            else
            {
                EndDialogue();
            }

            count++;
        }

        
    }
}
