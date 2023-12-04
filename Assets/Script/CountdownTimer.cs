using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public GameObject[] countdownImages; // Assurez-vous d'assigner vos images ici dans l'ordre 3, 2, 1, Go!

    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        for (int i = 0; i < countdownImages.Length; i++)
        {
            countdownImages[i].SetActive(true);
            yield return new WaitForSeconds(1f);
            countdownImages[i].SetActive(false);
        }
    }
}
