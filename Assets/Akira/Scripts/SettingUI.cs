using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Image _settingPanel = default;
    [SerializeField] private Selectable[] _buttons = new Selectable[3];

    private Selectable _startElement = default;
    private Selectable _currentElement = default;
    private int _index = 0;

    private void Start()
    {
        _startElement = _buttons[2];
        _index = 2;

        _currentElement = _startElement;
        _currentElement.Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_settingPanel != null)
                _settingPanel.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _index++;
            if (_index >= _buttons.Length)
            {
                _index = 0;
            }

            _currentElement = _buttons[_index];
            _currentElement.Select();
        }
        else if (Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            _index--;
            if (_index < 0)
            {
                _index = _buttons.Length - 1;
            }

            _currentElement = _buttons[_index];
            _currentElement.Select();
        }
    }
}
