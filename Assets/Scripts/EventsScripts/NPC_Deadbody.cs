using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Deadbody : MonoBehaviour

{
    public GameObject dialogPanel; // masukan dialogPanel
    public TextMeshProUGUI dialogText; // masukan dialogText
    public string[] dialog; // array isi dialog
    private int index = 0; // inisialisasi index
    public float wordSpeed; // kecepatan ketikan kata, lebih kecil lebih cepat
    public bool playerIsClose; // if trigger player dekat dengan collision NPC


    public GameObject videoTrigger; // masukan trigger dalam inspektor

    void Start()
    {
        dialogText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialogPanel.activeInHierarchy)
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());

                Debug.Log("Interacted with NPC dead body");
                videoTrigger.SetActive(true);
            }
            else if (dialogText.text == dialog[index])
            {
                NextLine();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && dialogPanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    public void RemoveText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialog.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        }
    }
}