import Vue from 'vue'
import Router from 'vue-router'
import SplashHeader from '@/components/SplashHeader'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'SplashHeader',
            component: SplashHeader,
            meta: {
                title: 'SplashHeader',
                type: ''
            }
        }
    ]
})
