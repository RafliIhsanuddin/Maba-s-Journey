using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerPart2 : MonoBehaviour
{


    [SerializeField] private GameObject Player;

    [SerializeField] private PanitiaPenjagaDialogManajer dialogPanitiaPenjaga;

    private bool triggered;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !triggered){
            dialogPanitiaPenjaga.TriggerStartDialog();
            triggered = true;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !triggered)
        {
            dialogPanitiaPenjaga.TriggerStartDialog();
            triggered = true;

            // Mengubah skala x dari objek Player menjadi 0.5
            Vector3 currentScale = Player.transform.localScale;
            Player.transform.localScale = new Vector3(0.5f, currentScale.y, currentScale.z);
        }

        /*if (other.CompareTag("Player"))
        {
            dialogPanitiaPenjaga.TriggerStartDialog();
        }*/
    }


    /*IEnumerator EnableTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(true);
    }
*/

}
