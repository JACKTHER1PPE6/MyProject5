using System;
using System.Collections;
using UnityEngine;

public class SlotFrame : MonoBehaviour
{
    public SlotSymbol ChoosenSymbol;
    public GameObject Row;
    public float downMovementAmt = 0.15f;
    public float movementInterval = 0.3f;
    public bool isSpinning = true;
    public float distance = 0.3f; 
    public SymbolMarkEnum symbolMark;
    public Action<SymbolMarkEnum> GottenSpin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSpinning) return;
        
            
        
        ChoosenSymbol = collision.gameObject.GetComponent<SlotSymbol>();
    }

    [ContextMenu("Run Test Method")]

    public void CenterAlignSymbol()
    {
        isSpinning = false;
        //ChoosenSymbol.transform.position = transform.position;
        StartCoroutine(CenterAlignSymbolCO());
       

    }
    IEnumerator CenterAlignSymbolCO()
    {
        
        while (ChoosenSymbol.gameObject.transform.position.y - transform.position.y > distance)
        {
            print(ChoosenSymbol.transform.position);
            Vector3 tempPos = Row.transform.position;
            tempPos.y -= downMovementAmt;
            Row.transform.position = tempPos;
            yield return new WaitForSeconds(movementInterval);
        }

        symbolMark = ChoosenSymbol.symbolMarkEnum;
        GottenSpin(symbolMark);
    }
}
