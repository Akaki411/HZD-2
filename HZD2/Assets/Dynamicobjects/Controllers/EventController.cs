using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour
{
    public static EventController singleton { get; private set; }
    
    //***Mouse***
    [HideInInspector] public Vector2 mousePosition = new Vector2(0, 0);
    private float _halfWidth;
    private float _halfHeight;
    
    //***Events***
    //Jump
    public delegate void JumpDelegate();
    public event JumpDelegate Jump;
    
    //Flip
    public delegate void FlipRightDelegate();
    public event FlipRightDelegate FlipRight;
    public delegate void FlipLeftDelegate();
    public event FlipLeftDelegate FlipLeft;
    [HideInInspector] public bool isRight;
    
    //Run
    public delegate void StartRunDelegate();
    public event StartRunDelegate StartRun;
    public delegate void StopRunDelegate();
    public event StopRunDelegate StopRun;
    
    //UI
    public UnityEvent<bool> openMenu;
    private bool menuOpened = false;

    private void Awake()
    {
        GameObject ec = GameObject.FindGameObjectWithTag("EventController");
        if (ec)
        {
            Destroy(gameObject);
        }

        singleton = this;
        gameObject.tag = "EventController";
        _halfWidth = Screen.width / 2;
        _halfHeight = Screen.height / 2;

        isRight = Input.mousePosition.x - _halfWidth > 0;
    }
    private void Update()
    {
        mousePosition.x = Input.mousePosition.x - _halfWidth;
        mousePosition.y = Input.mousePosition.y - _halfHeight;

        if (mousePosition.x > 0 && !isRight)
        {
            FlipRight?.Invoke();
            isRight = true;
        }

        if (mousePosition.x < 0 && isRight)
        {
            FlipLeft?.Invoke();
            isRight = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartRun?.Invoke();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRun?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openMenu.Invoke(!menuOpened);
            menuOpened = !menuOpened;
        }
    }

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
