export const getKnowledgeItemList = (state, knowledgeList) => {
    state.knowledgeItemList = knowledgeList
}

export const addKnowledgeToList = (state, newKnowledgeItem) => {
    state.knowledgeItemList = state.knowledgeItemList.concat(newKnowledgeItem)
}
