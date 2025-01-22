using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkdestroy : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Tự hủy nếu đối tượng ra khỏi màn hình
        Destroy(gameObject);
    }

}
