using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2 : ObjectControllerBase
{
    // Start is called before the first frame update
    public override void OnKeyRAction()
    {
        hp += Random.Range(1.0f, 5.0f);
        base.OnKeyRAction();

    }

    public override void OnKeySpaceAction()
    {
        hp -= Random.Range(1.0f, 5.0f);
        base.OnKeySpaceAction();
    }
}
