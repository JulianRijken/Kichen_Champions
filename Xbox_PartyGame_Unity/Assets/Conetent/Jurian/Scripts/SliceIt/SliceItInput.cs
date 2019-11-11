using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class SliceItInput : MonoBehaviour
{
    [SerializeField, Header("Required")] private int m_player;
    [SerializeField] private GameObject cucumber;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject cucumberclone;

    private float scale;
    private Vector2 m_MovementInput;
    private Vector3 input;
    private Vector3 startpos;
    private bool done;

    private int slices;
    private bool AddPoint;
    private bool debounce;

    private Vector3[] Directions;
    // Start is called before the first frame update
    void Start()
    {
        Directions = new Vector3[2];
        Directions[0] = new Vector3(1, 1, 0);
        Directions[1] = new Vector3(-1, 1, 0);

        scale = 2.5f;
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove += StickMovement;
        }
        startpos = cucumber.transform.position;
        done = false;
        slices = 0;
    }

    IEnumerator destroyClone(GameObject x)
    {
        yield return new WaitForSeconds(2);
        Destroy(x);
    }

    private void StickMovement(InputAction.CallbackContext conext)
    {
        if (!done)
            m_MovementInput = conext.ReadValue<Vector2>();
    }

    private void MoveCucumber()
    {
        input = new Vector3(m_MovementInput.x, 0, 0);
        Vector3 topos = Vector3.Lerp(startpos, startpos + input, 10f);
        cucumber.transform.position = Vector3.MoveTowards(cucumber.transform.position, Vector3.Lerp(cucumber.transform.position, topos, Time.deltaTime * 20), 10f);
        if (m_MovementInput.x >= 0.75f && !debounce)
        {
            AddPoint = true;
            debounce = true;
        }
        if (m_MovementInput.x <= -0.75f)
        {
            debounce = false;
        }
    }
    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove -= StickMovement;
        }
    }
    private void Update()
    {
        MoveCucumber();

        if (AddPoint)
        {
            GameObject clone = Instantiate(cucumberclone);
            clone.transform.position = spawnpoint.position;

            int random = Random.Range(0, 2);
            int multiplier = Random.Range(50, 500);
            clone.GetComponent<Rigidbody2D>().AddForce(Directions[random]*multiplier);
            slices += 1;
            AddPoint = false;
            StartCoroutine(destroyClone(clone));
        }

        if (slices == 30 && !done)
        {
            done = true;
            MiniGameManager.SetPlayerDone(m_player);
        }
    }
}
