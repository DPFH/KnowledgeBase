export function getKnowledgeItemList({ commit }, knowledgeList) {
    return commit('getKnowledgeItemList', knowledgeList)
}

export function addKnowledgeToList({ commit }, newKnowledgeItem) {
    return commit('addKnowledgeToList', newKnowledgeItem)
}
