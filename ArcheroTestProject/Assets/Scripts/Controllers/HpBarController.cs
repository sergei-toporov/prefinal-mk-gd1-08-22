using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{

    protected TextMesh text;

    protected ObjectControllerBase parent;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
        if (transform.parent != null && transform.parent.TryGetComponent(out ObjectControllerBase parObject))
        {
            parent = parObject;
            OnParentHpChange(gameObject);
        }
        else
        {
            Debug.LogError("This HPBar has no parent... We all gonna die!");
        }
    }

    public void OnParentHpChange(GameObject go)
    {
        Debug.Log("GameObject: " + go.name);
        string tmpText = $"{parent.HP} / {parent.InitialHP}";
        text.text = tmpText;
    }
}
