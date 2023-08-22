using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Cutscenes : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        sentence = "";
        start = false;
        count = 0;
        skipWait = true;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && start && !skipWait)
        {
            NextSentence();
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
        openBoxSound.Play();
        start = false;
        //dialogueBox.SetActive(false);
        curScene.gameObject.SetActive(false);
        player.GetComponent<ActivePlayer>().Activate();
    }

    void NextSentence()
    {
        openBoxSound.Play();
        if (count < sentences.Length)
        {
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
}
