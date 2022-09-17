using System.Collections;
using TMPro;
using UnityEngine;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    private TypeWriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypeWriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject resourceDialogue)
    {
        if (GameSettings.enableDialogBox)
        {
            dialogueBox.SetActive(true);
            StartCoroutine(StepThroughDialogue(resourceDialogue));
        }
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(1);

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
        }

        CloseDialogueBox();
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                typewriterEffect.Stop();
            }
        }
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
