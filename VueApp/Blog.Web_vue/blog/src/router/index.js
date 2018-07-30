import Vue from 'vue'
import Router from 'vue-router'
import Posts from '@/components/posts'
import PostView from '@/components/postView'
import TagView from '@/components/tagView'

Vue.use(Router)

export default new Router({
  hashbang: false,
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'home',
      component: Posts
    },
    {
      path: '/posts',
      name: 'posts',
      component: Posts
    },
    {
      path: '/tags',
      name: 'tagView',
      component: TagView
    },
    {
      path: '/posts/:post_id',
      name: 'postView',
      component: PostView
    },
    {
      path: '/posts/?tag=:tag',
      name: 'postByTag',
      component: Posts
    }
  ]
})
