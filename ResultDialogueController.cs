using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResultDialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    // ⭐ 특정 옷 이름 (Inspector에서 바꿀 수 있음)
    public string specialItemName = "eye2";

    void Start()
    {
        if (PlayerController.instance == null)
        {
            Debug.LogWarning("PlayerController 없음");
            return;
        }

        Dictionary<string, int> items = PlayerController.instance.itemCounts;

        SetDialogue(items);
    }

    void SetDialogue(Dictionary<string, int> items)
    {
        if (dialogueText == null) return;

        // 1️⃣ 특정 옷이 있으면
        if (HasItem(items, specialItemName))
        {
            dialogueText.text =
                "와!!!사륜안!!!아마테라스!!!\n너 덕분에 짱 멋있어졌어... 고마워!!!!";
            return;
        }

        // 2️⃣ 다른 옷 하나라도 있으면
        if (HasAnyClothes(items))
        {
            dialogueText.text =
                "오, 멋있어졌어!!\n" +
                "네 덕분이야...\n" +
                "정말 고마워!!!";
            return;
        }

        // 3️⃣ 아무 옷도 없으면
        dialogueText.text =
            "아무것도 안 가져왔잖아...\n" +
            "다음엔 좀 더 노력해.";
    }

    bool HasAnyClothes(Dictionary<string, int> items)
    {
        foreach (var item in items)
        {
            if (item.Value > 0)
                return true;
        }
        return false;
    }

    bool HasItem(Dictionary<string, int> items, string itemName)
    {
        return items.ContainsKey(itemName) && items[itemName] > 0;
    }
}
