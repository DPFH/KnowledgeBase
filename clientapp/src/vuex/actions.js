export function getKnowledgeItemList({ commit }, knowledgeList) {
    return commit('getKnowledgeItemList', knowledgeList)
}

export function addKnowledgeToList({ commit }, newKnowledgeItem) {
    return commit('addKnowledgeToList', newKnowledgeItem)
}

export function deleteKnowledgeFromList({ commit }, deleteId) {
    return commit('deleteKnowledgeFromList', deleteId)
}
