using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saving;
using Utils;


namespace RPG.Quests
{
    public class QuestList : MonoBehaviour, ISaveable, IPredicateEvaluator
    {
        List<QuestStatus> statuses = new List<QuestStatus>();

        public event Action onUpdate;

        private void Update() {
            CompleteObjectivesByPredicates();
        }

        public void AddQuest(Quest quest)
        {
            if (HasQuest(quest)) return;
            QuestStatus newStatus = new QuestStatus(quest);
            statuses.Add(newStatus);
            if (onUpdate != null)
            {
                onUpdate();
            }
        }

        public void CompleteObjective(Quest quest, string objective)
        {
            QuestStatus status = GetQuestStatus(quest);
            status.CompleteObjective(objective);
            if (status.IsComplete())
            {
                GiveReward(quest);
            }
            if (onUpdate != null)
            {
                onUpdate();
            }
        }

        public bool HasQuest(Quest quest)
        {
            return GetQuestStatus(quest) != null;
        }

        public IEnumerable<QuestStatus> GetStatuses()
        {
            return statuses;
        }

        private QuestStatus GetQuestStatus(Quest quest)
        {
            foreach (QuestStatus status in statuses)
            {
                if (status.GetQuest() == quest)
                {
                    return status;
                }
            }
            return null;
        }

        private void GiveReward(Quest quest)
        {
            foreach (var reward in quest.GetRewards())
            {
                // 인벤토리 매니저에서 퀘스트가 끝난 후 인벤토리의 첫번째로 빈칸에 리워드 아이템을 주는 코드 -> 인벤토리 구현완료 후 활성화 바람
                //bool success = GetComponent<InventoryManager>().AddToFirstEmptySlot(reward.item, reward.number);
                // 만약성공한다면 보상아이템을 줌 아이템 스크립트에 Dropitem 추가해야함
                /*if (!success)
                {
                    GetComponent<Item>().DropItem(reward.item, reward.number);
                }*/
            }
        }

        private void CompleteObjectivesByPredicates()
        {
            foreach (QuestStatus status in statuses)
            {
                if (status.IsComplete()) continue;
                Quest quest = status.GetQuest();
                foreach (var objective in quest.GetObjectives())
                {
                    if (status.IsObjectiveComplete(objective.reference)) continue;
                    if (!objective.usesCondition) continue;

                    /*if (objective.completionCondition.Check(GetComponents<IPredicateEvaluator>()))
                    {
                        CompleteObjective(quest, objective.reference);
                    }*/
                }
            }
        }

        public object CaptureState()
        {
            List<object> state = new List<object>();
            foreach (QuestStatus status in statuses)
            {
                state.Add(status.CaptureState());
            }
            return state;
        }

        public void RestoreState(object state)
        {
            List<object> stateList = state as List<object>;
            if (stateList == null) return;

            statuses.Clear();
            foreach (object objectState in stateList)
            {
                statuses.Add(new QuestStatus(objectState));
            }
        }

        public bool? Evaluate(string predicate, string[] parameters)
        {
            switch (predicate)
            {
                case "HasQuest": 
                return HasQuest(Quest.GetByName(parameters[0]));
                case "CompletedQuest":
                return GetQuestStatus(Quest.GetByName(parameters[0])).IsComplete();
            }

            return null;
        }
    }

}