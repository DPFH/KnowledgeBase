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
                console.log(JSON.stringify(response))
                store.commit("addKnowledgeToList", response.data)
            }
        }).catch(function (error) {
            console.log(error)
        })
    }
}