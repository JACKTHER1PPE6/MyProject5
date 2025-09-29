using System.Collections;
using UnityEngine;

public class RowMover : MonoBehaviour
{
    public float movementInterval = 0.3f;
    public float downMovementAmt = 0.15f;
    public int initalRotation = 130;
    public int randomMin = 100, randomMax = 130;
    [SerializeField] SlotFrame mySlot;
    [ContextMenu("Run Test Method")]
   public void MoveRow()
    {
        StartCoroutine(MoveRowCO());
    }
    IEnumerator MoveRowCO()
    {
        for(int i = 0; i < initalRotation; i++)
        {
            Vector3 tempPos = transform.position;
            tempPos.y -= downMovementAmt;
            transform.position = tempPos;
            yield return new WaitForSeconds(movementInterval);
        }
        int furtherSpin = Random.Range(100, initalRotation);

        for(int i = 0;i < furtherSpin; i++)
        {
            Vector3 tempPos = transform.position;
            tempPos.y -= downMovementAmt;
            transform.position = tempPos;
            yield return new WaitForSeconds(movementInterval);
        }
        mySlot.CenterAlignSymbol();
    }
}
