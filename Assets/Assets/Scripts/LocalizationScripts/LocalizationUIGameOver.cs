using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

public class LocalizationUIGameOver : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable _localizedStringTable;

    private StringTable _currentStringTable;

    private UIGameOver _uiController;

    private void OnEnable()
    {
        _uiController = GetComponent<UIGameOver>();
        if (_currentStringTable)
        {
            SetUIText(_currentStringTable);
        }
    }

    private IEnumerator Start()
    {
        // 2. Wait for the table to load asynchronously
        var tableLoading = _localizedStringTable.GetTableAsync();
        yield return tableLoading;
        _currentStringTable = tableLoading.Result;

        // At this point _currentStringTable can be used to
        // access our strings
        // 3. Retrieve the localized string
        SetUIText(_currentStringTable);
    }

    private void SetUIText(StringTable table)
    {
        _uiController.buttonPlayAgain.text = table["ButtonPlay"].LocalizedValue;
        _uiController.buttonQuit.text = table["ButtonExit"].LocalizedValue;
    }
}
