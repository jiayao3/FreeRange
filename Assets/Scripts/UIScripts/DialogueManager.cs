using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    [TextArea(2,15)]
    public string[] sentences;
    public Text text;
    private string sentence;
    private bool start;
    public GameObject dialogueBox;
    private int count;
    public float speed;
    private GameObject player;
    public Animator animator;
    private bool skipWait;
    [SerializeField] AudioSource openBoxSound;

    // Start is called before the first frame update
    void Start()
    {
        sentence = "";
        start = false;
        count = 0;
        dialogueBox.SetActive(true);
        animator = dialogueBox.GetComponent<Animator>();
        animator.SetBool("Open", false);
        skipWait = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && start && !skipWait)
        {
            NextSentence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Main Player") || other.gameObject.CompareTag("Player"))
        {
            StartDialogue();
            player = other.gameObject;
            player.GetComponent<ActivePlayer>().Deactivate();
        }
        
    }

    void StartDialogue()
    {
        if (animator != null && animator.isActiveAndEnabled)
        {
            animator.SetBool("Open", true);
        }
            
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
        this.gameObject.SetActive(false);
        player.GetComponent<ActivePlayer>().Activate();
        if (animator != null && animator.isActiveAndEnabled)
        {
            animator.SetBool("Open", false);
        }
    }

    void NextSentence()
    {
        openBoxSound.Play();
        if (count < sentences.Length)
        {
            sentence = sentences[count];
            StartCoroutine(Typing(sentence));
        } else
        {
            EndDialogue();
            Destroy(this.gameObject);
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
