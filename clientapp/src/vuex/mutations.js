﻿export const getKnowledgeItemList = (state, knowledgeList) => {
    state.knowledgeItemList = knowledgeList
}

export const addKnowledgeToList = (state, newKnowledgeItem) => {
    state.knowledgeItemList = state.knowledgeItemList.concat(newKnowledgeItem)
}

export const deleteKnowledgeFromList = (state, deleteId) => {
    const removalIndex = state.knowledgeItemList.findIndex(x => x.id === deleteId)
    if (removalIndex !== undefined && removalIndex !== -1) {
        state.knowledgeItemList.splice(removalIndex, 1);    //removes item at index that matches
    }
}

export const editKnowledgeFromList = (state, knowledgeItem) => {
    const editIndex = state.knowledgeItemList.findIndex(x => x.id === knowledgeItem.id)
    if (editIndex !== undefined && editIndex !== -1) {
        state.knowledgeItemList.splice(editIndex, 1, knowledgeItem); //removes old item at index and replaces with edited version
    }
}
