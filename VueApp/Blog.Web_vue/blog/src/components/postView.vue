<template>
  <div id="posts" align=left>
    <div>
      <div v-for="item in postList.records" :key="item.postId">
        <h4>{{ item.header }}</h4>
        <p>{{ item.body }}</p>
        <span><router-link :to="{ name: 'posts', params: { post_id: item.postId }}">к списку</router-link></span>
      </div>
    </div>
  </div>
</template>

<script>
import { BlogPostService } from '@/common/api.service'

export default {
  name: 'postView',
  data: function () {
    return {
      postList: '',
      postApiUrl: 'http://localhost:59998/api/blog/posts/' + this.$route.params.post_id,
      error: ''
    }
  },

  created: function () {
    this.fetchData()
  },

  methods: {
    setData: function (json) {
      this.postList = json
    },

    fetchData: function () {
      BlogPostService.getPostsById(this.$route.params.post_id, this.setData)
    }
  }
}
</script>
