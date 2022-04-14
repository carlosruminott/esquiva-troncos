using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

public class LocalizationUIPauseMenu : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable _localizedStringTable;

    private StringTable _currentStringTable;

    private UIController _uiController;

    private void OnEnable()
    {
        _uiController = GetComponent<UIController>();
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
        _uiController.buttonResume.text = table["ButtonResume"].LocalizedValue;
        _uiController.buttonPlayAgain.text = table["ButtonPlay"].LocalizedValue;
        _uiController.buttonQuit.text = table["ButtonExit"].LocalizedValue;
    }
}
