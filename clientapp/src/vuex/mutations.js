export const getKnowledgeItemList = (state, knowledgeList) => {
    state.knowledgeItemList = knowledgeList
}

export const addKnowledgeToList = (state, newKnowledgeItem) => {
    state.knowledgeItemList = state.knowledgeItemList.concat(newKnowledgeItem)
}

export const deleteKnowledgeFromList = (state, deleteId) => {
    const removalIndex = state.knowledgeItemList.findIndex(x => x.id === deleteId)
    if (removalIndex !== undefined) {
        state.knowledgeItemList.splice(removalIndex, 1);
    }
}
