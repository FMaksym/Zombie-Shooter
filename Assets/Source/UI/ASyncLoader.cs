using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ASyncLoader : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameObject _selectGun;

    [Header("Select Gun Panel")]
    [SerializeField] private SelectGunUI _selectGunPanel;

    [Header("Slider")]
    [SerializeField] private Slider _loadingSlider;

    private GetGunOfMenu getGunOfMenu;

    public void LoadGameButton(string levelToLoad)
    {
        _selectGunPanel.SetFinalyGunParametres();
        _selectGun.SetActive(false);
        _loadingScreen.SetActive(true);
        StartCoroutine(GameLoadASync(levelToLoad));
    }

    IEnumerator GameLoadASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
