using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InGameShop : MonoBehaviour {

    public Canvas payMethod;
    public GameObject success, failed, choose;
    private Camera mainCamera;
    // Use this for initialization
    void Awake ()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
        gameObject.GetComponent<Canvas>().worldCamera = mainCamera;        

    }
    public void openAd()
    {
        payMethod.enabled = true;
        choose.SetActive(true);
    }
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Debug.Log("startAD");
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                Player.PlayerInstance.status.life = 5;
                Player.PlayerInstance.RefreshLife();
                Player.PlayerInstance.DeathRestart();                
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                closeWindows();
                failed.SetActive(true);
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                closeWindows();
                failed.SetActive(true);
                break;
        }
    }

    public void closeWindows()
    {
        choose.SetActive(false);
        failed.SetActive(false);
        success.SetActive(false);
        payMethod.enabled = false;
    }
    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
