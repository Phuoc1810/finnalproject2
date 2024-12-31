using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text textComment;
    public string[] line;
    public float textSpeed;

    private int index;
    private bool isTyping; //kiem tra xem co dang go hop thoai khong

    // Start is called before the first frame update
    void Start()
    {
        textComment.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (!isTyping) //neu khong go dong thoai
            {
                if (textComment.text == line[index]) //neu da go xong dong thoai
                {
                    NextLine(); //chuyen sang dong tiep theo
                }
                else
                {
                    StopAllCoroutines();
                    textComment.text = line[index];
                }
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        isTyping = true; //danh dau la dang go dong thoai
        textComment.text = ""; //xoa text truoc khi bat dau go
        foreach(char c in line[index].ToCharArray())
        {
            textComment.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false; //ket thuc viec go dong thoai
    }
    void NextLine()
    {
        if(index < line.Length - 1)
        {
            index++;
            textComment.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
