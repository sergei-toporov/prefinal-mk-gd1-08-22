using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ObjectControllerBase : MonoBehaviour
{
    protected float initialHP;
    public float InitialHP { get => initialHP; }

    [SerializeField] protected float hp = 1000.0f;
    public float HP { get => hp; }

    [SerializeField] protected Vector3 initialPosition;

    protected float movementLimits = 5.0f;

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected Vector3 movementDirection;

    protected float movementSpeed = 2.0f;

    protected void Awake()
    {
        initialHP = hp;
        initialPosition = transform.position;
        movementDirection = Random.value > 0.5f ? Vector3.right : Vector3.left;
        targetPosition = new Vector3(
            transform.position.x + (movementDirection.x * movementLimits),
            transform.position.y,
            transform.position.z
            );
    }
    public virtual void OnKeyRAction()
    {
        Debug.Log("Key 'R' pressed by " + gameObject.name);
        EventManager.Manager.OnHPChange.TriggerEvent();
    }

    public virtual void OnKeySpaceAction()
    {
        Debug.Log("Key 'Space' pressed by " + gameObject.name);
        EventManager.Manager.OnHPChange.TriggerEvent();
    }

    protected void Update()
    {
        transform.Translate(Time.deltaTime * movementSpeed * movementDirection);

        if (transform.position.x > (initialPosition.x + movementLimits))
        {
            targetPosition.x = initialPosition.x - movementLimits;
            movementDirection *= -1.0f;
        }

        if (transform.position.x < (initialPosition.x - movementLimits))
        {
            targetPosition.x = initialPosition.x + movementLimits;
            movementDirection *= -1.0f;
        }
    }
}
