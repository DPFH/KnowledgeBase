import Api from '@/services/Api'

export default {
    getKnowledgeItems() {
        return Api().get('weatherforecast').then(function (response) {
            if (response.statusText === 'OK') {
                console.log("api get successfully called")
                console.log(JSON.stringify(response))
            }
        }).catch(function (error) {
            console.log(error)
        })
    }
}