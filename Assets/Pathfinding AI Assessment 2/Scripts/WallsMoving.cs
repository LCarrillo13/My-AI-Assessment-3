using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WallsMoving : MonoBehaviour
{
    public float moveSpeed = 12;
    private Vector3 _moveDir;
    private CharacterController _charC;
    // Start is called before the first frame update
    private int moveWait;
    public bool isKeyCollected;


    private void OnValidate()
    {
       
        
        // Get the required component

            // If not null, set its values to the desired values
    }
    void Start()
    {
        moveSpeed = 12;
        moveWait = 6;
        _charC = GetComponent<CharacterController>();
        
        
    }
    private void Update()
    {
        if (isKeyCollected == true)
        {
            StartCoroutine(MoveNow());
            isKeyCollected = false;

        }
        _charC.Move(_moveDir * Time.deltaTime);
    }

    //randomly opens and closes door
    private IEnumerator MoveNow()
    {

        while (true)
        {
            yield return new WaitForSeconds(moveWait);

            float x = 1;
            while (x > 0)
            {
                _moveDir = transform.TransformDirection(0, 1, 0) * moveSpeed;
                x -= Time.deltaTime;
            }

            yield return new WaitForSeconds(0.6f);

            x = 1;
            while (x > 0)
            {
                _moveDir = transform.TransformDirection(0, 0, 0) * 0;
                x -= Time.deltaTime;
            }

            yield return new WaitForSeconds(14);
            x = 1;
            while (x > 0)
            {
                _moveDir = transform.TransformDirection(0, 1, 0) * -moveSpeed;
                x -= Time.deltaTime;
            }

            yield return new WaitForSeconds(moveWait);
            // Resets time.
            moveWait = Random.Range(4, 6);
        }
    }
}
