using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Julian.InputSystem
{
    public class PlayerInputCenter : MonoBehaviour
    {
        [SerializeField] private PlayerInputManager m_playerInputManager;
        [SerializeField] private GameObject m_playerInputPrefab;

        private Dictionary<int, PlayerInputEvents> m_playerInputEvents;

        public static PlayerInputCenter Instance { get; private set; }
        public static Dictionary<int, PlayerInputEvents> PlayerInputEvents { get => Instance.m_playerInputEvents; }
        public static int PlayerCount
        {
            get
            {
                return Instance.m_playerInputEvents.Count;
            }
        }


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
            }

            m_playerInputEvents = new Dictionary<int, PlayerInputEvents>();
            m_playerInputManager.playerPrefab = m_playerInputPrefab;


            foreach (var device in InputDevice.all)
            {
                m_playerInputManager.JoinPlayer();
            }

            OnDevicesReset?.Invoke();
            Debug.Log("Devices Reset");
        }
        public delegate void DevicesResetAction();
        public event DevicesResetAction OnDevicesReset;
        public void OnControllerAdded(PlayerInput joinedPlayer)
        {
            joinedPlayer.transform.SetParent(this.transform);
            m_playerInputEvents.Add(joinedPlayer.user.index, joinedPlayer.GetComponent<PlayerInputEvents>());
        }



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
