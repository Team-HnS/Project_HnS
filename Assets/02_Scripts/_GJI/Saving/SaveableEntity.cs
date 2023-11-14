using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Saving
{
    /// <summary>
    /// ISaveable 컴포넌트를 가진 모든 GameObject에 배치되어야 합니다.
    ///
    /// 이 클래스는 GameObject에 씬 파일에서 사용되는 고유 ID를 제공합니다.
    /// 이 ID는 이 GameObject과 관련된 상태를 저장하고 복원하는 데 사용됩니다.
    /// 이 ID를 수동으로 설정하여 씬 간에 GameObject를 연결할 수 있습니다(예: 반복되는 캐릭터, 플레이어 또는 스코어 보드).
    /// 프리팹에서는 모든 인스턴스를 연결하려면 주의해야 합니다.
    /// </summary>
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        // 설정 데이터
        [Tooltip("만약 비어있다면 씬 파일에서 자동으로 고유 ID가 생성됩니다. 프리팹에서는 모든 인스턴스를 연결하려면 설정하지 마세요.")]
        [SerializeField] string uniqueIdentifier = "";

        // 캐시된 상태
        static Dictionary<string, SaveableEntity> globalLookup = new Dictionary<string, SaveableEntity>();

        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        /// <summary>
        /// 이 컴포넌트에 있는 모든 `ISaveable`의 상태를 캡처하고 이 상태를 나중에 복원할 수 있는 `System.Serializable` 객체를 반환합니다.
        /// </summary>
        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }
            return state;
        }

        /// <summary>
        /// `CaptureState`에 의해 캡처된 상태를 복원합니다.
        /// </summary>
        /// <param name="state">`CaptureState`에 의해 반환된 동일한 객체</param>
        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                string typeString = saveable.GetType().ToString();
                if (stateDict.ContainsKey(typeString))
                {
                    saveable.RestoreState(stateDict[typeString]);
                }
            }
        }

        // 비공개 멤버

#if UNITY_EDITOR
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            globalLookup[property.stringValue] = this;
        }
#endif

        private bool IsUnique(string candidate)
        {
            if (!globalLookup.ContainsKey(candidate)) return true;

            if (globalLookup[candidate] == this) return true;

            if (globalLookup[candidate] == null)
            {
                globalLookup.Remove(candidate);
                return true;
            }

            if (globalLookup[candidate].GetUniqueIdentifier() != candidate)
            {
                globalLookup.Remove(candidate);
                return true;
            }

            return false;
        }
    }
}
