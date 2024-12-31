using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selene : MonoBehaviour
{
    public GameObject dialoguePanel;  // Hộp thoại UI
    public UnityEngine.UI.Text dialogueText;  // Text để hiển thị hội thoại
    public string[] dialogues;  // Mảng các câu hội thoại
    public float textSpeed = 0.05f;  // Tốc độ gõ chữ
    private int dialogueIndex = 0;  // Chỉ số câu hội thoại hiện tại

    public GameObject ui_Contact;
    private bool isPlayerNearby = false;  // Kiểm tra xem người chơi có ở gần NPC không

    void Start()
    {
        dialoguePanel.SetActive(false);  // Ẩn hộp thoại khi bắt đầu
        ui_Contact.SetActive(false);
    }

    void Update()
    {
        // Nếu người chơi gần NPC và nhấn F, bắt đầu hội thoại
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            StartDialogue();
            ui_Contact.SetActive(false);
        }

        // Nếu đang trong hội thoại, người chơi có thể chuyển sang câu tiếp theo
        if (dialoguePanel.activeSelf && Input.anyKeyDown)
        {
            if (dialogueText.text == dialogues[dialogueIndex])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogues[dialogueIndex];  // Hiển thị câu hoàn chỉnh ngay lập tức
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            ui_Contact.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            ui_Contact.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }

    // Bắt đầu hiển thị hộp thoại
    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueIndex = 0;  // Bắt đầu từ câu hội thoại đầu tiên
        dialogueText.text = string.Empty;  // Xóa nội dung cũ
        StartCoroutine(TypeSentence(dialogues[dialogueIndex]));  // Bắt đầu gõ chữ
    }

    // Hiển thị câu tiếp theo
    private void NextDialogue()
    {
        if (dialogueIndex < dialogues.Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeSentence(dialogues[dialogueIndex]));
        }
        else
        {
            dialoguePanel.SetActive(false);  // Ẩn hộp thoại khi hết hội thoại
        }
    }

    // Coroutine để gõ chữ từng chữ một
    private IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
