using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRules : MonoBehaviour
{
    [SerializeField] private GameObject? _block;

    private static bool _isLoaded = false;

    private void Awake()
    {
        if (!_isLoaded)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Scene", "Menu"));
            GameSettings.MainVolume = PlayerPrefs.GetFloat("Volume", GameSettings.MainVolume);
            _isLoaded = true;
        }
        if (_block != null)
        {
            var xBlock = PlayerPrefs.GetFloat("BlockPosX");
            var yBlock = PlayerPrefs.GetFloat("BlockPosY");
            _block.transform.position = new Vector3(xBlock, yBlock, _block.transform.position.z);
            Debug.Log(_block.transform.position);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
