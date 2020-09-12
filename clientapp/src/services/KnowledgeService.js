import Api from '@/services/Api'
import store from '@/vuex/store'

export default {
    getKnowledgeItems() {
        return Api().get('knowledgeitems').then(function (response) {
            if (response.statusText === 'OK') {
                console.log("api get successfully called")
                console.log(JSON.stringify(response))

                store.commit("getKnowledgeItemList", response.data)
            }
        }).catch(function (error) {
            console.log(error)
        })
    }
}