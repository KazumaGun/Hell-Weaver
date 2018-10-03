using UnityEngine;

/// <summary>
/// Checks for clicks or taps on all objects.
/// </summary>
public class InputManager : MonoBehaviour
{
    [SerializeField] private bool m_perform3dRaycast = true;

    [SerializeField] private bool m_perform2dRaycast = true;

    [SerializeField] private Camera m_camera = null;

    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Run MouseAndKeyboard() only in the editor or a PC/Mac build.
        MouseAndKeyboard();
#endif
        
#if UNITY_ANDROID || UNITY_IOS
        // Run Touchscreen() only on Android or iOS.
        Touchscreen();
#endif
    }

    /// <summary>
    /// Execute when on PC.
    /// </summary>
    private void MouseAndKeyboard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProcessTap(Input.mousePosition);
        }
    }

    /// <summary>
    /// Execute when on touchscreen device.
    /// </summary>
    private void Touchscreen()
    {
        // Check if there's at least one touch.
        if(Input.touchCount > 0)
        {
            // Pass the position of the touch to ProcessTap().
            ProcessTap(Input.GetTouch(0).position);
        }
    }

    /// <summary>
    /// Processes a click or tap at /screenPoint/
    /// </summary>
    private void ProcessTap(Vector2 screenPoint)
    {
        // 3D
        if (m_perform3dRaycast)
        {
            // Transform mouse cursor position into a Ray
            Ray ray = m_camera.ScreenPointToRay(screenPoint);

            // Perform the raycast
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // You clicked on something!
                Collider hitObject = hitInfo.collider;

                // If anything is hit, send a message.
                // Call OnTap() on all scripts attached to the clicked object.
                hitObject.SendMessage("OnTap");
            }


        }

        // 2D

        // For 2D mode, camera must be orthographic!

        if (m_perform2dRaycast)
        {
            // Transform mouse cursor from screen space to world space.
            Vector3 worldPoint = m_camera.ScreenToWorldPoint(screenPoint);

            // Perform the raycast
            Collider2D hitCollider = Physics2D.OverlapPoint(worldPoint);

            if (hitCollider != null)
            {
                // You clicked on something!
                // If anything is hit, send a message.
                hitCollider.SendMessage("OnTap");
            }

        }
    }
}
