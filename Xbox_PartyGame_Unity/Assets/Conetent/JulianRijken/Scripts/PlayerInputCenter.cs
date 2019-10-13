using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Julian.InputSystem
{
    public class PlayerInputCenter : MonoBehaviour
    {

        public static PlayerInputCenter Instance { get; private set; }
        public static Dictionary<int, PlayerInputEvents> PlayerInputEvents { get => Instance.m_playerInputEvents; }
        public static int PlayerEventsCount { get => Instance.m_playerInputEvents.Count; }
        public static bool PlayerExists(int player)
        {
            return Instance.m_playerInputEvents.ContainsKey(player);
        }
        public static int SelectedPlayerCount
        {
            get
            {
                return Instance.m_selectedPlayerCount;
            }
            set
            {
                Instance.m_selectedPlayerCount = value;
            }
        }


        [SerializeField] private PlayerInputEvents m_playerEventsPrefab;

        private Dictionary<int, PlayerInputEvents> m_playerInputEvents;
        private int m_selectedPlayerCount;




        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance.gameObject);
            }
            else if (this != Instance)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnEnable()
        {
            ResetDevices();
        }


        public void ResetDevices()
        {
            if (m_playerInputEvents != null)
            {
                foreach (var player in m_playerInputEvents)
                {
                    Destroy(player.Value.gameObject);
                }

                m_playerInputEvents.Clear();
            }
            else
            {
                m_playerInputEvents = new Dictionary<int, PlayerInputEvents>();
            }

            for (int i = 0; i < InputDevice.all.Count; i++)
            {
                PlayerInputEvents playerInputEvents =  Instantiate(m_playerEventsPrefab,this.transform);
  
                m_playerInputEvents.Add(playerInputEvents.m_playerInput.user.index, playerInputEvents);
            }


            OnDevicesReset?.Invoke();
            Debug.Log("Devices Reset");

        }
        public delegate void DevicesResetAction();
        public event DevicesResetAction OnDevicesReset;

        public void FireOnDeviceLost()
        {
            OnDeviceLost?.Invoke();
            Debug.Log("DEVICE LOST RECCONECT DEVICE");
        }
        public delegate void DeviceLostAction();
        public event DeviceLostAction OnDeviceLost;

        public void FireOnDeviceRegained()
        {
            OnDeviceRegained?.Invoke();
            Debug.Log("DEVICE RECCONECTED");

        }
        public delegate void DeviceRegainedAction();
        public event DeviceRegainedAction OnDeviceRegained;


    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;

//namespace Julian.InputSystem
//{
//    public class PlayerInputCenter : MonoBehaviour
//    {
//        [SerializeField] private PlayerInputManager m_playerInputManager;
//        [SerializeField] private GameObject m_playerInputPrefab;

//        private Dictionary<int, PlayerInputEvents> m_playerInputEvents;
//        private int m_selectedPlayerCount;

//        public static PlayerInputCenter Instance { get; private set; }
//        public static Dictionary<int, PlayerInputEvents> PlayerInputEvents { get => Instance.m_playerInputEvents; }
//        public static int PlayerEventsCount { get => Instance.m_playerInputEvents.Count; }
//        public static bool PlayerExists(int player)
//        {
//            return Instance.m_playerInputEvents.ContainsKey(player);
//        }
//        public static int SelectedPlayerCount
//        {
//            get
//            {
//                return Instance.m_selectedPlayerCount;
//            }
//            set
//            {
//                Instance.m_selectedPlayerCount = value;
//            }
//        }


//        private void Awake()
//        {
//            if (Instance == null)
//            {
//                Instance = this;
//                DontDestroyOnLoad(Instance.gameObject);
//            }
//            else if (this != Instance)
//            {
//                Destroy(this.gameObject);
//            }
//        }

//        private void OnEnable()
//        {
//            ResetDevices();
//        }


//        public void ResetDevices()
//        {

//            if (m_playerInputEvents != null)
//            {
//                foreach (var player in m_playerInputEvents)
//                {
//                    Destroy(player.Value.gameObject);
//                }
//            }

//            m_playerInputEvents = new Dictionary<int, PlayerInputEvents>();
//            m_playerInputManager.playerPrefab = m_playerInputPrefab;


//            foreach (var device in InputDevice.all)
//            {
//                m_playerInputManager.JoinPlayer();
//            }

//            OnDevicesReset?.Invoke();
//            Debug.Log("Devices Reset");
//        }
//        public delegate void DevicesResetAction();
//        public event DevicesResetAction OnDevicesReset;
//        public void OnConStrollerAdded(PlayerInput joinedPlayer)
//        {
//            joinedPlayer.transform.SetParent(this.transform);
//            m_playerInputEvents.Add(joinedPlayer.user.index, joinedPlayer.GetComponent<PlayerInputEvents>());
//        }

//        public void FireOnDeviceLost()
//        {
//            OnDeviceLost?.Invoke();
//            Debug.Log("DEVICE LOST RECCONECT DEVICE");
//        }
//        public delegate void DeviceLostAction();
//        public event DeviceLostAction OnDeviceLost;

//        public void FireOnDeviceRegained()
//        {
//            OnDeviceRegained?.Invoke();
//            Debug.Log("DEVICE RECCONECTED");

//        }
//        public delegate void DeviceRegainedAction();
//        public event DeviceRegainedAction OnDeviceRegained;


//    }
//}
