<template>
  <div id="tags" align=left>
    <div>
      <div v-for="item in tagList.records" :key="item.tag">
        <span>
            <router-link :to="{ name: 'postByTag', params: { tag: item.tag }}">
              {{ item.tag}}
            </router-link>
        </span>
      </div>
    </div>
  </div>
</template>

<script>
import { BlogPostService } from '@/common/api.service'

export default {
  name: 'tagView',
  data: function () {
    return {
      tagList: '',
      error: ''
    }
  },

  created: function () {
    this.fetchData()
  },

  methods: {
    setData: function (json) {
      this.tagList = json
    },

    fetchData: function () {
      BlogPostService.getTags(this.setData)
    }
  }
}
</script>
