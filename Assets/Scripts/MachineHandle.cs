using System.Collections;
using UnityEngine;

public class MachineHandle : MonoBehaviour
{
   [SerializeField] SlotMachineManager slotMachineManager;
    [SerializeField] GameObject handleUp, handleDown;
    
    private void OnMouseDown()
    {
        if (!slotMachineManager.isSpining)
        {
            StartCoroutine(StartMachine());
        }
    }

    IEnumerator StartMachine()
    {
        handleUp.SetActive(false);
        handleDown.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        slotMachineManager.StartSpin();
        handleDown.SetActive(false);
        handleUp.SetActive(true);
    }
}
