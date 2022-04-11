using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

public class LocalizationUIPlayerPanel : MonoBehaviour
{

    [SerializeField]
    private LocalizedStringTable _localizedStringTable;

    private StringTable _currentStringTable;

    private IEnumerator Start()
    {
        // 2. Wait for the table to load asynchronously
        var tableLoading = _localizedStringTable.GetTableAsync();
        yield return tableLoading;
        _currentStringTable = tableLoading.Result;

        // At this point _currentStringTable can be used to
        // access our strings
        // 3. Retrieve the localized string     
        UIPlayerPanel.instance.lifeLeft.text = _currentStringTable["LifeLeft"].LocalizedValue;
        UIPlayerPanel.instance.impulseTimer.text = _currentStringTable["ImpulseTimer"].LocalizedValue;
        UIPlayerPanel.instance.speed.text = _currentStringTable["Speed"].LocalizedValue;
    }
}
