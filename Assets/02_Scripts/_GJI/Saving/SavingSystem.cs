using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDevTV.Saving
{
    /// <summary>
    /// 이 컴포넌트는 저장 시스템에 대한 인터페이스를 제공합니다. 씬을 저장하고 복원하는
    /// 메소드를 제공합니다.
    ///
    /// 이 컴포넌트는 한 번 생성되어 이후의 모든 씬에서 공유되어야 합니다.
    /// </summary>
    public class SavingSystem : MonoBehaviour
    {
        /// <summary>
        /// 저장된 마지막 씬을 불러오고 상태를 복원합니다. 이것은 코루틴으로 실행되어야 합니다.
        /// </summary>
        /// <param name="saveFile">불러오기에 사용할 저장 파일</param>
        public IEnumerator LoadLastScene(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            if (state.ContainsKey("lastSceneBuildIndex"))
            {
                buildIndex = (int)state["lastSceneBuildIndex"];
            }
            yield return SceneManager.LoadSceneAsync(buildIndex);
            RestoreState(state);
        }

        /// <summary>
        /// 현재 씬을 제공된 저장 파일에 저장합니다.
        /// </summary>
        /// <param name="saveFile">저장에 사용할 파일 이름</param>
        public void Save(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            CaptureState(state);
            SaveFile(saveFile, state);
        }

        /// <summary>
        /// 주어진 저장 파일에서 상태를 삭제합니다.
        /// </summary>
        /// <param name="saveFile">삭제할 상태의 저장 파일</param>
        public void Delete(string saveFile)
        {
            File.Delete(GetPathFromSaveFile(saveFile));
        }

        /// <summary>
        /// 주어진 저장 파일에서 상태를 불러옵니다.
        /// </summary>
        /// <param name="saveFile">불러올 상태의 저장 파일</param>
        public void Load(string saveFile)
        {
            RestoreState(LoadFile(saveFile));
        }

        /// <summary>
        /// 저장된 파일 목록을 가져옵니다.
        /// </summary>
        /// <returns>저장된 파일 목록</returns>
        public IEnumerable<string> ListSaves()
        {
            foreach (string path in Directory.EnumerateFiles(Application.persistentDataPath))
            {
                if (Path.GetExtension(path) == ".sav")
                {
                    yield return Path.GetFileNameWithoutExtension(path);
                }
            }
        }

        // PRIVATE

        /// <summary>
        /// 주어진 저장 파일에서 데이터를 읽어옵니다.
        /// </summary>
        /// <param name="saveFile">불러올 저장 파일의 이름</param>
        /// <returns>불러온 데이터</returns>
        private Dictionary<string, object> LoadFile(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path))
            {
                return new Dictionary<string, object>();
            }
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// 주어진 저장 파일에 데이터를 저장합니다.
        /// </summary>
        /// <param name="saveFile">저장할 파일의 이름</param>
        /// <param name="state">저장할 데이터</param>
        private void SaveFile(string saveFile, object state)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Saving to " + path);
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        /// <summary>
        /// 현재 씬의 상태를 저장할 수 있도록 데이터를 캡처합니다.
        /// </summary>
        /// <param name="state">저장할 데이터를 담을 딕셔너리</param>
        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                state[saveable.GetUniqueIdentifier()] = saveable.CaptureState();
            }

            state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;
        }

        /// <summary>
        /// 저장된 상태를 현재 씬에 복원합니다.
        /// </summary>
        /// <param name="state">복원할 상태 데이터를 담은 딕셔너리</param>
        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                string id = saveable.GetUniqueIdentifier();
                if (state.ContainsKey(id))
                {
                    saveable.RestoreState(state[id]);
                }
            }
        }

        /// <summary>
        /// 저장 파일의 전체 경로를 가져옵니다.
        /// </summary>
        /// <param name="saveFile">저장 파일의 이름</param>
        /// <returns>저장 파일의 전체 경로</returns>
        private string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }
}
