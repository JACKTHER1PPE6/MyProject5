using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    [SerializeField] List<RowMover> rows;
    [SerializeField] SlotFrame[] frames;
    [SerializeField] TMP_Text gameOverText;
    private List<SymbolMarkEnum> symbolGotten = new List<SymbolMarkEnum>();
    public bool isSpining;
    private void Start()
    {
        foreach (SlotFrame frame in frames)
        {
            frame.GottenSpin += MarkList;
        }
    }
    [ContextMenu("Run Test Method")]
    public void StartSpin()
    {
        isSpining = true;
        gameOverText.text = "";
        foreach (var row in rows)
        {
            row.MoveRow();
        }
    }

    public void MarkList(SymbolMarkEnum markEnum)
    {
        symbolGotten.Add(markEnum);
        if (symbolGotten.Count == 3) CheckSymbols();

    }
    void CheckSymbols()
    {
        if (symbolGotten[0] == symbolGotten[1] && symbolGotten[1] == symbolGotten[2])
        {
            gameOverText.text = "You win";
        }
        else
        {
            gameOverText.text = "you lose";
        }
        symbolGotten.Clear();
        isSpining = false;
    }
}
