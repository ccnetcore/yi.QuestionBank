import Vue from 'vue'
import VueRouter from 'vue-router'
import Layout from '@/components/Layout'
import Index from '@/views/Index'
import question from '@/views/question'
import top from '@/views/top'
import search from '@/views/search'
import author from '@/views/author'

import login from '@/views/login'
import register from '@/views/register'



Vue.use(VueRouter)

const routes = [{
        path: '/login',
        name: 'login',
        component: login
    },
    {
        path: '/register',
        name: 'register',
        component: register
    },
    {
        path: '/',
        name: 'Layout',
        component: Layout,
        redirect: "/index",
        children: [{
                path: "/index",
                name: "Index",
                component: Index
            },
            {
                path: "/question",
                name: "question",
                component: question
            },
            {
                path: "/top",
                name: "top",
                component: top
            },
            {
                path: "/search",
                name: "search",
                component: search
            },
            {
                path: "/author",
                name: "author",
                component: author
            }

        ]
    }
]

const router = new VueRouter({
    // mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router