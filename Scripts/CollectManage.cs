using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollectManage : MonoBehaviour
{
    public int collectedSoFar = 0;
    public int totalCollectables = 11;
    public TextMeshProUGUI collectText;

    private void Update()
    {
       collectText.text = "" + collectedSoFar + "/" + totalCollectables+" Collectables";
       if (collectedSoFar >= totalCollectables) {
           SceneManager.LoadScene("WinScreen");
       }
    }

}