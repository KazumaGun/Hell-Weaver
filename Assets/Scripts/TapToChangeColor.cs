using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach this to an object to change its color when it is clicked or tapped.
/// </summary>
public class TapToChangeColor : MonoBehaviour
{
    private enum Mode
    {
        Collider,
        Button
    }

    [SerializeField] private Mode m_mode = Mode.Collider;

    [SerializeField] private Color m_color = Color.blue;

    /// <summary>
    /// Will get called by InputManager when this object is clicked.
    /// </summary>
    public void OnTap()
    {
        if (m_mode == Mode.Collider)
            this.GetComponent<Renderer>().material.color = m_color;
        else if (m_mode == Mode.Button)
            this.GetComponent<Image>().color = m_color;
    }
}
