import Api from '@/services/Api'
import store from '@/vuex/store'

export default {
    getKnowledgeItems() {
        return Api().get('knowledgeitem').then(function (response) {
            if (response.statusText === 'OK') {
                console.log("api get successfully called")
                //console.log(JSON.stringify(response))

                store.commit("getKnowledgeItemList", response.data)
            }
        }).catch(function (error) {
            console.log(error)
        })
    },
    addKnowledgeItem(data) {
        return Api().post('knowledgeitem', data).then(function (response) {
            if (response.statusText === 'OK') {
                console.log("api create successfully called")
                //console.log(JSON.stringify(response))
                
                store.commit("addKnowledgeToList", response.data)
            }
        }).catch(function (error) {
            console.log(error)
        })
    },
    deleteKnowledgeItem(id) {
        return Api().delete('knowledgeitem/' + id).then(function (response) {
            if (response.statusText === 'No Content') {
                console.log("api delete successfully called")
                //console.log(JSON.stringify(response))
                store.commit("deleteKnowledgeFromList", id)
            }
        }).catch(function (error) {
            console.log(error)
        })
    }
}