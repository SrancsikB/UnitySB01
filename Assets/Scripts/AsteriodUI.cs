using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsteriodUI : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    [SerializeField] Gradient hpColor;

    [SerializeField] Damageable target;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Button restartButton;

    [SerializeField] String sceneName = "";

    private void Start()
    {
        target.HPChanged += FreshUI;
        target.Died += OpenGameOverUI;
        FreshUI();
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDestroy()
    {
        target.HPChanged -= FreshUI;
        target.Died -= OpenGameOverUI;
        restartButton.onClick.RemoveListener(RestartGame);
    }

    private void OpenGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    private void FreshUI()
    {
        if (hpText == null)
            return;


        hpText.text = Mathf.CeilToInt(target.GetCurrentHP).ToString("0") + "/" + target.GetStartHP.ToString("0") + " HP";
        hpText.color = hpColor.Evaluate(target.GetCurrentHP / target.GetStartHP);




    }

    void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
