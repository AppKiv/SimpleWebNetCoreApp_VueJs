<template>
  <div id="posts" align=left>
    <h3>{{ postList.totalPages }}</h3>
    <ul>
      <li v-for="item in postList.records" :key="item.postId">
        <h4>{{ item.header }}</h4>
        <p>{{ item.preview }}</p>
        <span><router-link :to="{ name: 'postView', params: { post_id: item.postId }}">перейти</router-link></span>
      </li>
    </ul>
  </div>
</template>

<script>
import { BlogPostService } from '@/common/api.service'

export default {
  name: 'posts',
  data: function () {
    return {
      postList: '',
      error: ''
    }
  },

  created: function () {
    this.fetchData()
  },

  methods: {
    fetchData: function () {
      let tag = ''
      if ((this.$route.params.tag !== '') && (this.$route.params.tag !== undefined)) {
        tag = this.$route.params.tag
      }
      BlogPostService.getPostsByTag(tag, this.setData)
    },

    setData: function (json) {
      this.postList = json
    }
  }
}
</script>
