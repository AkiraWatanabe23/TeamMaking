using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Image _settingPanel = default;
    [SerializeField] private Selectable _startElement = default;

    private Selectable _currentElement = default;

    private void Start()
    {
        if (_startElement != null)
        {
            _currentElement = _startElement;
            _currentElement.Select();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_settingPanel != null)
                _settingPanel.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_currentElement != null)
                _currentElement.OnDeselect(null);

            if (Input.GetKey(KeyCode.LeftShift) ||
                Input.GetKey(KeyCode.RightShift))
                _currentElement = _currentElement.FindSelectableOnUp();
            else
                _currentElement = _currentElement.FindSelectableOnDown();

            if (_currentElement != null)
                _currentElement.Select();
        }
    }
}
